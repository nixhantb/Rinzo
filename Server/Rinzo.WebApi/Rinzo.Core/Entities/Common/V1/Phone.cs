namespace JobLeet.WebApi.JobLeet.Core.Entities.Common.V1
{
    public class Phone : BaseEntity
    {
        public int CountryCode { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
