using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Rinzo.Core.Entities.Jobs;
using Rinzo.Core.Interfaces.Jobs;

namespace Rinzo.WebApi.Controllers.Job
{
    [Route("api/applications")]
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
