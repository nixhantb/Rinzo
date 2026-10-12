using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Rinzo.Core.Entities.Common.V1;
using Rinzo.Core.Interfaces.Common.V1;

namespace Rinzo.WebApi.Controllers.Common.V1
{
    [Route("api/v1/phones")]
    public class PhoneController : BaseApiController<Phone, IPhoneService>
    {
        public PhoneController(IPhoneService phoneService, IValidator<Phone> validator)
            : base(phoneService, validator) { }
    }
}
