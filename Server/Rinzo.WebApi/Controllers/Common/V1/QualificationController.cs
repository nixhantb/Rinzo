using FluentValidation;
using Rinzo.Core.Entities.Common.V1;
using Rinzo.Core.Interfaces.Common.V1;
using Microsoft.AspNetCore.Mvc;

namespace Rinzo.WebApi.Controllers.Common.V1
{
    [Route("api/v1/qualification-types")]
    public class QualificationController : BaseApiController<Qualification, IQualificationService>
    {
        public QualificationController(
            IQualificationService qualificationService,
            IValidator<Qualification> validator
        )
            : base(qualificationService, validator) { }
    }
}
