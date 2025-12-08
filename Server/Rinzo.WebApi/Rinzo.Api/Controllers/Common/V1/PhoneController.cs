using FluentValidation;
using JobLeet.WebApi.JobLeet.Api.Models.Common.V1;
using JobLeet.WebApi.JobLeet.Core.Entities.Common.V1;
using JobLeet.WebApi.JobLeet.Core.Interfaces.Common.V1;
using Microsoft.AspNetCore.Mvc;

namespace JobLeet.WebApi.JobLeet.Api.Controllers.Common.V1
{
    [Route("api/v1/phones")]
    public class PhoneController : BaseApiController<Phone, PhoneModel, IPhoneService>
    {
        public PhoneController(IPhoneService phoneService, IValidator<Phone> validator)
            : base(phoneService, validator) { }
    }
}
