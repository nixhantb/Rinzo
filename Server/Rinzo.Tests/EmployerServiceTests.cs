using FluentValidation;
using Rinzo.Application.Common;
using Rinzo.Application.Employers;
using Rinzo.Domain.Employers;
using Rinzo.Tests.Builders;
using Rinzo.Tests.Fakes;

namespace Rinzo.Tests;

public class EmployerServiceTests
{
    private readonly FakeEmployerRepository _repository = new();
    private readonly FakeCompanyRepository _companies = new();
    private readonly FakeUnitOfWork _unitOfWork = new();
    private readonly EmployerService _service;

    public EmployerServiceTests()
    {
        _service = new EmployerService(
            _repository,
            _companies,
            _unitOfWork,
            new EmployerRequestValidator()
        );
    }

    private EmployerRequest ValidRequest(Guid companyId) =>
        new(
            companyId,
            new PersonNameDto("Jane", null, "Doe"),
            null,
            null,
            EmployerType.SmallBusiness,
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
    public async Task Create_saves_the_employer_when_the_company_exists()
    {
        var company = new CompanyBuilder().Build();
        _companies.Items.Add(company);

        var response = await _service.CreateAsync(ValidRequest(company.Id));

        Assert.Equal(company.Id, response.CompanyId);
        Assert.Single(_repository.Items);
        Assert.Equal(1, _unitOfWork.SaveCount);
    }

    [Fact]
    public async Task Create_with_a_missing_last_name_throws_validation_error()
    {
        var company = new CompanyBuilder().Build();
        _companies.Items.Add(company);

        var request = new EmployerRequest(
            company.Id,
            new PersonNameDto("Jane", null, ""),
            null,
            null,
            EmployerType.SmallBusiness,
            null
        );

        await Assert.ThrowsAsync<ValidationException>(() => _service.CreateAsync(request));
    }

    [Fact]
    public async Task GetById_with_an_unknown_id_throws_not_found()
    {
        await Assert.ThrowsAsync<NotFoundException>(() => _service.GetByIdAsync(Guid.NewGuid()));
    }
}
