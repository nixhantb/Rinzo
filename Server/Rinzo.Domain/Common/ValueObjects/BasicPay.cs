namespace Rinzo.Domain.Common.ValueObjects;

public sealed class BasicPay
{
    public decimal MinimumPay { get; private set; }
    public decimal MaximumPay { get; private set; }
    public string Currency { get; private set; } = string.Empty;

    private BasicPay() { }

    public static BasicPay Create(decimal minimumPay, decimal maximumPay, string currency)
    {
        if (maximumPay < minimumPay)
        {
            throw new ArgumentException(
                "Maximum pay cannot be less than minimum pay.",
                nameof(maximumPay)
            );
        }

        return new BasicPay
        {
            MinimumPay = minimumPay,
            MaximumPay = maximumPay,
            Currency = currency.Trim(),
        };
    }
}
