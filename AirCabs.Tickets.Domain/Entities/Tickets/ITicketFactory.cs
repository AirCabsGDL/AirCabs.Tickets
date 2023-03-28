using AirCabs.Tickets.Domain.Entities.Addresses;
using AirCabs.Tickets.Domain.Entities.Riders;

namespace AirCabs.Tickets.Domain.Entities.Tickets;

public interface ITicketFactory
{
    public Ticket CreateTicket(RiderName? rider, Address destination, Zone destinationZone);
}