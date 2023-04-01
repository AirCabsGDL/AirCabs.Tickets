using AirCabs.Tickets.Domain.Exceptions;
using AirCabs.Tickets.Domain.UsesCases.BuyTicketsCreditCard;
using Xunit;

namespace AirCabs.Tickets.Tests.UsesCases.BuyTickets;

public class BuyTicketCreditCardTest
{
    [Fact]
    public void Try_to_buy_a_ticket_but_the_rider_does_not_have_enough_funds()
    {
        // Arrange
        IBuyTicketCreditCard sut = new BuyTicketCreditCard();

        // Act/Assert
        Assert.Throws<PaymentDeclineException>(() => sut.Execute());
    }
}