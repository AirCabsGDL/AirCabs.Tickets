namespace AirCabs.Tickets.Domain.Entities;

public record Id()
{
    public string Value { get; init; } = Guid.NewGuid().ToString();
}