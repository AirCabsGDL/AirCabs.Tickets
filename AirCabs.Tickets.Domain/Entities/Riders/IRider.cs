namespace AirCabs.Tickets.Domain.Entities.Riders;

public interface IRider
{
    public Id Id { get; }
    
    public RiderName Name { get; }
}