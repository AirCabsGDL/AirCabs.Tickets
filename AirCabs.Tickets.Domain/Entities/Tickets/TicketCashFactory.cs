using AirCabs.Tickets.Domain.Entities.Addresses;
using AirCabs.Tickets.Domain.Entities.Riders;

namespace AirCabs.Tickets.Domain.Entities.Tickets;

public class TicketCashFactory : ITicketFactory
{
    public Ticket CreateTicket(RiderName? rider, Address destination, Zone destinationZone)
    {
       return rider != null ? new Ticket(new AnonymousRider(rider), destination, destinationZone)
                    : new Ticket(destination, destinationZone);
    }
}