using AirCabs.Tickets.Domain.Entities.Tickets;
using AirCabs.Tickets.Domain.Ports;

namespace AirCabs.Tickets.BehaviorTests.Mocks;

public class TicketCommandsMock : ITicketCommands
{
    private readonly List<TicketCash> _tickets;
    public IReadOnlyList<TicketCash> Tickets => _tickets.AsReadOnly();

    public TicketCommandsMock()
    {
        _tickets = new List<TicketCash>();
    }

    public void Save(TicketCash ticketCash)
    {
        _tickets.Add(ticketCash);
    }
}