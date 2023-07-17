namespace AirCabs.Tickets.Domain.Entities;

public record Money(decimal Amount)
{
    public Money Subtract(Money amount)
    {
        return new Money(Amount - amount.Amount);
    }

    public static Money Zero() => new Money(0);
}