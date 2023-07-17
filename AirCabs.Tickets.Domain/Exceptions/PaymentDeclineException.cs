namespace AirCabs.Tickets.Domain.Exceptions;

public class PaymentDeclineException : Exception 
{
    public PaymentDeclineException(string message = null) : base(message) { }
}