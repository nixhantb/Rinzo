using FluentValidation;
using JobLeet.WebApi.JobLeet.Core.Entities.Common.V1;

namespace JobLeet.WebApi.JobLeet.Validator
{
    public class EmailValidator : AbstractValidator<Email>
    {
        public EmailValidator()
        {
            RuleFor(x => x.EmailType).IsInEnum().WithMessage("Email Type is required");

            RuleFor(x => x.EmailAddress)
                .NotEmpty()
                .WithMessage("Email Address is required")
                .EmailAddress()
                .WithMessage("Invalid Email Address format")
                .When(x => x.EmailAddress != null);

            RuleFor(x => x.EmailAddress)
                .NotNull()
                .When(x => x.EmailType == EmailCategory.Personal)
                .WithMessage("Personal Email Address cannot be null");
        }
    }
}
