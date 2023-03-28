using AirCabs.Tickets.Domain.Entities.Addresses;
using AirCabs.Tickets.Domain.Exceptions;

namespace AirCabs.Tickets.Domain.UsesCases.BuyTickets;

public class BuyTicketUseCase : IBuyTicketUseCase
{
    public void Execute(Address destination)
    {
        throw new UncoveredZoneException(destination.GetFullAddress());
    }
}