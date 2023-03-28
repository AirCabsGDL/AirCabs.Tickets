using AirCabs.Tickets.Domain.Entities;

namespace AirCabs.Tickets.Domain.UsesCases.BuyTickets;

public interface IBuyTicketCashUseCase
{
    public Ticket Execute(BuyTicketCashRequest request);
}