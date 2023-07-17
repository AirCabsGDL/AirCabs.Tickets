using AirCabs.Tickets.Domain.Entities.Addresses;
using AirCabs.Tickets.Domain.Entities.Riders;

namespace AirCabs.Tickets.Domain.UsesCases.BuyTickets.BuyTicketsCreditCard;

public record BuyTicketCreditCardRequest(RiderName? RiderName, Address Destination);