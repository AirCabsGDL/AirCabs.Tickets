namespace AirCabs.Tickets.Domain.Entities.Riders;

public class AnonymousRider : IRider
{
    public Id Id { get; }

    public RiderName Name { get; }

    public AnonymousRider(RiderName name)
    {
        Id = new Id();
        Name = name;
    }
}