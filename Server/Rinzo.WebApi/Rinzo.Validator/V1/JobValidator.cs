using System;
using FluentValidation;
using JobLeet.WebApi.JobLeet.Core.Entities.Jobs.V1;

namespace JobLeet.WebApi.JobLeet.Validator
{
    public class JobEntityValidator : AbstractValidator<JobEntity>
    {
        public JobEntityValidator()
        {
            RuleFor(job => job.JobTitle)
                .NotEmpty()
                .WithMessage("Job title is required.")
                .MaximumLength(100)
                .WithMessage("Job title must not exceed 100 characters.");

            RuleFor(job => job.JobDescription)
                .NotEmpty()
                .WithMessage("Job description is required.")
                .MaximumLength(1000)
                .WithMessage("Job description must not exceed 1000 characters.");

            RuleFor(job => job.JobType)
                .NotEmpty()
                .WithMessage("Job type is required.")
                .WithMessage(
                    "Job type must be one of the following: FullTime, PartTime, Contract, Remote, Temporary."
                );

            RuleFor(job => job.JobAddress).NotNull().WithMessage("Job address is required.");

            RuleFor(job => job.Vacancies)
                .NotNull()
                .WithMessage("Number of vacancies is required.")
                .GreaterThanOrEqualTo(1)
                .WithMessage("Vacancies must be at least 1.");

            RuleFor(job => job.BasicPay).NotNull().WithMessage("Basic pay is required.");

            RuleFor(job => job.RequiredExperience)
                .NotNull()
                .WithMessage("Required experience is mandatory.");

            RuleFor(job => job.PostingDate)
                .NotNull()
                .WithMessage("Posting date is required.")
                .LessThanOrEqualTo(DateTime.UtcNow)
                .WithMessage("Posting date cannot be in the future.");

            RuleFor(job => job.ApplicationDeadline)
                .NotNull()
                .WithMessage("Application deadline is required.")
                .GreaterThan(job => job.PostingDate.GetValueOrDefault())
                .WithMessage("Application deadline must be after the posting date.");

            RuleFor(job => job.FunctionalArea)
                .NotEmpty()
                .WithMessage("Functional area is required.");

            RuleForEach(job => job.Tags)
                .MaximumLength(50)
                .WithMessage("Each tag must not exceed 50 characters.");

            RuleFor(job => job.JobResponsibilities)
                .NotEmpty()
                .WithMessage("Job responsibilities must be provided.")
                .When(job => job.JobResponsibilities != null);

            RuleFor(job => job.Benefits)
                .NotEmpty()
                .WithMessage("Benefits list cannot be empty.")
                .When(job => job.Benefits != null);

            RuleFor(job => job.PreferredQualifications)
                .NotEmpty()
                .WithMessage("Preferred qualifications cannot be empty.")
                .When(job => job.PreferredQualifications != null);
        }
    }
}
