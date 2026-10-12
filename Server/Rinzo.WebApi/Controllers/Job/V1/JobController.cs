using FluentValidation;
using Rinzo.Core.Models.Jobs.V1;
using Rinzo.Core.Entities.Jobs.V1;
using Rinzo.Core.Interfaces.Jobs.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Rinzo.WebApi.Controllers.Job.V1
{
    // [Authorize]
    [Route("api/v1/jobs")]
    [ApiController]
    public class JobController : BaseApiController<JobEntity, JobModel, IJobService>
    {
        public JobController(IJobService jobService, IValidator<JobEntity> validator)
            : base(jobService, validator) { }
    }
}
