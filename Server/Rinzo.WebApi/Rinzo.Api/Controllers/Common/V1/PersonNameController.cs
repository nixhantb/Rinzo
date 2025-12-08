using FluentValidation;
using JobLeet.WebApi.JobLeet.Api.Models.Common.V1;
using JobLeet.WebApi.JobLeet.Core.Entities.Common.V1;
using JobLeet.WebApi.JobLeet.Core.Interfaces.Common.V1;
using Microsoft.AspNetCore.Mvc;

namespace JobLeet.WebApi.JobLeet.Api.Controllers.Common.V1
{
    [Route("api/v1/person-names")]
    public class PersonNameController
        : BaseApiController<PersonName, PersonNameModel, IPersonNameService>
    {
        public PersonNameController(
            IPersonNameService personNameService,
            IValidator<PersonName> validator
        )
            : base(personNameService, validator) { }
    }
}
