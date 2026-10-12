namespace Rinzo.Core.Entities.Companies.V1
{
    public class Company : BaseEntity
    {
        public string? CompanyName { get; set; }
        public CompanyProfile? Profile { get; set; }
    }
}
