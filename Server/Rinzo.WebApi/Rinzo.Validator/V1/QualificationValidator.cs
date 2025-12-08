using FluentValidation;
using JobLeet.WebApi.JobLeet.Core.Entities.Common.V1;

namespace JobLeet.WebApi.JobLeet.Validator
{
    public class QualificationValidator : AbstractValidator<Qualification>
    {
        public QualificationValidator()
        {
            RuleFor(x => x.QualificationType).IsInEnum().WithMessage("Invalid Qualification Type");

            RuleFor(x => x.QualificationInformation)
                .NotNull()
                .WithMessage("Qualification Information cannot be null")
                .NotEmpty()
                .WithMessage("Qualification Information cannot be empty")
                .When(x => x.QualificationInformation != null);
        }
    }
}
