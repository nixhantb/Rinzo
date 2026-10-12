using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Rinzo.Core.Entities.Common.V1;
using Rinzo.Core.Interfaces.Common.V1;

namespace Rinzo.WebApi.Controllers.Common.V1
{
    [Route("api/v1/skills")]
    public class SkillController : BaseApiController<Skill, ISkillService>
    {
        public SkillController(ISkillService skillService, IValidator<Skill> validator)
            : base(skillService, validator) { }
    }
}
