using AirCabs.Tickets.Domain.Entities.Tickets;
using AirCabs.Tickets.Domain.Ports;

namespace AirCabs.Tickets.BehaviorTests.Mocks;

public class RiderWaitingQueueMock : IRiderWaitingQueue
{
    private readonly List<TicketCash> _tickets;

    public RiderWaitingQueueMock()
    {
        _tickets = new List<TicketCash>();
    }
    
    public IReadOnlyList<TicketCash> Tickets => _tickets.AsReadOnly();
    
    public void AddTicket(TicketCash ticketCash)
    {
        _tickets.Add(ticketCash);
    }
}