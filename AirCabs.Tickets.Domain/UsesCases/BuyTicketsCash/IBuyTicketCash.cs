using AirCabs.Tickets.Domain.Entities.Tickets;

namespace AirCabs.Tickets.Domain.UsesCases.BuyTickets;

public interface IBuyTicketCashUseCase
{
    public TicketCash Execute(BuyTicketCashRequest request);
}