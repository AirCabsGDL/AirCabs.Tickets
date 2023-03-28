using AirCabs.Tickets.Domain.Entities;

namespace AirCabs.Tickets.Domain.Exceptions;

public class InsufficientAmountException : Exception
{
    public InsufficientAmountException(Cash cost, Cash paid, string message = null) : base(message)
    {
        Cost = cost;
        Paid = paid;
    }

    public Cash Paid { get; }

    public Cash Cost { get; }
}