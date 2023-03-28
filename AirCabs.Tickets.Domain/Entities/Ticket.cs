using AirCabs.Tickets.Domain.Entities.Addresses;
using AirCabs.Tickets.Domain.Exceptions;

namespace AirCabs.Tickets.Domain.Entities;

public class Ticket
{
    public Ticket(Address destination, Cash zonePrice)
    {
        Id = new Id();
        Destination = destination;
        Cost = zonePrice;
        Change = new Cash();
        TotalPayed = new Cash();
    }

    public Id Id { get; }
    
    public Address Destination { get; }
            
    public Cash Cost { get; }
    
    public Cash Change { get; protected set; }
    
    public Cash TotalPayed { get; protected set; }

    public void Pay(Cash amount)
    {
        if(amount.Amount < Cost.Amount) throw new InsufficientAmountException(Cost, amount);
        
        Change = amount.Add(-Cost.Amount);
        TotalPayed = amount;
    }
}