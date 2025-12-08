using FluentValidation;
using JobLeet.WebApi.JobLeet.Core.Entities.Seekers.V1;
using JobLeet.WebApi.JobLeet.Validator;

namespace JobLeet.WebApi.JobLeet.Core.Validators.Seekers
{
    public class SeekerValidator : AbstractValidator<Seeker>
    {
        public SeekerValidator()
        {
            RuleFor(seeker => seeker.PersonName)
                .NotNull()
                .WithMessage("Person Name is required.")
                .When(seeker => seeker.Phone != null)
                .SetValidator(new PersonNameValidator());
            RuleFor(seeker => seeker.Phone)
                .NotNull()
                .WithMessage("Phone information is required.")
                .When(seeker => seeker.Phone != null)
                .SetValidator(new PhoneValidator());

            RuleFor(seeker => seeker.Address)
                .NotNull()
                .WithMessage("Address is required.")
                .When(seeker => seeker.Address != null)
                .SetValidator(new AddressValidator());

            RuleFor(seeker => seeker.Skills)
                .NotNull()
                .WithMessage("Skills information is required.")
                .When(seeker => seeker.Skills != null)
                .SetValidator(new SkillValidator());

            RuleFor(seeker => seeker.Education)
                .NotNull()
                .WithMessage("Education information is required.")
                .ForEach(x => x.SetValidator(new EducationValidator()));

            RuleFor(seeker => seeker.Experience)
                .NotNull()
                .WithMessage("Experience information is required.")
                .ForEach(x => x.SetValidator(new ExperienceValidator()));

            RuleFor(seeker => seeker.DateOfBirth)
                .NotNull()
                .WithMessage("Date of birth is required.")
                .LessThan(DateTime.UtcNow)
                .WithMessage("Date of birth cannot be in the future.")
                .GreaterThan(DateTime.UtcNow.AddYears(-100))
                .WithMessage("Date of birth must be within the last 100 years.");

            RuleFor(seeker => seeker.Qualifications)
                .NotNull()
                .WithMessage("Qualifications are required.")
                .ForEach(x => x.SetValidator(new QualificationValidator()));

            RuleFor(seeker => seeker.ProfileSummary)
                .MaximumLength(500)
                .WithMessage("Profile summary cannot exceed 500 characters.");

            RuleFor(seeker => seeker.Interests)
                .NotEmpty()
                .WithMessage("Interests cannot be empty.")
                .When(seeker => seeker.Interests != null);

            RuleFor(seeker => seeker.Achievements)
                .NotEmpty()
                .WithMessage("Achievements cannot be empty.")
                .When(seeker => seeker.Achievements != null);
        }
    }
}
