using FluentValidation;
using Rinzo.Application.Abstractions;
using Rinzo.Application.Common;
using Rinzo.Domain.Companies;

namespace Rinzo.Application.Companies;

// Service Layer (a Facade): hides validation, the uniqueness check, creation and
// saving behind a handful of simple methods. The controller calls this, nothing else.
public sealed class CompanyService(
    ICompanyRepository companies,
    IUnitOfWork unitOfWork,
    IValidator<CompanyRequest> validator
) : ICompanyService
{
    public async Task<CompanyResponse> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        var company =
            await companies.GetByIdAsync(id, ct)
            ?? throw new NotFoundException(nameof(Company), id);
        return company.ToResponse();
    }

    public async Task<PagedResult<CompanyResponse>> GetPagedAsync(
        int page,
        int pageSize,
        CancellationToken ct = default
    )
    {
        page = Math.Max(page, 1);
        pageSize = Math.Clamp(pageSize, 1, 100);

        var result = await companies.GetPagedAsync(page, pageSize, ct);
        return result.Map(company => company.ToResponse());
    }

    public async Task<IReadOnlyList<CompanyResponse>> ListAllAsync(CancellationToken ct = default)
    {
        var all = await companies.ListAsync(ct);
        return all.Select(company => company.ToResponse()).ToList();
    }

    public async Task<CompanyResponse> CreateAsync(
        CompanyRequest request,
        CancellationToken ct = default
    )
    {
        await validator.ValidateAndThrowAsync(request, ct);

        if (await companies.NameExistsAsync(request.CompanyName, excludeId: null, ct))
        {
            throw new ConflictException($"A company named '{request.CompanyName}' already exists.");
        }

        var company = Company.Create(
            request.CompanyName,
            request.ProfileInfo,
            request.Website,
            request.Industry,
            request.CompanyAddress?.ToDomain(),
            request.ContactPhone?.ToDomain(),
            request.ContactEmail?.ToDomain()
        );

        companies.Add(company);
        await unitOfWork.SaveChangesAsync(ct);

        return company.ToResponse();
    }

    public async Task UpdateAsync(Guid id, CompanyRequest request, CancellationToken ct = default)
    {
        await validator.ValidateAndThrowAsync(request, ct);

        var company =
            await companies.GetByIdAsync(id, ct)
            ?? throw new NotFoundException(nameof(Company), id);

        if (await companies.NameExistsAsync(request.CompanyName, excludeId: id, ct))
        {
            throw new ConflictException($"A company named '{request.CompanyName}' already exists.");
        }

        company.Update(
            request.CompanyName,
            request.ProfileInfo,
            request.Website,
            request.Industry,
            request.CompanyAddress?.ToDomain(),
            request.ContactPhone?.ToDomain(),
            request.ContactEmail?.ToDomain()
        );

        await unitOfWork.SaveChangesAsync(ct);
    }

    public async Task DeleteAsync(Guid id, CancellationToken ct = default)
    {
        var company =
            await companies.GetByIdAsync(id, ct)
            ?? throw new NotFoundException(nameof(Company), id);
        companies.Remove(company);
        await unitOfWork.SaveChangesAsync(ct);
    }
}
