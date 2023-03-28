using AirCabs.Tickets.Domain.Entities;
using AirCabs.Tickets.Domain.Exceptions;
using AirCabs.Tickets.Domain.Ports;

namespace AirCabs.Tickets.Domain.UsesCases.BuyTickets;

public class BuyTicketCashCashUseCase : IBuyTicketCashUseCase
{
    private readonly IZoneQueries _zoneQueries;
    private readonly ITicketsCommands _ticketsCommands;

    public BuyTicketCashCashUseCase(IZoneQueries zoneQueries, ITicketsCommands ticketsCommands)
    {
        _zoneQueries = zoneQueries;
        _ticketsCommands = ticketsCommands;
    }

    public Ticket Execute(BuyTicketCashRequest request)
    {
        var zone = _zoneQueries.GetZoneByAddress(request.Destination);
        
        if(zone is null) throw new UncoveredZoneException(request.Destination.GetFullAddress());
        
        var ticket = new Ticket(request.Destination, zone.Price);
        var cashAmount = new Cash(request.amount);
        
        ticket.Pay(cashAmount);
        
        _ticketsCommands.Save(ticket);

        return ticket;
    }
}