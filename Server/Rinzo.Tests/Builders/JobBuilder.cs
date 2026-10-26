using Rinzo.Domain.Jobs;

namespace Rinzo.Tests.Builders;

public sealed class JobBuilder
{
    private Guid _companyId = Guid.CreateVersion7();
    private string _jobTitle = "Software Engineer";
    private int _vacancies = 1;

    public JobBuilder WithCompanyId(Guid companyId)
    {
        _companyId = companyId;
        return this;
    }

    public JobBuilder WithTitle(string jobTitle)
    {
        _jobTitle = jobTitle;
        return this;
    }

    public JobBuilder WithVacancies(int vacancies)
    {
        _vacancies = vacancies;
        return this;
    }

    public Job Build() =>
        Job.Create(
            _companyId,
            _jobTitle,
            "Build and ship features.",
            "Full-time",
            null,
            _vacancies,
            null,
            null,
            [],
            [],
            null,
            [],
            [],
            [],
            [],
            null,
            null
        );
}
