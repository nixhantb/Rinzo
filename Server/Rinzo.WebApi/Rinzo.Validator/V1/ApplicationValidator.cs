using FluentValidation;
using JobLeet.WebApi.JobLeet.Core.Entities.Jobs.V1;
using JobLeet.WebApi.JobLeet.Core.Validators.Seekers;
using JobLeet.WebApi.JobLeet.Validator;

namespace JobLeet.WebApi.JobLeet.Core.Validators.Jobs
{
    public class ApplicationValidator : AbstractValidator<Application>
    {
        public ApplicationValidator()
        {
            RuleFor(application => application.Seekers)
                .NotNull()
                .WithMessage("Seeker information is required.")
                .When(application => application.Seekers != null)
                .SetValidator(new SeekerValidator());

            RuleFor(application => application.Company)
                .NotNull()
                .WithMessage("Company information is required.")
                .When(application => application.Company != null)
                .SetValidator(new CompanyValidator());

            RuleFor(application => application.Jobs)
                .NotNull()
                .WithMessage("Job information is required.")
                .When(application => application.Jobs != null)
                .SetValidator(new JobEntityValidator());

            RuleFor(application => application.ApplicationDate)
                .NotNull()
                .WithMessage("ApplicationDate is required.")
                .SetValidator(new ApplicationDateValidator());

            RuleFor(application => application.Status).NotNull().WithMessage("Status is required.");
        }
    }
}
