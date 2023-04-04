using AirCabs.Tickets.Domain.Entities.Addresses;
using AirCabs.Tickets.Domain.Entities.Riders;

namespace AirCabs.Tickets.Domain.Entities.Tickets;

public class TicketCreditCard : ITicket
{
    public TicketCreditCard(Id id, IRider rider, Address destination, Zone destinationZone)
    {
        Id = id;
        Summary = new TicketSummary(destination, destinationZone.Price, destinationZone.Price, rider);
        DestinationZone = destinationZone;
    }
    
    public TicketCreditCard(Id id, Address destination, Zone destinationZone)
    {
        Id = id;
        Summary = new TicketSummary(destination, destinationZone.Price, destinationZone.Price, null);
        DestinationZone = destinationZone;
    }

    public static TicketCreditCard Create(IRider rider, Address destination, Zone destinationZone)
    {
        return new TicketCreditCard(new Id(), rider, destination, destinationZone);
    }

    public static TicketCreditCard CreateNotRiderData(Address destination, Zone destinationZone)
    {
        return new TicketCreditCard(new Id(), destination, destinationZone);
    }

    public Id Id { get; }
    public TicketSummary Summary { get; }

    public Zone DestinationZone { get; }

    public void Pay(Money amount)
    {
        Summary.ChangeTotalPayed(amount);
    }
}