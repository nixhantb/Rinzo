using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Rinzo.Core.Entities.Common.V1;
using Rinzo.Core.Interfaces.Common.V1;

namespace Rinzo.WebApi.Controllers.Common.V1
{
    [Route("api/v1/email-types")]
    public class EmailController : BaseApiController<Email, IEmaiTypeRepository>
    {
        public EmailController(IEmaiTypeRepository emailRepository, IValidator<Email> validator)
            : base(emailRepository, validator) { }
    }
}
