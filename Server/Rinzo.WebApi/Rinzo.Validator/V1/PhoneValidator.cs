using FluentValidation;
using JobLeet.WebApi.JobLeet.Core.Entities.Common.V1;

namespace JobLeet.WebApi.JobLeet.Validator
{
    public class PhoneValidator : AbstractValidator<Phone>
    {
        public PhoneValidator()
        {
            RuleFor(x => x.CountryCode)
                .GreaterThan(0)
                .WithMessage("Country Code must be a positive number");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .WithMessage("Phone Number is required")
                .Matches(@"^[0-9]+$")
                .WithMessage("Invalid Phone Number format. Use only digits.")
                .When(x => !string.IsNullOrEmpty(x.PhoneNumber));
        }
    }
}
