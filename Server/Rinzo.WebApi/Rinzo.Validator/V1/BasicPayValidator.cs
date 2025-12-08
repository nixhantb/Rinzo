using FluentValidation;
using JobLeet.WebApi.JobLeet.Core.Entities.Common.V1;

namespace JobLeet.WebApi.JobLeet.Validator
{
    public class BasicPayValidator : AbstractValidator<BasicPay>
    {
        public BasicPayValidator()
        {
            RuleFor(basicPay => basicPay.MinmumPay)
                .NotNull()
                .WithMessage("Minimum Pay is required.")
                .GreaterThanOrEqualTo(0)
                .WithMessage("Minimum Pay cannot be negative.");

            RuleFor(basicPay => basicPay.MaximumPay)
                .NotNull()
                .WithMessage("Maximum Pay is required.")
                .GreaterThanOrEqualTo(basicPay => basicPay.MinmumPay ?? 0)
                .WithMessage("Maximum Pay must be greater than or equal to Minimum Pay.");

            RuleFor(basicPay => basicPay.Currency)
                .NotEmpty()
                .WithMessage("Currency is required.")
                .Must(currency => currency?.Length == 3)
                .WithMessage("Currency must be a valid 3-character ISO code.")
                .When(basicPay => !string.IsNullOrWhiteSpace(basicPay.Currency));
        }
    }
}
