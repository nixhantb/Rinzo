using FluentValidation;
using JobLeet.WebApi.JobLeet.Api.Models.Companies.V1;
using JobLeet.WebApi.JobLeet.Core.Entities.Companies.V1;
using JobLeet.WebApi.JobLeet.Core.Interfaces.Companies.V1;
using Microsoft.AspNetCore.Mvc;

namespace JobLeet.WebApi.JobLeet.Api.Controllers.Companies.V1
{
    [Route("api/v1/companies")]
    public class CompanyController : BaseApiController<Company, CompanyModel, ICompanyService>
    {
        public CompanyController(ICompanyService companyService, IValidator<Company> validator)
            : base(companyService, validator) { }
    }
}
