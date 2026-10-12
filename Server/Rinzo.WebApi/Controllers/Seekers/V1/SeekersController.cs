using FluentValidation;
using Rinzo.Core.Models.Seekers.V1;
using Rinzo.Core.Entities.Seekers.V1;
using Rinzo.Core.Interfaces.Seekers.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Rinzo.WebApi.Controllers.Job.V1
{
    [Authorize]
    [Route("api/v1/seekers")]
    public class SeekersController : BaseApiController<Seeker, SeekerModel, ISeekerService>
    {
        public SeekersController(ISeekerService seekerService, IValidator<Seeker> validator)
            : base(seekerService, validator) { }
    }
}
