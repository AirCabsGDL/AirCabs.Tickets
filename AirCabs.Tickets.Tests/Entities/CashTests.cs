using AirCabs.Tickets.Domain.Entities;
using Xunit;

namespace AirCabs.Tickets.Tests.Entities;

public class CashTests
{
    [Theory]
    [InlineData(1, 1, 0)]
    public void Subtract_Quantity_to_cash(decimal amount, decimal adding, decimal expected)
    {
        // Arrange
        var cash = new Money(amount);
        var addingCash = new Money(adding);

        // Act
        var result = cash.Subtract(addingCash);

        // Assert
        Assert.Equal(expected, result.Amount);
    }
}