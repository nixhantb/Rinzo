using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Rinzo.Core.Entities.Common;
using Rinzo.Core.Interfaces.Common;

namespace Rinzo.WebApi.Controllers.Common
{
    [Route("api/v1/email-types")]
    public class EmailController : BaseApiController<Email, IEmaiTypeRepository>
    {
        public EmailController(IEmaiTypeRepository emailRepository, IValidator<Email> validator)
            : base(emailRepository, validator) { }
    }
}
