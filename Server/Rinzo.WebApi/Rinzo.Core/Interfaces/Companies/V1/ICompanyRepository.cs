using JobLeet.WebApi.JobLeet.Api.Models.Companies.V1;
using JobLeet.WebApi.JobLeet.Core.Entities.Companies.V1;

namespace JobLeet.WebApi.JobLeet.Core.Interfaces.Companies.V1
{
    public interface ICompanyRepository : IRepository<Company, CompanyModel> { }
}
