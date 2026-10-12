using FluentValidation;
using Rinzo.Core.Entities.Common;

namespace Rinzo.Core.Validators
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
