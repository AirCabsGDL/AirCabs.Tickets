using AirCabs.Tickets.Domain.Entities.Addresses;
using AirCabs.Tickets.Domain.Entities.Riders;

namespace AirCabs.Tickets.Domain.Entities.Tickets;

public class TicketSummary
{
    public TicketSummary(Address destination, Money cost, Money totalPayed, IRider? rider)
    {
        Destination = destination;
        Cost = cost;
        Rider = rider;
        TotalPayed = totalPayed;
    }

    public Money TotalPayed { get; private set; }
    public Address Destination { get; }
    public Money Cost { get; }
    public IRider? Rider { get; }

    public void ChangeTotalPayed(Money amount)
    {
        TotalPayed = amount;
    }
}