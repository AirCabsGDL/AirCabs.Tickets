using System.Collections.Generic;
using AirCabs.Tickets.Domain.Entities.Tickets;
using AirCabs.Tickets.Domain.Ports;

namespace AirCabs.Tickets.Tests.Mocks;

public class TicketCommandsMock : ITicketCommands
{
    private readonly List<ITicket> _tickets;
    public IReadOnlyList<ITicket> Tickets => _tickets.AsReadOnly();

    public TicketCommandsMock()
    {
        _tickets = new List<ITicket>();
    }

    public void Save(ITicket ticketCash)
    {
        _tickets.Add(ticketCash);
    }
}