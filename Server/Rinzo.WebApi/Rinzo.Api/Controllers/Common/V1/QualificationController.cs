using FluentValidation;
using JobLeet.WebApi.JobLeet.Api.Models.Common.V1;
using JobLeet.WebApi.JobLeet.Core.Entities.Common.V1;
using JobLeet.WebApi.JobLeet.Core.Interfaces.Common.V1;
using Microsoft.AspNetCore.Mvc;

namespace JobLeet.WebApi.JobLeet.Api.Controllers.Common.V1
{
    [Route("api/v1/qualification-types")]
    public class QualificationController
        : BaseApiController<Qualification, QualificationModel, IQualificationService>
    {
        public QualificationController(
            IQualificationService qualificationService,
            IValidator<Qualification> validator
        )
            : base(qualificationService, validator) { }
    }
}
