using FluentValidation;
using Rinzo.Application.Common;
using Rinzo.Application.Seekers;
using Rinzo.Tests.Fakes;

namespace Rinzo.Tests;

public class SeekerServiceTests
{
    private readonly FakeSeekerRepository _repository = new();
    private readonly FakeUnitOfWork _unitOfWork = new();
    private readonly SeekerService _service;

    public SeekerServiceTests()
    {
        _service = new SeekerService(_repository, _unitOfWork, new SeekerRequestValidator());
    }

    private static SeekerRequest ValidRequest(
        string firstName = "John",
        string lastName = "Smith"
    ) =>
        new(
            new PersonNameDto(firstName, null, lastName),
            null,
            null,
            null,
            null,
            [],
            [],
            [],
            [],
            [],
            [],
            [],
            []
        );

    [Fact]
    public async Task Create_saves_the_seeker_and_returns_its_id()
    {
        var response = await _service.CreateAsync(ValidRequest());

        Assert.NotEqual(Guid.Empty, response.Id);
        Assert.Single(_repository.Items);
        Assert.Equal(1, _unitOfWork.SaveCount);
    }

    [Fact]
    public async Task Create_with_an_empty_last_name_throws_validation_error()
    {
        await Assert.ThrowsAsync<ValidationException>(
            () => _service.CreateAsync(ValidRequest(lastName: ""))
        );
    }

    [Fact]
    public async Task GetById_with_an_unknown_id_throws_not_found()
    {
        await Assert.ThrowsAsync<NotFoundException>(() => _service.GetByIdAsync(Guid.NewGuid()));
    }
}
