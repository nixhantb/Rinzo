using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Rinzo.Core.Entities.Common;
using Rinzo.Core.Interfaces.Common;

namespace Rinzo.WebApi.Controllers.Common
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
