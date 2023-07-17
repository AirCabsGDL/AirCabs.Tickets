using AirCabs.Tickets.Domain.Entities.Addresses;
using AirCabs.Tickets.Domain.Entities.Riders;

namespace AirCabs.Tickets.Domain.Entities.Tickets;

public class TicketFactory : ITicketFactory
{
    public TicketCash CreateTicketCash(RiderName? rider, Address destination, Zone destinationZone)
    {
        return rider != null
            ? TicketCash.Create(new AnonymousRider(rider), destination, destinationZone)
            : TicketCash.CreateNotRiderData(destination, destinationZone);
    }

    public TicketCreditCard CreateTicketCreditCard(RiderName? rider, Address destination, Zone destinationZone)
    {
        return rider != null
            ? TicketCreditCard.Create(new AnonymousRider(rider), destination, destinationZone)
            : TicketCreditCard.CreateNotRiderData(destination, destinationZone);
    }
}