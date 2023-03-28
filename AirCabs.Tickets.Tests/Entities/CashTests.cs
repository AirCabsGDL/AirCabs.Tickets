using AirCabs.Tickets.Domain.Entities;
using Xunit;

namespace AirCabs.Tickets.Tests.Entities;

public class CashTests
{
    [Theory]
    [InlineData(1, 1, 2)]
    public void Add_Quantity_to_cash(decimal amount, decimal adding, decimal expected)
    {
        // Arrange
        var cash = new Cash(amount);
        var addingCash = new Cash(adding);

        // Act
        var result = cash.Add(addingCash);

        // Assert
        Assert.Equal(expected, result.Amount);
    }
}