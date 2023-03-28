namespace AirCabs.Tickets.Domain.Entities.Addresses;

public record ZipCode
{
    public ZipCode(string value)
    {
        ValidateZipCode(value);

        Value = value;
    }

    public string Value { get; }

    private static void ValidateZipCode(string value)
    {
        if (value.Length > 6)
        {
            throw new ArgumentOutOfRangeException(nameof(value), "Zip code cannot be more than 6 digits.");
        }

        if (value.Any(c => !char.IsLetterOrDigit(c)))
        {
            throw new ArgumentException("Zip code must contain only letters and digits.");
        }
    }
}