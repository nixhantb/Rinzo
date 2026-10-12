using FluentValidation;
using Rinzo.Core.Entities.Companies.V1;
using Rinzo.Core.Interfaces.Companies.V1;
using Microsoft.AspNetCore.Mvc;

namespace Rinzo.WebApi.Controllers.Companies.V1
{
    [Route("api/v1/companies")]
    public class CompanyController : BaseApiController<Company, ICompanyService>
    {
        public CompanyController(ICompanyService companyService, IValidator<Company> validator)
            : base(companyService, validator) { }
    }
}
