namespace AirCabs.Tickets.Domain.Entities;

public record Id
{
    public string Value { get; init; }
    
    public Id()
    {
        Value = Guid.NewGuid().ToString();
    }
}