using AirCabs.Tickets.Domain.Entities;

namespace AirCabs.Tickets.Domain.Ports;

public interface IPaymentCommands
{
    public void PayWithCreditCard(Money amount);
}