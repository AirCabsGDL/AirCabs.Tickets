using AirCabs.Tickets.Domain.Entities;
using AirCabs.Tickets.Domain.Entities.Addresses;
using AirCabs.Tickets.Domain.Entities.Riders;

namespace AirCabs.Tickets.Domain.UsesCases.BuyTickets;

public record BuyTicketCashRequest(RiderName? RiderName, Address Destination, Cash Amount);