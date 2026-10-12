using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rinzo.Core.Entities.Employers;
using Rinzo.Core.Interfaces.Employers;

namespace Rinzo.WebApi.Controllers.Employers
{
    [Authorize]
    [Route("api/v1/employers")]
    public class EmployerController : BaseApiController<Employer, IEmployerRepository>
    {
        public EmployerController(
            IEmployerRepository employerRepository,
            IValidator<Employer> validator
        )
            : base(employerRepository, validator) { }
    }
}
