using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rinzo.Core.Entities.Employers.V1;
using Rinzo.Core.Interfaces.Employers.V1;

namespace Rinzo.WebApi.Controllers.Job.V1
{
    [Authorize]
    [Route("api/v1/employers")]
    public class EmployerController : BaseApiController<Employer, IEmployerService>
    {
        public EmployerController(IEmployerService employerService, IValidator<Employer> validator)
            : base(employerService, validator) { }
    }
}
