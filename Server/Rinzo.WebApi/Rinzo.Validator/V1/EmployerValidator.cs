using FluentValidation;
using JobLeet.WebApi.JobLeet.Core.Entities.Employers.V1;
using JobLeet.WebApi.JobLeet.Validator;

namespace JobLeet.WebApi.JobLeet.Api.Validators
{
    public class EmployerValidator : AbstractValidator<Employer>
    {
        public EmployerValidator()
        {
            RuleFor(e => e.Name)
                .NotNull()
                .WithMessage("Name is required.")
                .SetValidator(new PersonNameValidator());

            RuleFor(e => e.Address)
                .NotNull()
                .WithMessage("Address is required.")
                .SetValidator(new AddressValidator());

            RuleFor(e => e.Phone)
                .NotNull()
                .WithMessage("Phone is required.")
                .SetValidator(new PhoneValidator());

            RuleFor(e => e.Company)
                .NotNull()
                .WithMessage("Company is required.")
                .SetValidator(new CompanyValidator());

            RuleFor(e => e.EmployerType).NotNull().WithMessage("Employer type is required.");

            RuleFor(e => e.IndustryType).NotNull().WithMessage("Industry type is required.");
        }
    }
}
