namespace Rinzo.Domain.Common.ValueObjects;

public enum EmailType
{
    Personal = 1,
    Work = 2,
    Other = 3,
}

public sealed class Email
{
    public string Address { get; private set; } = string.Empty;
    public EmailType Type { get; private set; } = EmailType.Personal;

    private Email() { }

    public static Email Create(string address, EmailType type) =>
        new() { Address = address.Trim(), Type = type };
}
