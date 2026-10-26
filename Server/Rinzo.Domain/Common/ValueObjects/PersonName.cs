namespace Rinzo.Domain.Common.ValueObjects;

public sealed class PersonName
{
    public string FirstName { get; private set; } = string.Empty;
    public string? MiddleName { get; private set; }
    public string LastName { get; private set; } = string.Empty;

    private PersonName() { }

    public static PersonName Create(string firstName, string? middleName, string lastName) =>
        new()
        {
            FirstName = firstName.Trim(),
            MiddleName = string.IsNullOrWhiteSpace(middleName) ? null : middleName.Trim(),
            LastName = lastName.Trim(),
        };
}
