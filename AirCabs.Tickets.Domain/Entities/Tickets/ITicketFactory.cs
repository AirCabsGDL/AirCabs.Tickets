using AirCabs.Tickets.Domain.Entities.Addresses;
using AirCabs.Tickets.Domain.Entities.Riders;

namespace AirCabs.Tickets.Domain.Entities.Tickets;

public interface ITicketFactory
{
    public TicketCash CreateTicketCash(RiderName? rider, Address destination, Zone destinationZone);
    
    public TicketCreditCard CreateTicketCreditCard(RiderName? rider, Address destination, Zone destinationZone);
}