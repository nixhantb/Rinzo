using FluentValidation;
using Rinzo.Application.Abstractions;
using Rinzo.Application.Common;
using Rinzo.Domain.Applications;

namespace Rinzo.Application.Applications;

public sealed class ApplicationService(
    IApplicationRepository applications,
    ISeekerRepository seekers,
    ICompanyRepository companies,
    IJobRepository jobs,
    IUnitOfWork unitOfWork,
    IValidator<JobApplicationRequest> validator,
    IValidator<JobApplicationStatusRequest> statusValidator
) : IApplicationService
{
    public async Task<JobApplicationResponse> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        var application =
            await applications.GetByIdAsync(id, ct)
            ?? throw new NotFoundException(nameof(JobApplication), id);
        return application.ToResponse();
    }

    public async Task<PagedResult<JobApplicationResponse>> GetPagedAsync(
        int page,
        int pageSize,
        CancellationToken ct = default
    )
    {
        page = Math.Max(page, 1);
        pageSize = Math.Clamp(pageSize, 1, 100);

        var result = await applications.GetPagedAsync(page, pageSize, ct);
        return result.Map(application => application.ToResponse());
    }

    public async Task<IReadOnlyList<JobApplicationResponse>> ListAllAsync(
        CancellationToken ct = default
    )
    {
        var all = await applications.ListAsync(ct);
        return all.Select(application => application.ToResponse()).ToList();
    }

    public async Task<JobApplicationResponse> CreateAsync(
        JobApplicationRequest request,
        CancellationToken ct = default
    )
    {
        await validator.ValidateAndThrowAsync(request, ct);

        if (await seekers.GetByIdAsync(request.SeekerId, ct) is null)
        {
            throw new BadRequestException($"Seeker with id '{request.SeekerId}' does not exist.");
        }

        if (await companies.GetByIdAsync(request.CompanyId, ct) is null)
        {
            throw new BadRequestException($"Company with id '{request.CompanyId}' does not exist.");
        }

        if (await jobs.GetByIdAsync(request.JobId, ct) is null)
        {
            throw new BadRequestException($"Job with id '{request.JobId}' does not exist.");
        }

        if (await applications.ExistsAsync(request.SeekerId, request.JobId, ct))
        {
            throw new ConflictException("This seeker has already applied to this job.");
        }

        var application = JobApplication.Create(
            request.SeekerId,
            request.CompanyId,
            request.JobId,
            request.Comments
        );

        applications.Add(application);
        await unitOfWork.SaveChangesAsync(ct);

        return application.ToResponse();
    }

    public async Task UpdateStatusAsync(
        Guid id,
        JobApplicationStatusRequest request,
        CancellationToken ct = default
    )
    {
        await statusValidator.ValidateAndThrowAsync(request, ct);

        var application =
            await applications.GetByIdAsync(id, ct)
            ?? throw new NotFoundException(nameof(JobApplication), id);

        application.ChangeStatus(request.Status, request.Comments);

        await unitOfWork.SaveChangesAsync(ct);
    }

    public async Task DeleteAsync(Guid id, CancellationToken ct = default)
    {
        var application =
            await applications.GetByIdAsync(id, ct)
            ?? throw new NotFoundException(nameof(JobApplication), id);
        applications.Remove(application);
        await unitOfWork.SaveChangesAsync(ct);
    }
}
