using FluentValidation;
using Rinzo.Application.Abstractions;
using Rinzo.Application.Common;
using Rinzo.Domain.Companies;
using Rinzo.Domain.Employers;

namespace Rinzo.Application.Employers;

public sealed class EmployerService(
    IEmployerRepository employers,
    ICompanyRepository companies,
    IUnitOfWork unitOfWork,
    IValidator<EmployerRequest> validator
) : IEmployerService
{
    public async Task<EmployerResponse> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        var employer =
            await employers.GetByIdAsync(id, ct)
            ?? throw new NotFoundException(nameof(Employer), id);
        return employer.ToResponse();
    }

    public async Task<PagedResult<EmployerResponse>> GetPagedAsync(
        int page,
        int pageSize,
        CancellationToken ct = default
    )
    {
        page = Math.Max(page, 1);
        pageSize = Math.Clamp(pageSize, 1, 100);

        var result = await employers.GetPagedAsync(page, pageSize, ct);
        return result.Map(employer => employer.ToResponse());
    }

    public async Task<IReadOnlyList<EmployerResponse>> ListAllAsync(CancellationToken ct = default)
    {
        var all = await employers.ListAsync(ct);
        return all.Select(employer => employer.ToResponse()).ToList();
    }

    public async Task<EmployerResponse> CreateAsync(
        EmployerRequest request,
        CancellationToken ct = default
    )
    {
        await validator.ValidateAndThrowAsync(request, ct);
        await EnsureCompanyExistsAsync(request.CompanyId, ct);

        var employer = Employer.Create(
            request.CompanyId,
            request.Name.ToDomain(),
            request.EmployerAddress?.ToDomain(),
            request.EmployerPhone?.ToDomain(),
            request.EmployerType,
            request.IndustryType
        );

        employers.Add(employer);
        await unitOfWork.SaveChangesAsync(ct);

        return employer.ToResponse();
    }

    public async Task UpdateAsync(Guid id, EmployerRequest request, CancellationToken ct = default)
    {
        await validator.ValidateAndThrowAsync(request, ct);

        var employer =
            await employers.GetByIdAsync(id, ct)
            ?? throw new NotFoundException(nameof(Employer), id);

        employer.Update(
            request.Name.ToDomain(),
            request.EmployerAddress?.ToDomain(),
            request.EmployerPhone?.ToDomain(),
            request.EmployerType,
            request.IndustryType
        );

        await unitOfWork.SaveChangesAsync(ct);
    }

    public async Task DeleteAsync(Guid id, CancellationToken ct = default)
    {
        var employer =
            await employers.GetByIdAsync(id, ct)
            ?? throw new NotFoundException(nameof(Employer), id);
        employers.Remove(employer);
        await unitOfWork.SaveChangesAsync(ct);
    }

    private async Task EnsureCompanyExistsAsync(Guid companyId, CancellationToken ct)
    {
        if (await companies.GetByIdAsync(companyId, ct) is null)
        {
            throw new BadRequestException($"Company with id '{companyId}' does not exist.");
        }
    }
}
