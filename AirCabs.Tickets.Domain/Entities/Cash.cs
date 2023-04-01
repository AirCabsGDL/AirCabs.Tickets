namespace AirCabs.Tickets.Domain.Entities;

public record Cash(decimal Amount)
{
    public Cash Subtract(Cash amount)
    {
        return new Cash(Amount - amount.Amount);
    }

    public static Cash Zero() => new Cash(0);
}