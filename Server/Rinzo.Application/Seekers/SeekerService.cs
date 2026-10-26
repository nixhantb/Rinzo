using FluentValidation;
using Rinzo.Application.Abstractions;
using Rinzo.Application.Common;
using Rinzo.Domain.Seekers;

namespace Rinzo.Application.Seekers;

public sealed class SeekerService(
    ISeekerRepository seekers,
    IUnitOfWork unitOfWork,
    IValidator<SeekerRequest> validator
) : ISeekerService
{
    public async Task<SeekerResponse> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        var seeker =
            await seekers.GetByIdAsync(id, ct) ?? throw new NotFoundException(nameof(Seeker), id);
        return seeker.ToResponse();
    }

    public async Task<PagedResult<SeekerResponse>> GetPagedAsync(
        int page,
        int pageSize,
        CancellationToken ct = default
    )
    {
        page = Math.Max(page, 1);
        pageSize = Math.Clamp(pageSize, 1, 100);

        var result = await seekers.GetPagedAsync(page, pageSize, ct);
        return result.Map(seeker => seeker.ToResponse());
    }

    public async Task<IReadOnlyList<SeekerResponse>> ListAllAsync(CancellationToken ct = default)
    {
        var all = await seekers.ListAsync(ct);
        return all.Select(seeker => seeker.ToResponse()).ToList();
    }

    public async Task<SeekerResponse> CreateAsync(
        SeekerRequest request,
        CancellationToken ct = default
    )
    {
        await validator.ValidateAndThrowAsync(request, ct);

        var seeker = Seeker.Create(
            request.PersonName.ToDomain(),
            request.Phone?.ToDomain(),
            request.Address?.ToDomain(),
            request.DateOfBirth,
            request.ProfileSummary,
            request.Skills.Select(s => s.ToDomain()).ToList(),
            request.Education.Select(e => e.ToDomain()).ToList(),
            request.Experience.Select(e => e.ToDomain()).ToList(),
            request.Qualifications.Select(q => q.ToDomain()).ToList(),
            request.SocialMedias.Select(s => s.ToDomain()).ToList(),
            request.Projects.Select(p => p.ToDomain()).ToList(),
            request.Interests,
            request.Achievements
        );

        seekers.Add(seeker);
        await unitOfWork.SaveChangesAsync(ct);

        return seeker.ToResponse();
    }

    public async Task UpdateAsync(Guid id, SeekerRequest request, CancellationToken ct = default)
    {
        await validator.ValidateAndThrowAsync(request, ct);

        var seeker =
            await seekers.GetByIdAsync(id, ct) ?? throw new NotFoundException(nameof(Seeker), id);

        seeker.Update(
            request.PersonName.ToDomain(),
            request.Phone?.ToDomain(),
            request.Address?.ToDomain(),
            request.DateOfBirth,
            request.ProfileSummary,
            request.Skills.Select(s => s.ToDomain()).ToList(),
            request.Education.Select(e => e.ToDomain()).ToList(),
            request.Experience.Select(e => e.ToDomain()).ToList(),
            request.Qualifications.Select(q => q.ToDomain()).ToList(),
            request.SocialMedias.Select(s => s.ToDomain()).ToList(),
            request.Projects.Select(p => p.ToDomain()).ToList(),
            request.Interests,
            request.Achievements
        );

        await unitOfWork.SaveChangesAsync(ct);
    }

    public async Task DeleteAsync(Guid id, CancellationToken ct = default)
    {
        var seeker =
            await seekers.GetByIdAsync(id, ct) ?? throw new NotFoundException(nameof(Seeker), id);
        seekers.Remove(seeker);
        await unitOfWork.SaveChangesAsync(ct);
    }
}
