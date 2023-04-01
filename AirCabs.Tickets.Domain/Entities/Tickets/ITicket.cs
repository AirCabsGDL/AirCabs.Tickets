namespace AirCabs.Tickets.Domain.Entities.Tickets;

public interface ITicket
{
    public void Pay(Cash amount);
}