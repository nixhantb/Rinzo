using FluentValidation;
using JobLeet.WebApi.JobLeet.Api.Models.Jobs.V1;
using JobLeet.WebApi.JobLeet.Core.Entities.Jobs.V1;
using JobLeet.WebApi.JobLeet.Core.Interfaces.Jobs.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobLeet.WebApi.JobLeet.Api.Controllers.Job.V1
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
