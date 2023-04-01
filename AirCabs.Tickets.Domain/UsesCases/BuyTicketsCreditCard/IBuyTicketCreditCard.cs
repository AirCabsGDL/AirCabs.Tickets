using AirCabs.Tickets.Domain.Entities.Tickets;

namespace AirCabs.Tickets.Domain.UsesCases.BuyTicketsCreditCard;

public interface IBuyTicketCreditCard
{
    TicketCash Execute();
}