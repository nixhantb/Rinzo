using FluentValidation;
using Rinzo.Core.Entities.Common.V1;

namespace Rinzo.Core.Validators
{
    public class ExperienceValidator : AbstractValidator<Experience>
    {
        public ExperienceValidator()
        {
            RuleFor(x => x.ExperienceLevel).IsInEnum().WithMessage("Invalid Experience Level");
        }
    }
}
