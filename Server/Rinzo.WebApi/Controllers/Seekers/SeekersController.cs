using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rinzo.Core.Entities.Seekers;
using Rinzo.Core.Interfaces.Seekers;

namespace Rinzo.WebApi.Controllers.Seekers
{
    [Authorize]
    [Route("api/v1/seekers")]
    public class SeekersController : BaseApiController<Seeker, ISeekerRepository>
    {
        public SeekersController(ISeekerRepository seekerRepository, IValidator<Seeker> validator)
            : base(seekerRepository, validator) { }
    }
}
