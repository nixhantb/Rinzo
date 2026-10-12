using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Rinzo.Core.Entities.Common.V1;
using Rinzo.Core.Interfaces.Common.V1;

namespace Rinzo.WebApi.Controllers.Common.V1
{
    [Route("api/v1/phones")]
    public class PhoneController : BaseApiController<Phone, IPhoneRepository>
    {
        public PhoneController(IPhoneRepository phoneRepository, IValidator<Phone> validator)
            : base(phoneRepository, validator) { }
    }
}
