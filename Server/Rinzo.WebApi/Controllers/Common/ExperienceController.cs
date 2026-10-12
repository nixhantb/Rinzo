using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Rinzo.Core.Entities.Common;
using Rinzo.Core.Interfaces.Common;

namespace Rinzo.WebApi.Controllers.Common
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
