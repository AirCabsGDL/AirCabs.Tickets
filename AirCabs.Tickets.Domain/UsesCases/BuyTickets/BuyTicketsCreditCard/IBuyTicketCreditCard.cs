using AirCabs.Tickets.Domain.Entities.Tickets;

namespace AirCabs.Tickets.Domain.UsesCases.BuyTickets.BuyTicketsCreditCard;

public interface IBuyTicketCreditCard
{
    public TicketCreditCard Execute(BuyTicketCreditCardRequest request);
} 