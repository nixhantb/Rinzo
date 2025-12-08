using FluentValidation;
using JobLeet.WebApi.JobLeet.Core.Entities.Common.V1;

namespace JobLeet.WebApi.JobLeet.Validator
{
    public class EducationValidator : AbstractValidator<Education>
    {
        public EducationValidator()
        {
            RuleFor(x => x.Degree).NotEmpty().WithMessage("Degree is required");

            RuleFor(x => x.Major).NotEmpty().WithMessage("Major is required");

            RuleFor(x => x.Institution).NotEmpty().WithMessage("Institution is required");

            RuleFor(x => x.GraduationDate)
                .NotEmpty()
                .WithMessage("Graduation Date is required")
                .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.Now))
                .WithMessage("Graduation Date cannot be in the future");

            RuleFor(x => x.Cgpa)
                .InclusiveBetween(0, 4.0m)
                .WithMessage("CGPA must be between 0.0 and 4.0");
        }
    }
}
