using Rinzo.Core.Entities.Common;
using Rinzo.Core.Entities.Companies;

namespace Rinzo.Core.Entities.Employers
{
    public class Employer : BaseEntity
    {
        public PersonName? Name { get; set; }
        public Address? Address { get; set; }
        public Phone? Phone { get; set; }
        public Company? Company { get; set; }
        public EmployerType? EmployerType { get; set; }
        public Industry? IndustryType { get; set; }
    }
}
