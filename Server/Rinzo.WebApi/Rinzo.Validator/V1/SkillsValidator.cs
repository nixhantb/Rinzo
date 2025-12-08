using FluentValidation;
using JobLeet.WebApi.JobLeet.Core.Entities.Common.V1;

namespace JobLeet.WebApi.JobLeet.Validator
{
    public class SkillValidator : AbstractValidator<Skill>
    {
        public SkillValidator()
        {
            RuleFor(x => x.Title)
                .NotNull()
                .WithMessage("Title cannot be null")
                .NotEmpty()
                .WithMessage("Title cannot be empty")
                .Must(title => title.Count > 0)
                .WithMessage("Title must contain at least one item");

            RuleFor(x => x.Description)
                .NotNull()
                .WithMessage("Description cannot be null")
                .NotEmpty()
                .WithMessage("Description cannot be empty")
                .Must(description => description.Count > 0)
                .WithMessage("Description must contain at least one item");
        }
    }
}
