using AirCabs.Tickets.Domain.Entities.Tickets;
using AirCabs.Tickets.Domain.Ports;

namespace AirCabs.Tickets.Domain.UsesCases.BuyTickets.BuyTicketsCash;

public class BuyTicketCashUseCase : IBuyTicketCashUseCase
{
    private readonly IZoneQueries _zoneQueries;
    private readonly ITicketCommands _ticketCommands;
    private readonly IRiderWaitingQueue _riderWaitingQueue;
    private readonly TicketFactory _ticketFactory;

    public BuyTicketCashUseCase(IZoneQueries zoneQueries, ITicketCommands ticketCommands,
        IRiderWaitingQueue riderWaitingQueue)
    {
        _zoneQueries = zoneQueries;
        _ticketCommands = ticketCommands;
        _riderWaitingQueue = riderWaitingQueue;
        _ticketFactory = new TicketFactory();
    }

    public TicketCash Execute(BuyTicketCashRequest request)
    {
        var zone = _zoneQueries.GetZoneByAddress(request.Destination);
        var ticket = _ticketFactory.CreateTicketCash(request.RiderName, request.Destination, zone);

        var cashAmount = request.Amount;

        ticket.Pay(cashAmount);

        _ticketCommands.Save(ticket);
        _riderWaitingQueue.AddTicket(ticket);

        return ticket;
    }
}