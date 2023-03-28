namespace AirCabs.Tickets.Domain.Exceptions;

public class UncoveredZoneException : Exception
{
    public string FullAddress { get; }

    public UncoveredZoneException(string address, string? message = null) : base(message)
    {
        FullAddress = address;
    }
}