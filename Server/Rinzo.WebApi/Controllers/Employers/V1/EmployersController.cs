using FluentValidation;
using Rinzo.Core.Models.Employers.V1;
using Rinzo.Core.Entities.Employers.V1;
using Rinzo.Core.Interfaces.Employers.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Rinzo.WebApi.Controllers.Job.V1
{
    [Authorize]
    [Route("api/v1/employers")]
    public class EmployerController : BaseApiController<Employer, EmployerModel, IEmployerService>
    {
        public EmployerController(IEmployerService employerService, IValidator<Employer> validator)
            : base(employerService, validator) { }
        // [HttpPost]
        // public override async Task<IActionResult> CreateAsync([FromBody] Employer entity)
        // {
        //     try
        //     {
        //         if (entity == null)
        //         {
        //             return BadRequest();
        //         }

        //         var result = await Repository.AddAsync(entity);


        //         return Ok(result);
        //     }
        //     catch (Exception ex)
        //     {
        //         _logger.LogError($"Error occurred while creating the entity: {ex.Message}");
        //         var errorResponse = new GlobalErrorResponse
        //         {
        //             Error = "System Exception",
        //             Message = ex.Message
        //         };
        //         return StatusCode(400, errorResponse);
        //     }
        // }
    }
}
