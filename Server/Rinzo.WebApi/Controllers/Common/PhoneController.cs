using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Rinzo.Core.Entities.Common;
using Rinzo.Core.Interfaces.Common;

namespace Rinzo.WebApi.Controllers.Common
{
    [Route("api/v1/phones")]
    public class PhoneController : BaseApiController<Phone, IPhoneRepository>
    {
        public PhoneController(IPhoneRepository phoneRepository, IValidator<Phone> validator)
            : base(phoneRepository, validator) { }
    }
}
