using AirCabs.Tickets.BehaviorTests.Mocks;
using AirCabs.Tickets.Domain.Entities;
using AirCabs.Tickets.Domain.Entities.Addresses;
using AirCabs.Tickets.Domain.Entities.Tickets;
using AirCabs.Tickets.Domain.Ports;
using Moq;

namespace AirCabs.Tickets.BehaviorTests.Features.BuyTickets.Contexts;

public class BuyTicketContext
{
    public Address Destination { get; set;  }

    public Zone DestinationZone { get; set; }
    
    public TicketCommandsMock TicketCommandsMock { get; }
    
    public Ticket Ticket { get; set; }
    
    public Cash TotalPayed { get; set; }

    public BuyTicketContext()
    {
        TicketCommandsMock = new TicketCommandsMock();
    }
    
    public IZoneQueries CreateMockForZoneQueries()
    {
        var mock = new Mock<IZoneQueries>();
        mock.Setup(x => x.GetZoneByAddress(Destination)).Returns(DestinationZone);
        
        return mock.Object;
    }
}