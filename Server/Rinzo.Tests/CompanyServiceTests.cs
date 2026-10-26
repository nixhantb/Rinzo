using FluentValidation;
using Rinzo.Application.Common;
using Rinzo.Application.Companies;
using Rinzo.Tests.Builders;
using Rinzo.Tests.Fakes;

namespace Rinzo.Tests;

public class CompanyServiceTests
{
    private readonly FakeCompanyRepository _repository = new();
    private readonly FakeUnitOfWork _unitOfWork = new();
    private readonly CompanyService _service;

    public CompanyServiceTests()
    {
        _service = new CompanyService(_repository, _unitOfWork, new CompanyRequestValidator());
    }

    private static CompanyRequest ValidRequest(string name = "Acme Corp") =>
        new(name, null, null, null, null, null, null);

    [Fact]
    public async Task Create_saves_the_company_and_returns_its_id()
    {
        var response = await _service.CreateAsync(ValidRequest());

        Assert.NotEqual(Guid.Empty, response.Id);
        Assert.Single(_repository.Items);
        Assert.Equal(1, _unitOfWork.SaveCount);
    }

    [Fact]
    public async Task Create_with_a_duplicate_name_throws_conflict_and_saves_nothing()
    {
        _repository.Items.Add(new CompanyBuilder().WithName("Acme Corp").Build());

        await Assert.ThrowsAsync<ConflictException>(() => _service.CreateAsync(ValidRequest()));

        Assert.Equal(0, _unitOfWork.SaveCount);
    }

    [Fact]
    public async Task Create_with_an_empty_name_throws_validation_error()
    {
        await Assert.ThrowsAsync<ValidationException>(() => _service.CreateAsync(ValidRequest("")));
    }

    [Fact]
    public async Task Update_changes_the_company_and_saves()
    {
        var company = new CompanyBuilder().WithName("Old Name").Build();
        _repository.Items.Add(company);

        await _service.UpdateAsync(company.Id, ValidRequest("New Name"));

        Assert.Equal("New Name", company.CompanyName);
        Assert.Equal(1, _unitOfWork.SaveCount);
    }

    [Fact]
    public async Task GetById_with_an_unknown_id_throws_not_found()
    {
        await Assert.ThrowsAsync<NotFoundException>(() => _service.GetByIdAsync(Guid.NewGuid()));
    }
}
