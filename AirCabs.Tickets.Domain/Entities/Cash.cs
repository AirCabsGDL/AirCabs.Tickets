namespace AirCabs.Tickets.Domain.Entities;

public record Cash(decimal Amount = 0)
{
    public Cash Add(Cash amount)
    {
        return new Cash(Amount + amount.Amount);
    }
    
    public Cash Subtract(Cash amount)
    {
        return new Cash(Amount - amount.Amount);
    }
}