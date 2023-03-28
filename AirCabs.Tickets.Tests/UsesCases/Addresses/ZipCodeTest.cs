using System;
using AirCabs.Tickets.Domain.Entities.Addresses;
using Xunit;

namespace AirCabs.Tickets.Tests.UsesCases.Addresses;

public class ZipCodeTest
{
    [Theory]
    [InlineData("=/")]
    [InlineData("2324A?")]
    public void Try_to_create_a_zip_code_with_an_invalid_character(string zipCode)
    {
        // Arrange/Act/Assert
        Assert.Throws<ArgumentException>(() => new ZipCode(zipCode));
    }

    [Theory]
    [InlineData("131234412")]
    [InlineData("31312A312")]
    public void Try_to_create_a_zip_code_with_an_invalid_size(string zipCode)
    {
        // Arrange/Act/Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => new ZipCode(zipCode));
    }
    
    [Theory]
    [InlineData("12345")]
    [InlineData("1234A")]
    [InlineData("123456")]
    public void Create_a_valid_zip_code(string zipCode)
    {
        // Arrange/Act
        var sut = new ZipCode(zipCode);

        // Assert
        Assert.Equal(zipCode, sut.Value);
    }
}