using AirCabs.Tickets.Domain.Entities.Addresses;
using AirCabs.Tickets.Domain.Entities.Riders;
using AirCabs.Tickets.Domain.Exceptions;

namespace AirCabs.Tickets.Domain.Entities.Tickets;

public class Ticket
{
    public Ticket(Address destination, Zone destinationZone)
    {
        Id = new Id();
        Destination = destination;
        Cost = destinationZone.Price;
        DestinationZone = destinationZone;
        Change = new Cash();
        TotalPayed = new Cash();
    }

    public Ticket(IRider rider, Address destination, Zone destinationZone) : this(destination, destinationZone)
    {
        Rider = rider;
    }

    public Id Id { get; }

    public Address Destination { get; }

    public Cash Cost { get; }

    public Cash Change { get; protected set; }

    public Cash TotalPayed { get; protected set; }

    public IRider? Rider { get; }

    public Zone DestinationZone { get; }

    public void Pay(Cash amount)
    {
        if (amount.Amount < Cost.Amount) throw new InsufficientAmountException(Cost, amount);

        Change = amount.Subtract(Cost);
        TotalPayed = amount;
    }
}