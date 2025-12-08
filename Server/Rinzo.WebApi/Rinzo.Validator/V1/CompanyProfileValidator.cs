using FluentValidation;
using JobLeet.WebApi.JobLeet.Core.Entities.Companies.V1;

namespace JobLeet.WebApi.JobLeet.Validator
{
    public class CompanyProfileValidator : AbstractValidator<CompanyProfile>
    {
        public CompanyProfileValidator()
        {
            // RuleFor(x => x.ProfileInfo)
            //     .NotEmpty().WithMessage("Profile Info is required.")
            //     .MaximumLength(500).WithMessage("Profile Info must not exceed 500 characters.");

            // RuleFor(x => x.CompanyAddress)
            //     .NotNull().WithMessage("Company Address is required.")
            //     .SetValidator(new AddressValidator());

            // RuleFor(x => x.ContactPhone)
            //     .NotNull().WithMessage("Contact Phone is required.")
            //     .SetValidator(new PhoneValidator());

            // RuleFor(x => x.ContactEmail)
            //     .NotNull().WithMessage("Contact Email is required.")
            //     .SetValidator(new EmailValidator());

            // RuleFor(x => x.Website)
            //     .Matches(@"^https?:\/\/[^\s/$.?#].[^\s]*$").WithMessage("Invalid website URL format.")
            //     .When(x => x.Website != null);

            // RuleFor(x => x.IndustryTypes)
            //     .IsInEnum().WithMessage("Invalid Industry Type.");
        }
    }
}
