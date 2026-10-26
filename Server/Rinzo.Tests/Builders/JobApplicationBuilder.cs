using Rinzo.Domain.Applications;

namespace Rinzo.Tests.Builders;

public sealed class JobApplicationBuilder
{
    private Guid _seekerId = Guid.CreateVersion7();
    private Guid _companyId = Guid.CreateVersion7();
    private Guid _jobId = Guid.CreateVersion7();

    public JobApplicationBuilder WithSeekerId(Guid seekerId)
    {
        _seekerId = seekerId;
        return this;
    }

    public JobApplicationBuilder WithJobId(Guid jobId)
    {
        _jobId = jobId;
        return this;
    }

    public JobApplication Build() => JobApplication.Create(_seekerId, _companyId, _jobId, null);
}
