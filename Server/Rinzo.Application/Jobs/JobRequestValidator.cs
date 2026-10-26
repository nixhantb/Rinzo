using FluentValidation;

namespace Rinzo.Application.Jobs;

public sealed class JobRequestValidator : AbstractValidator<JobRequest>
{
    public JobRequestValidator()
    {
        RuleFor(x => x.CompanyId).NotEmpty().WithMessage("A company id is required.");

        RuleFor(x => x.JobTitle)
            .NotEmpty()
            .WithMessage("Job title is required.")
            .MaximumLength(150)
            .WithMessage("Job title must be 150 characters or less.");

        RuleFor(x => x.JobDescription).NotEmpty().WithMessage("Job description is required.");

        RuleFor(x => x.JobType).NotEmpty().WithMessage("Job type is required.");

        RuleFor(x => x.Vacancies)
            .GreaterThanOrEqualTo(1)
            .WithMessage("A job needs at least one vacancy.");
    }
}
