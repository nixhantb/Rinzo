using FluentValidation;
using JobLeet.WebApi.JobLeet.Core.Entities.Jobs.V1;

namespace JobLeet.WebApi.JobLeet.Core.Validators.Jobs
{
    public class ApplicationDateValidator : AbstractValidator<ApplicationDate>
    {
        public ApplicationDateValidator()
        {
            RuleFor(applicationDate => applicationDate.SubmitDate)
                .NotEmpty()
                .WithMessage("SubmitDate is required.")
                .LessThanOrEqualTo(DateTime.UtcNow)
                .WithMessage("SubmitDate cannot be in the future.");

            RuleFor(applicationDate => applicationDate.ReviewDate)
                .GreaterThanOrEqualTo(applicationDate => applicationDate.SubmitDate)
                .WithMessage("ReviewDate must be on or after the SubmitDate.")
                .LessThanOrEqualTo(DateTime.UtcNow)
                .WithMessage("ReviewDate cannot be in the future.");

            RuleFor(applicationDate => applicationDate.DecisionDate)
                .GreaterThanOrEqualTo(applicationDate => applicationDate.ReviewDate)
                .WithMessage("DecisionDate must be on or after the ReviewDate.")
                .LessThanOrEqualTo(DateTime.UtcNow)
                .WithMessage("DecisionDate cannot be in the future.");

            RuleFor(applicationDate => applicationDate.Comments)
                .MaximumLength(500)
                .WithMessage("Comments cannot exceed 500 characters.");
        }
    }
}
