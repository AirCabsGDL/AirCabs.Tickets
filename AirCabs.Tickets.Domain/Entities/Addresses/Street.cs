namespace AirCabs.Tickets.Domain.Entities.Addresses;

public record Street(string Value)
{
    public string Value { get; init; } = Value ?? throw new ArgumentNullException(nameof(Value));
}