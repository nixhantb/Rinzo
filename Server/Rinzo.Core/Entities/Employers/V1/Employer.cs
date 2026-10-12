using Rinzo.Core.Entities.Common.V1;
using Rinzo.Core.Entities.Companies.V1;

namespace Rinzo.Core.Entities.Employers.V1
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
