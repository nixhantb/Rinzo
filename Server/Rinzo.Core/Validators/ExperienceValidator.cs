using FluentValidation;
using Rinzo.Core.Entities.Common;

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
