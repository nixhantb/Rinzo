using FluentValidation;
using JobLeet.WebApi.JobLeet.Core.Entities.Companies.V1;

namespace JobLeet.WebApi.JobLeet.Validator
{
    public class IndustryTypeValidator : AbstractValidator<IndustryType>
    {
        public IndustryTypeValidator()
        {
            RuleFor(industry => industry.IndustryCategory)
                .IsInEnum()
                .WithMessage("IndustryCategory must be a valid enum value of IndustryCategory.")
                .NotEqual(IndustryCategory.Others)
                .WithMessage("IndustryCategory cannot be 'Others' for certain use cases.");
        }
    }
}
