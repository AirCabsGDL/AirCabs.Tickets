namespace AirCabs.Tickets.Domain.Entities;

public record Cash(decimal Amount = 0)
{
    public Cash Subtract(Cash amount)
    {
        return new Cash(Amount - amount.Amount);
    }
}