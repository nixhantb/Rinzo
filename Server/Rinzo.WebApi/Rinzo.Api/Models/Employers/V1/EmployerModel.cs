using JobLeet.WebApi.JobLeet.Api.Models.Common.V1;
using JobLeet.WebApi.JobLeet.Api.Models.Companies.V1;

namespace JobLeet.WebApi.JobLeet.Api.Models.Employers.V1
{
    public class EmployerModel : BaseModel
    {
        public PersonNameModel? Name { get; set; }

        public AddressModel? Address { get; set; }

        public PhoneModel? Phone { get; set; }

        public CompanyModel? Company { get; set; }

        public EmployerTypeModel? EmployerType { get; set; }

        public IndustryModel? IndustryType { get; set; }
    }
}
