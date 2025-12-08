using FluentValidation;
using JobLeet.WebApi.JobLeet.Core.Entities.Companies.V1;

namespace JobLeet.WebApi.JobLeet.Validator
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
