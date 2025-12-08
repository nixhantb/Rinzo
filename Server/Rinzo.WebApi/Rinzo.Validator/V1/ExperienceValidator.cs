using FluentValidation;
using JobLeet.WebApi.JobLeet.Core.Entities.Common.V1;

namespace JobLeet.WebApi.JobLeet.Validator
{
    public class ExperienceValidator : AbstractValidator<Experience>
    {
        public ExperienceValidator()
        {
            RuleFor(x => x.ExperienceLevel).IsInEnum().WithMessage("Invalid Experience Level");
        }
    }
}
