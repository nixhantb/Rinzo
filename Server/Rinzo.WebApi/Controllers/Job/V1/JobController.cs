using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rinzo.Core.Entities.Jobs.V1;
using Rinzo.Core.Interfaces.Jobs.V1;

namespace Rinzo.WebApi.Controllers.Job.V1
{
    // [Authorize]
    [Route("api/v1/jobs")]
    [ApiController]
    public class JobController : BaseApiController<JobEntity, IJobService>
    {
        public JobController(IJobService jobService, IValidator<JobEntity> validator)
            : base(jobService, validator) { }
    }
}
