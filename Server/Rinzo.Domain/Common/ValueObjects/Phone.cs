namespace Rinzo.Domain.Common.ValueObjects;

public sealed class Phone
{
    public int CountryCode { get; private set; }
    public string PhoneNumber { get; private set; } = string.Empty;

    private Phone() { }

    public static Phone Create(int countryCode, string phoneNumber) =>
        new() { CountryCode = countryCode, PhoneNumber = phoneNumber.Trim() };
}
