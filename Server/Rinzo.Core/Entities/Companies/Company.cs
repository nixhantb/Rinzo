namespace Rinzo.Core.Entities.Companies
{
    public class Company : BaseEntity
    {
        public string? CompanyName { get; set; }
        public CompanyProfile? Profile { get; set; }
    }
}
