using FluentValidation;
using Rinzo.Core.Models.Jobs.V1;
using Rinzo.Core.Entities.Jobs.V1;
using Rinzo.Core.Interfaces.Jobs.V1;
using Microsoft.AspNetCore.Mvc;

namespace Rinzo.WebApi.Controllers.Job.V1
{
    [Route("api/v1/applications")]
    [ApiController]
    public class ApplicationController
        : BaseApiController<Application, ApplicationModel, IApplicationService>
    {
        public ApplicationController(
            IApplicationService applicationService,
            IValidator<Application> validator
        )
            : base(applicationService, validator) { }

        [HttpGet("seekers/{seekerId}")]
        public async Task<IActionResult> GetBySeekersIdAsync([FromRoute] string seekerId)
        {
            try
            {
                var applicationBySeekersId = await _service.GetApplicationBySeekersId(seekerId);

                return Ok(applicationBySeekersId);
            }
            catch (Exception ex)
            {
                return StatusCode(
                    500,
                    new { Error = "Internal Server Error", Message = ex.Message }
                );
            }
        }

        [HttpPost("apply")]
        public async Task<IActionResult> ApplyForJobAsync(
            [FromQuery] string seekerId,
            [FromQuery] string jobId,
            [FromQuery] string companyId
        )
        {
            try
            {
                var application = await _service.ApplyForJobAsync(seekerId, jobId, companyId);

                return Ok(application);
            }
            catch (Exception ex)
            {
                return StatusCode(
                    500,
                    new { Error = "Internal Server Error", Message = ex.Message }
                );
            }
        }
    }
}
