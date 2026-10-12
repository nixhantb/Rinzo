using FluentValidation;
using Rinzo.Core.Entities.Common.V1;
using Rinzo.Core.Interfaces.Common.V1;
using Microsoft.AspNetCore.Mvc;

namespace Rinzo.WebApi.Controllers.Common.V1
{
    [Route("api/v1/person-names")]
    public class PersonNameController : BaseApiController<PersonName, IPersonNameService>
    {
        public PersonNameController(
            IPersonNameService personNameService,
            IValidator<PersonName> validator
        )
            : base(personNameService, validator) { }
    }
}
