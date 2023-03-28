using AirCabs.Tickets.Domain.Entities.Addresses;

namespace AirCabs.Tickets.Domain.UsesCases.BuyTickets;

public interface IBuyTicketUseCase
{
    public void Execute(Address destination);
}