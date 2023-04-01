using AirCabs.Tickets.Domain.Entities.Addresses;
using AirCabs.Tickets.Domain.Entities.Riders;

namespace AirCabs.Tickets.Domain.Entities.Tickets;

public class TicketSummary
{
    public TicketSummary(Address destination, Cash cost, Cash totalPayed, IRider? rider)
    {
        Destination = destination;
        Cost = cost;
        Rider = rider;
        TotalPayed = totalPayed;
    }

    public Cash TotalPayed { get; private set; }
    public Address Destination { get; }
    public Cash Cost { get; }
    public IRider? Rider { get; }

    public void ChangeTotalPayed(Cash amount)
    {
        TotalPayed = amount;
    }
}