using AirCabs.Tickets.Domain.Entities;

namespace AirCabs.Tickets.Domain.Ports;

public interface ITicketsCommands
{
    void Save(Ticket ticket);
}