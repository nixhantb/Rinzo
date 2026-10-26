using FluentValidation;

namespace Rinzo.Application.Seekers;

public sealed class SeekerRequestValidator : AbstractValidator<SeekerRequest>
{
    public SeekerRequestValidator()
    {
        RuleFor(x => x.PersonName).NotNull().WithMessage("Name is required.");
        RuleFor(x => x.PersonName.FirstName)
            .NotEmpty()
            .WithMessage("First name is required.")
            .When(x => x.PersonName is not null);
        RuleFor(x => x.PersonName.LastName)
            .NotEmpty()
            .WithMessage("Last name is required.")
            .When(x => x.PersonName is not null);
    }
}
