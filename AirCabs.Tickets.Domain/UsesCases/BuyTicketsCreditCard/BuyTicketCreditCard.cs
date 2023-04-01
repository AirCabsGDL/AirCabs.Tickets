using AirCabs.Tickets.Domain.Entities.Tickets;
using AirCabs.Tickets.Domain.Exceptions;

namespace AirCabs.Tickets.Domain.UsesCases.BuyTicketsCreditCard;

public class BuyTicketCreditCard : IBuyTicketCreditCard
{
    public Ticket Execute()
    {
        throw new PaymentDeclineException("Payment Declined");
    }
}