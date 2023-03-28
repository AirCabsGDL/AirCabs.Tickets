namespace AirCabs.Tickets.Domain.Entities;

public record Cash(decimal Amount = 0)
{
    public Cash Add(decimal amount)
    {
        return new Cash(Amount + amount);
    }
}