using JobLeet.WebApi.JobLeet.Api.Models.Employers.V1;
using JobLeet.WebApi.JobLeet.Core.Entities.Employers.V1;

namespace JobLeet.WebApi.JobLeet.Core.Interfaces.Employers.V1
{
    public interface IEmployerRepository : IRepository<Employer, EmployerModel> { }
}
