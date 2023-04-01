using AirCabs.Tickets.Domain.Entities.Addresses;
using AirCabs.Tickets.Domain.Entities.Riders;
using AirCabs.Tickets.Domain.Exceptions;

namespace AirCabs.Tickets.Domain.Entities.Tickets;

public class TicketCash : ITicket
{
    public TicketCash(Address destination, Zone destinationZone)
    {
        Id = new Id();
        Summary = new TicketSummary(destination, destinationZone.Price, Cash.Zero(), null);
        DestinationZone = destinationZone;
        Change = Cash.Zero();
    }

    public TicketCash(IRider rider, Address destination, Zone destinationZone) : this(destination, destinationZone)
    {
        Summary = new TicketSummary(destination, destinationZone.Price, Cash.Zero(), rider);
    }

    public Id Id { get; }
    public TicketSummary Summary { get; }
    public Zone DestinationZone { get; }
    public Cash Change { get; protected set; }

    public void Pay(Cash amount)
    {
        if (amount.Amount < Summary.Cost.Amount) throw new InsufficientAmountException(Summary.Cost, amount);

        Change = amount.Subtract(Summary.Cost);
        Summary.ChangeTotalPayed(amount);
    }
}