using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Rinzo.Core.Entities.Companies.V1;
using Rinzo.Core.Interfaces.Companies.V1;

namespace Rinzo.WebApi.Controllers.Companies.V1
{
    [Route("api/v1/industry-types")]
    public class IndustryTypeController : BaseApiController<Industry, IIndustryTypeService>
    {
        public IndustryTypeController(
            IIndustryTypeService industryTypeService,
            IValidator<Industry> validator
        )
            : base(industryTypeService, validator) { }
    }
}
