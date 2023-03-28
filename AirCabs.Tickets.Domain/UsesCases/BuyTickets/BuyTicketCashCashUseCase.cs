using AirCabs.Tickets.Domain.Entities;
using AirCabs.Tickets.Domain.Entities.Riders;
using AirCabs.Tickets.Domain.Entities.Tickets;
using AirCabs.Tickets.Domain.Ports;

namespace AirCabs.Tickets.Domain.UsesCases.BuyTickets;

public class BuyTicketCashCashUseCase : IBuyTicketCashUseCase
{
    private readonly IZoneQueries _zoneQueries;
    private readonly ITicketCommands _ticketCommands;
    private readonly TicketCashFactory _ticketFactory;

    public BuyTicketCashCashUseCase(IZoneQueries zoneQueries, ITicketCommands ticketCommands)
    {
        _zoneQueries = zoneQueries;
        _ticketCommands = ticketCommands;
        _ticketFactory = new TicketCashFactory();
    }

    public Ticket Execute(BuyTicketCashRequest request)
    {
        var zone = _zoneQueries.GetZoneByAddress(request.Destination);
        var ticket = _ticketFactory.CreateTicket(request.RiderName, request.Destination, zone);
        
        var cashAmount = request.Amount;
        
        ticket.Pay(cashAmount);
        
        _ticketCommands.Save(ticket);

        return ticket;
    }
}   