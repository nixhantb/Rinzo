using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Rinzo.Core.Entities.Companies.V1;
using Rinzo.Core.Interfaces.Companies.V1;

namespace Rinzo.WebApi.Controllers.Companies.V1
{
    [Route("api/v1/companies")]
    public class CompanyController : BaseApiController<Company, ICompanyRepository>
    {
        public CompanyController(
            ICompanyRepository companyRepository,
            IValidator<Company> validator
        )
            : base(companyRepository, validator) { }
    }
}
