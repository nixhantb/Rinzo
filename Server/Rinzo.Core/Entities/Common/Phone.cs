namespace Rinzo.Core.Entities.Common
{
    public class Phone : BaseEntity
    {
        public int CountryCode { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
