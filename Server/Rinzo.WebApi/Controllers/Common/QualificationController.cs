using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Rinzo.Core.Entities.Common;
using Rinzo.Core.Interfaces.Common;

namespace Rinzo.WebApi.Controllers.Common
{
    [Route("api/v1/qualification-types")]
    public class QualificationController
        : BaseApiController<Qualification, IQualificationTypeRepository>
    {
        public QualificationController(
            IQualificationTypeRepository qualificationRepository,
            IValidator<Qualification> validator
        )
            : base(qualificationRepository, validator) { }
    }
}
