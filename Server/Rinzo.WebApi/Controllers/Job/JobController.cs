using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rinzo.Core.Entities.Jobs;
using Rinzo.Core.Interfaces.Jobs;

namespace Rinzo.WebApi.Controllers.Job
{
    // [Authorize]
    [Route("api/jobs")]
    [ApiController]
    public class JobController : BaseApiController<JobEntity, IJobRepository>
    {
        public JobController(IJobRepository jobRepository, IValidator<JobEntity> validator)
            : base(jobRepository, validator) { }
    }
}
