using FluentValidation;
using Rinzo.Core.Entities.Companies;

namespace Rinzo.Core.Validators
{
    public class CompanyValidator : AbstractValidator<Company>
    {
        public CompanyValidator()
        {
            RuleFor(x => x.CompanyName)
                .NotEmpty()
                .WithMessage("Company Name is required.")
                .MaximumLength(100)
                .WithMessage("Company Name must not exceed 100 characters.");

            RuleFor(x => x.Profile)
                .NotNull()
                .WithMessage("Company Profile is required.")
                .SetValidator(new CompanyProfileValidator());
        }
    }
}
