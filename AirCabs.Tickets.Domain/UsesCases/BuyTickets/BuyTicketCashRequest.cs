using AirCabs.Tickets.Domain.Entities.Addresses;

namespace AirCabs.Tickets.Domain.UsesCases.BuyTickets;

public record BuyTicketCashRequest(Address Destination, decimal amount);