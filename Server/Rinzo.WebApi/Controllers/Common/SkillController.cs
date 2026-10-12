using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Rinzo.Core.Entities.Common;
using Rinzo.Core.Interfaces.Common;

namespace Rinzo.WebApi.Controllers.Common
{
    [Route("api/skills")]
    public class SkillController : BaseApiController<Skill, ISkillRepository>
    {
        public SkillController(ISkillRepository skillRepository, IValidator<Skill> validator)
            : base(skillRepository, validator) { }
    }
}
