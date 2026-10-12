using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Rinzo.Core.Entities.Jobs.V1;
using Rinzo.Core.Interfaces.Jobs.V1;

namespace Rinzo.WebApi.Controllers.Job.V1
{
    [Route("api/v1/applications")]
    [ApiController]
    public class ApplicationController : BaseApiController<Application, IApplicationRepository>
    {
        public ApplicationController(
            IApplicationRepository applicationRepository,
            IValidator<Application> validator
        )
            : base(applicationRepository, validator) { }

        [HttpGet("seekers/{seekerId}")]
        public async Task<IActionResult> GetBySeekersIdAsync([FromRoute] string seekerId)
        {
            var applicationBySeekersId = await _repository.GetApplicationBySeekersId(seekerId);
            return Ok(applicationBySeekersId);
        }

        [HttpPost("apply")]
        public async Task<IActionResult> ApplyForJobAsync(
            [FromQuery] string seekerId,
            [FromQuery] string jobId,
            [FromQuery] string companyId
        )
        {
            var application = await _repository.ApplyForJobAsync(seekerId, jobId, companyId);
            return Ok(application);
        }
    }
}
