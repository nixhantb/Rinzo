using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Rinzo.Core.Entities.Common;
using Rinzo.Core.Interfaces.Common;

namespace Rinzo.WebApi.Controllers.Common
{
    [Route("api/v1/addresses")]
    public class AddressController : BaseApiController<Address, IAddressRepository>
    {
        public AddressController(
            IAddressRepository addressRepository,
            IValidator<Address> validator
        )
            : base(addressRepository, validator) { }
    }
}
