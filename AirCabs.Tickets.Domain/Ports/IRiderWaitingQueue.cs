using AirCabs.Tickets.Domain.Entities.Tickets;

namespace AirCabs.Tickets.Domain.Ports;

public interface IRiderWaitingQueue
{
    public void AddTicket(Ticket ticket);
}