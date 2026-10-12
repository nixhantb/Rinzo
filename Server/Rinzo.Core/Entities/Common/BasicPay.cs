namespace Rinzo.Core.Entities.Common
{
    public class BasicPay
    {
        public decimal? MinmumPay { get; set; }
        public decimal? MaximumPay { get; set; }
        public string? Currency { get; set; }
    }
}
