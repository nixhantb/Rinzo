using FluentValidation;
using JobLeet.WebApi.JobLeet.Api.Models.Common.V1;
using JobLeet.WebApi.JobLeet.Core.Entities.Common.V1;
using JobLeet.WebApi.JobLeet.Core.Interfaces.Common.V1;
using Microsoft.AspNetCore.Mvc;

namespace JobLeet.WebApi.JobLeet.Api.Controllers.Common.V1
{
    [Route("api/v1/email-types")]
    public class EmailController : BaseApiController<Email, EmailModel, IEmailService>
    {
        public EmailController(IEmailService emailService, IValidator<Email> validator)
            : base(emailService, validator) { }
    }
}
