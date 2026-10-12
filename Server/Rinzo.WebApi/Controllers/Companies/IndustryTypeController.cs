using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Rinzo.Core.Entities.Companies;
using Rinzo.Core.Interfaces.Companies;

namespace Rinzo.WebApi.Controllers.Companies
{
    [Route("api/v1/industry-types")]
    public class IndustryTypeController : BaseApiController<Industry, IIndustryTypeRepository>
    {
        public IndustryTypeController(
            IIndustryTypeRepository industryTypeRepository,
            IValidator<Industry> validator
        )
            : base(industryTypeRepository, validator) { }
    }
}
