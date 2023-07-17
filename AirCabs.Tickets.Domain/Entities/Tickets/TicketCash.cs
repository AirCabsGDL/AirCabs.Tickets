using AirCabs.Tickets.Domain.Entities.Addresses;
using AirCabs.Tickets.Domain.Entities.Riders;
using AirCabs.Tickets.Domain.Exceptions;

namespace AirCabs.Tickets.Domain.Entities.Tickets;

public class TicketCash : ITicket
{
    public TicketCash(Id id, IRider rider, Address destination, Zone destinationZone, Money change)
    {
        Id = id;
        Summary = new TicketSummary(destination, destinationZone.Price, destinationZone.Price, rider);
        DestinationZone = destinationZone;
        Change = change;
    }
    
    public TicketCash(Id id, Address destination, Zone destinationZone, Money change)
    {
        Id = id;
        Summary = new TicketSummary(destination, destinationZone.Price, destinationZone.Price, null);
        DestinationZone = destinationZone;
        Change = change;
    }

    public static TicketCash Create(IRider rider, Address destination, Zone destinationZone)
    {
        return new TicketCash(new Id(), rider, destination, destinationZone, Money.Zero());
    }

    public static TicketCash CreateNotRiderData(Address destination, Zone destinationZone)
    {
        return new TicketCash(new Id(), destination, destinationZone, Money.Zero());
    }

    public Id Id { get; }
    public TicketSummary Summary { get; }
    public Zone DestinationZone { get; }
    public Money Change { get; protected set; }

    public void Pay(Money amount)
    {
        if (amount.Amount < Summary.Cost.Amount) throw new InsufficientAmountException(Summary.Cost, amount);

        Change = amount.Subtract(Summary.Cost);
        Summary.ChangeTotalPayed(amount);
    }
}