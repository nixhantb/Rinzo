using FluentValidation;
using Rinzo.Core.Entities.Common.V1;
using Rinzo.Core.Interfaces.Common.V1;
using Microsoft.AspNetCore.Mvc;

namespace Rinzo.WebApi.Controllers.Common.V1
{
    [Route("api/v1/email-types")]
    public class EmailController : BaseApiController<Email, IEmailService>
    {
        public EmailController(IEmailService emailService, IValidator<Email> validator)
            : base(emailService, validator) { }
    }
}
