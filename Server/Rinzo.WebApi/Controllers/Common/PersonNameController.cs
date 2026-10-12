using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Rinzo.Core.Entities.Common;
using Rinzo.Core.Interfaces.Common;

namespace Rinzo.WebApi.Controllers.Common
{
    [Route("api/v1/person-names")]
    public class PersonNameController : BaseApiController<PersonName, IPersonNameRepository>
    {
        public PersonNameController(
            IPersonNameRepository personNameRepository,
            IValidator<PersonName> validator
        )
            : base(personNameRepository, validator) { }
    }
}
