using AirCabs.Tickets.Domain.Entities;
using AirCabs.Tickets.Domain.Entities.Addresses;

namespace AirCabs.Tickets.Domain.Ports;

public interface IZoneQueries
{
    public Zone GetZoneByAddress(Address address);
}