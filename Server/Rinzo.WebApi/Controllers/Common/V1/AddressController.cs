using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Rinzo.Core.Entities.Common.V1;
using Rinzo.Core.Interfaces.Common.V1;

namespace Rinzo.WebApi.Controllers.Common.V1
{
    [Route("api/v1/addresses")]
    public class AddressController : BaseApiController<Address, IAddressService>
    {
        public AddressController(IAddressService addressRepository, IValidator<Address> validator)
            : base(addressRepository, validator) { }
    }
}
