using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Rinzo.Core.Entities.Common.V1;
using Rinzo.Core.Interfaces.Common.V1;

namespace Rinzo.WebApi.Controllers.Common.V1
{
    [Route("api/v1/educations")]
    public class EducationController : BaseApiController<Education, IEducationRepository>
    {
        public EducationController(
            IEducationRepository educationRepository,
            IValidator<Education> validator
        )
            : base(educationRepository, validator) { }
    }
}
