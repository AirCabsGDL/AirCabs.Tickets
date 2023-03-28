using AirCabs.Tickets.Domain.Entities.Tickets;
using AirCabs.Tickets.Domain.Ports;

namespace AirCabs.Tickets.BehaviorTests.Mocks;

public class RiderWaitingQueueMock : IRiderWaitingQueue
{
    private readonly List<Ticket> _tickets;

    public RiderWaitingQueueMock()
    {
        _tickets = new List<Ticket>();
    }
    
    public IReadOnlyList<Ticket> Tickets => _tickets.AsReadOnly();
    
    public void AddTicket(Ticket ticket)
    {
        _tickets.Add(ticket);
    }
}