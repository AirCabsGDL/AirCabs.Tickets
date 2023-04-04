using AirCabs.Tickets.Domain.Entities.Tickets;
using AirCabs.Tickets.Domain.Ports;

namespace AirCabs.Tickets.Domain.UsesCases.BuyTickets.BuyTicketsCreditCard;

public class BuyTicketCreditCard : IBuyTicketCreditCard
{
    private readonly CreditCardPorts _creditCardPorts;
    private readonly IPaymentCommands _paymentCommands;

    public BuyTicketCreditCard(CreditCardPorts creditCardPorts, IPaymentCommands paymentCommands)
    {
        _creditCardPorts = creditCardPorts;
        _paymentCommands = paymentCommands;
    }
    
    public TicketCreditCard Execute(BuyTicketCreditCardRequest request)
    {
        var zone = _creditCardPorts.ZoneQueries.GetZoneByAddress(request.Destination);
        var ticketFactory = new TicketFactory();
        
        var ticket = ticketFactory.CreateTicketCreditCard(request.RiderName, request.Destination, zone);
        
        _paymentCommands.PayWithCreditCard(ticket.Summary.Cost);
        ticket.Pay(ticket.Summary.Cost);

        return ticket;
    }
}