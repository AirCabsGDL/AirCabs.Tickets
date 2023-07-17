using AirCabs.Tickets.Domain.Entities;

namespace AirCabs.Tickets.Domain.Exceptions;

public class InsufficientAmountException : Exception
{
    public InsufficientAmountException(Money cost, Money paid, string message = null) : base(message)
    {
        Cost = cost;
        Paid = paid;
    }

    public Money Paid { get; }

    public Money Cost { get; }
}