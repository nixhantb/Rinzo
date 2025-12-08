using FluentValidation;
using JobLeet.WebApi.JobLeet.Core.Entities.Common.V1;

namespace JobLeet.WebApi.JobLeet.Validator
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(address => address.Street)
                .MaximumLength(100)
                .WithMessage("Street cannot exceed 100 characters.")
                .When(address => !string.IsNullOrWhiteSpace(address.Street));

            RuleFor(address => address.City)
                .MaximumLength(50)
                .WithMessage("City cannot exceed 50 characters.")
                .When(address => !string.IsNullOrWhiteSpace(address.City));

            RuleFor(address => address.State)
                .MaximumLength(50)
                .WithMessage("State cannot exceed 50 characters.")
                .When(address => !string.IsNullOrWhiteSpace(address.State));

            RuleFor(address => address.PostalCode)
                .Matches(@"^\d{5}(-\d{4})?$")
                .WithMessage("Invalid Postal Code format")
                .When(address => !string.IsNullOrWhiteSpace(address.PostalCode));

            RuleFor(address => address.Country)
                .NotEmpty()
                .WithMessage("Country is required")
                .MaximumLength(50)
                .WithMessage("Country cannot exceed 50 characters.");
        }
    }
}
