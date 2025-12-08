using FluentValidation;
using JobLeet.WebApi.JobLeet.Core.Entities.Common.V1;

namespace JobLeet.WebApi.JobLeet.Validator
{
    public class PersonNameValidator : AbstractValidator<PersonName>
    {
        public PersonNameValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("First Name is required")
                .MaximumLength(100)
                .WithMessage("First Name cannot be longer than 100 characters");

            RuleFor(x => x.MiddleName)
                .MaximumLength(100)
                .WithMessage("Middle Name cannot be longer than 100 characters")
                .When(x => !string.IsNullOrEmpty(x.MiddleName));

            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("Last Name is required")
                .MaximumLength(100)
                .WithMessage("Last Name cannot be longer than 100 characters");
        }
    }
}
