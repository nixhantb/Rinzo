using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Rinzo.Core.Entities.Common.V1;
using Rinzo.Core.Interfaces.Common.V1;

namespace Rinzo.WebApi.Controllers.Common.V1
{
    [Route("api/v1/experiences")]
    public class ExperienceController : BaseApiController<Experience, IExperienceRepository>
    {
        public ExperienceController(
            IExperienceRepository experienceRepository,
            IValidator<Experience> validator
        )
            : base(experienceRepository, validator) { }
    }
}
