using AirCabs.Tickets.Domain.Entities;
using AirCabs.Tickets.Domain.Entities.Addresses;
using AirCabs.Tickets.Domain.Entities.Riders;

namespace AirCabs.Tickets.Domain.UsesCases.BuyTickets.BuyTicketsCash;

public record BuyTicketCashRequest(RiderName? RiderName, Address Destination, Money Amount);