using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Rinzo.Core.Entities.Companies;
using Rinzo.Core.Interfaces.Companies;

namespace Rinzo.WebApi.Controllers.Companies
{
    [Route("api/companies")]
    public class CompanyController : BaseApiController<Company, ICompanyRepository>
    {
        public CompanyController(
            ICompanyRepository companyRepository,
            IValidator<Company> validator
        )
            : base(companyRepository, validator) { }
    }
}
