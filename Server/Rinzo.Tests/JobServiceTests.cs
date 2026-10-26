using FluentValidation;
using Rinzo.Application.Common;
using Rinzo.Application.Jobs;
using Rinzo.Tests.Builders;
using Rinzo.Tests.Fakes;

namespace Rinzo.Tests;

public class JobServiceTests
{
    private readonly FakeJobRepository _repository = new();
    private readonly FakeCompanyRepository _companies = new();
    private readonly FakeUnitOfWork _unitOfWork = new();
    private readonly JobService _service;

    public JobServiceTests()
    {
        _service = new JobService(_repository, _companies, _unitOfWork, new JobRequestValidator());
    }

    private static JobRequest ValidRequest(Guid companyId, int vacancies = 1) =>
        new(
            companyId,
            "Software Engineer",
            "Build and ship features.",
            "Full-time",
            null,
            vacancies,
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

    [Fact]
    public async Task Create_with_an_unknown_company_throws_bad_request()
    {
        await Assert.ThrowsAsync<BadRequestException>(
            () => _service.CreateAsync(ValidRequest(Guid.NewGuid()))
        );

        Assert.Equal(0, _unitOfWork.SaveCount);
    }

    [Fact]
    public async Task Create_saves_the_job_when_the_company_exists()
    {
        var company = new CompanyBuilder().Build();
        _companies.Items.Add(company);

        var response = await _service.CreateAsync(ValidRequest(company.Id));

        Assert.Equal(company.Id, response.CompanyId);
        Assert.Single(_repository.Items);
        Assert.Equal(1, _unitOfWork.SaveCount);
    }

    [Fact]
    public async Task Create_with_zero_vacancies_throws_validation_error()
    {
        var company = new CompanyBuilder().Build();
        _companies.Items.Add(company);

        await Assert.ThrowsAsync<ValidationException>(
            () => _service.CreateAsync(ValidRequest(company.Id, 0))
        );
    }

    [Fact]
    public async Task GetById_with_an_unknown_id_throws_not_found()
    {
        await Assert.ThrowsAsync<NotFoundException>(() => _service.GetByIdAsync(Guid.NewGuid()));
    }
}
