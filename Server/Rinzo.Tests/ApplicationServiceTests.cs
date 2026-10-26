using Rinzo.Application.Applications;
using Rinzo.Application.Common;
using Rinzo.Domain.Applications;
using Rinzo.Tests.Builders;
using Rinzo.Tests.Fakes;

namespace Rinzo.Tests;

public class ApplicationServiceTests
{
    private readonly FakeApplicationRepository _repository = new();
    private readonly FakeSeekerRepository _seekers = new();
    private readonly FakeCompanyRepository _companies = new();
    private readonly FakeJobRepository _jobs = new();
    private readonly FakeUnitOfWork _unitOfWork = new();
    private readonly ApplicationService _service;

    public ApplicationServiceTests()
    {
        _service = new ApplicationService(
            _repository,
            _seekers,
            _companies,
            _jobs,
            _unitOfWork,
            new ApplicationRequestValidator(),
            new ApplicationStatusRequestValidator()
        );
    }

    private (Guid SeekerId, Guid CompanyId, Guid JobId) SeedSeekerCompanyAndJob()
    {
        var seeker = new SeekerBuilder().Build();
        var company = new CompanyBuilder().Build();
        var job = new JobBuilder().WithCompanyId(company.Id).Build();

        _seekers.Items.Add(seeker);
        _companies.Items.Add(company);
        _jobs.Items.Add(job);

        return (seeker.Id, company.Id, job.Id);
    }

    [Fact]
    public async Task Create_saves_the_application_when_seeker_company_and_job_exist()
    {
        var (seekerId, companyId, jobId) = SeedSeekerCompanyAndJob();

        var response = await _service.CreateAsync(
            new JobApplicationRequest(seekerId, companyId, jobId, null)
        );

        Assert.Equal(ApplicationStatus.Pending, response.Status);
        Assert.Single(_repository.Items);
        Assert.Equal(1, _unitOfWork.SaveCount);
    }

    [Fact]
    public async Task Create_for_an_unknown_job_throws_bad_request()
    {
        var (seekerId, companyId, _) = SeedSeekerCompanyAndJob();

        await Assert.ThrowsAsync<BadRequestException>(
            () =>
                _service.CreateAsync(
                    new JobApplicationRequest(seekerId, companyId, Guid.NewGuid(), null)
                )
        );
    }

    [Fact]
    public async Task Create_a_second_time_for_the_same_seeker_and_job_throws_conflict()
    {
        var (seekerId, companyId, jobId) = SeedSeekerCompanyAndJob();
        _repository.Items.Add(
            new JobApplicationBuilder().WithSeekerId(seekerId).WithJobId(jobId).Build()
        );

        await Assert.ThrowsAsync<ConflictException>(
            () => _service.CreateAsync(new JobApplicationRequest(seekerId, companyId, jobId, null))
        );
    }

    [Fact]
    public async Task UpdateStatus_moves_the_application_forward_and_saves()
    {
        var application = new JobApplicationBuilder().Build();
        _repository.Items.Add(application);

        await _service.UpdateStatusAsync(
            application.Id,
            new JobApplicationStatusRequest(ApplicationStatus.Reviewed, "Looks good")
        );

        Assert.Equal(ApplicationStatus.Reviewed, application.Status);
        Assert.Equal(1, _unitOfWork.SaveCount);
    }

    [Fact]
    public async Task GetById_with_an_unknown_id_throws_not_found()
    {
        await Assert.ThrowsAsync<NotFoundException>(() => _service.GetByIdAsync(Guid.NewGuid()));
    }
}
