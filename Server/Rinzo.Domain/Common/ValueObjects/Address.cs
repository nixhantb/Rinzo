namespace Rinzo.Domain.Common.ValueObjects;

// A value object: no identity of its own, always owned by an entity. EF Core maps it
// with OwnsOne, as columns on the owner's table - no separate id, no separate table.
public sealed class Address
{
    public string Street { get; private set; } = string.Empty;
    public string City { get; private set; } = string.Empty;
    public string State { get; private set; } = string.Empty;
    public string PostalCode { get; private set; } = string.Empty;
    public string Country { get; private set; } = string.Empty;

    private Address() { }

    public static Address Create(
        string street,
        string city,
        string state,
        string postalCode,
        string country
    ) =>
        new()
        {
            Street = street.Trim(),
            City = city.Trim(),
            State = state.Trim(),
            PostalCode = postalCode.Trim(),
            Country = country.Trim(),
        };
}
