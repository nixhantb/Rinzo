using FluentValidation;
using JobLeet.WebApi.JobLeet.Api.Models.Common.V1;
using JobLeet.WebApi.JobLeet.Core.Entities.Common.V1;
using JobLeet.WebApi.JobLeet.Core.Interfaces.Common.V1;
using Microsoft.AspNetCore.Mvc;

namespace JobLeet.WebApi.JobLeet.Api.Controllers.Common.V1
{
    [Route("api/v1/experiences")]
    public class ExperienceController
        : BaseApiController<Experience, ExperienceModel, IExperienceService>
    {
        public ExperienceController(
            IExperienceService experienceService,
            IValidator<Experience> validator
        )
            : base(experienceService, validator) { }
    }
}
