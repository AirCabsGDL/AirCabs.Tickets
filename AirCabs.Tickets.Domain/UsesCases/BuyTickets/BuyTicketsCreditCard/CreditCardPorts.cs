using AirCabs.Tickets.Domain.Ports;

namespace AirCabs.Tickets.Domain.UsesCases.BuyTickets;

public class CreditCardPorts
{
    public IZoneQueries ZoneQueries { get; }
    public ITicketCommands TicketCommands { get; }
    public IRiderWaitingQueue RiderWaitingQueue { get; }

    public CreditCardPorts(IZoneQueries zoneQueries, ITicketCommands ticketCommands,
        IRiderWaitingQueue riderWaitingQueue)
    {
        ZoneQueries = zoneQueries;
        TicketCommands = ticketCommands;
        RiderWaitingQueue = riderWaitingQueue;
    }
}