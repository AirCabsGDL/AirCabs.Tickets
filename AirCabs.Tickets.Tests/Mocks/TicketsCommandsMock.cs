using System.Collections.Generic;
using AirCabs.Tickets.Domain.Entities;
using AirCabs.Tickets.Domain.Ports;

namespace AirCabs.Tickets.Tests.Mocks;

public class TicketsCommandsMock : ITicketsCommands
{
    private readonly List<Ticket> _tickets;
    public IReadOnlyList<Ticket> Tickets => _tickets.AsReadOnly();

    public TicketsCommandsMock()
    {
        _tickets = new List<Ticket>();
    }

    public void Save(Ticket ticket)
    {
        _tickets.Add(ticket);
    }
}