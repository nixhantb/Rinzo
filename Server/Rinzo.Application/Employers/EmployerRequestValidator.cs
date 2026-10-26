using FluentValidation;

namespace Rinzo.Application.Employers;

public sealed class EmployerRequestValidator : AbstractValidator<EmployerRequest>
{
    public EmployerRequestValidator()
    {
        RuleFor(x => x.CompanyId).NotEmpty().WithMessage("A company id is required.");

        RuleFor(x => x.Name).NotNull().WithMessage("Name is required.");
        RuleFor(x => x.Name.FirstName)
            .NotEmpty()
            .WithMessage("First name is required.")
            .When(x => x.Name is not null);
        RuleFor(x => x.Name.LastName)
            .NotEmpty()
            .WithMessage("Last name is required.")
            .When(x => x.Name is not null);
    }
}
