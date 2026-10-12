using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rinzo.Core.Entities.Seekers.V1;
using Rinzo.Core.Interfaces.Seekers.V1;

namespace Rinzo.WebApi.Controllers.Job.V1
{
    [Authorize]
    [Route("api/v1/seekers")]
    public class SeekersController : BaseApiController<Seeker, ISeekerRepository>
    {
        public SeekersController(ISeekerRepository seekerRepository, IValidator<Seeker> validator)
            : base(seekerRepository, validator) { }
    }
}
