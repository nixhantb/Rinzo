using FluentValidation;

namespace Rinzo.Application.Applications;

public sealed class ApplicationRequestValidator : AbstractValidator<JobApplicationRequest>
{
    public ApplicationRequestValidator()
    {
        RuleFor(x => x.SeekerId).NotEmpty().WithMessage("A seeker id is required.");
        RuleFor(x => x.CompanyId).NotEmpty().WithMessage("A company id is required.");
        RuleFor(x => x.JobId).NotEmpty().WithMessage("A job id is required.");
    }
}

public sealed class ApplicationStatusRequestValidator
    : AbstractValidator<JobApplicationStatusRequest>
{
    public ApplicationStatusRequestValidator()
    {
        RuleFor(x => x.Status).IsInEnum();
    }
}
