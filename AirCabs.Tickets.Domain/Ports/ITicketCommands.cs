using AirCabs.Tickets.Domain.Entities.Tickets;

namespace AirCabs.Tickets.Domain.Ports;

public interface ITicketCommands
{
    void Save(ITicket ticketCash);
}