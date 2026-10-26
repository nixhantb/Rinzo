using FluentValidation;

namespace Rinzo.Application.Companies;

public sealed class CompanyRequestValidator : AbstractValidator<CompanyRequest>
{
    public CompanyRequestValidator()
    {
        RuleFor(x => x.CompanyName)
            .NotEmpty()
            .WithMessage("Company name is required.")
            .MaximumLength(100)
            .WithMessage("Company name must be 100 characters or less.");

        RuleFor(x => x.Website)
            .MaximumLength(200)
            .WithMessage("Website must be 200 characters or less.");
    }
}
