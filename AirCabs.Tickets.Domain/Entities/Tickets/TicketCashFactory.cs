using AirCabs.Tickets.Domain.Entities.Addresses;
using AirCabs.Tickets.Domain.Entities.Riders;

namespace AirCabs.Tickets.Domain.Entities.Tickets;

public class TicketCashFactory : ITicketFactory
{
    public TicketCash CreateTicket(RiderName? rider, Address destination, Zone destinationZone)
    {
       return rider != null ? new TicketCash(new AnonymousRider(rider), destination, destinationZone)
                    : new TicketCash(destination, destinationZone);
    }
}