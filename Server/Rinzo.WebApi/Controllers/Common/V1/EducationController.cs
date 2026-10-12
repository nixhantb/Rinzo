using FluentValidation;
using Rinzo.Core.Models.Common.V1;
using Rinzo.Core.Entities.Common.V1;
using Rinzo.Core.Interfaces.Common.V1;
using Microsoft.AspNetCore.Mvc;

namespace Rinzo.WebApi.Controllers.Common.V1
{
    [Route("api/v1/educations")]
    public class EducationController
        : BaseApiController<Education, EducationModel, IEducationService>
    {
        public EducationController(
            IEducationService educationService,
            IValidator<Education> validator
        )
            : base(educationService, validator) { }
    }
}
