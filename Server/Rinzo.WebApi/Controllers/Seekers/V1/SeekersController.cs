using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rinzo.Core.Entities.Seekers.V1;
using Rinzo.Core.Interfaces.Seekers.V1;

namespace Rinzo.WebApi.Controllers.Job.V1
{
    [Authorize]
    [Route("api/v1/seekers")]
    public class SeekersController : BaseApiController<Seeker, ISeekerService>
    {
        public SeekersController(ISeekerService seekerService, IValidator<Seeker> validator)
            : base(seekerService, validator) { }
    }
}
