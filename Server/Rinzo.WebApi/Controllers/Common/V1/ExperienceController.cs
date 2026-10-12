using FluentValidation;
using Rinzo.Core.Entities.Common.V1;
using Rinzo.Core.Interfaces.Common.V1;
using Microsoft.AspNetCore.Mvc;

namespace Rinzo.WebApi.Controllers.Common.V1
{
    [Route("api/v1/experiences")]
    public class ExperienceController : BaseApiController<Experience, IExperienceService>
    {
        public ExperienceController(
            IExperienceService experienceService,
            IValidator<Experience> validator
        )
            : base(experienceService, validator) { }
    }
}
