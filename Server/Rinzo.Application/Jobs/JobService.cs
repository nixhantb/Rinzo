using FluentValidation;
using Rinzo.Application.Abstractions;
using Rinzo.Application.Common;
using Rinzo.Domain.Jobs;

namespace Rinzo.Application.Jobs;

public sealed class JobService(
    IJobRepository jobs,
    ICompanyRepository companies,
    IUnitOfWork unitOfWork,
    IValidator<JobRequest> validator
) : IJobService
{
    public async Task<JobResponse> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        var job = await jobs.GetByIdAsync(id, ct) ?? throw new NotFoundException(nameof(Job), id);
        return job.ToResponse();
    }

    public async Task<PagedResult<JobResponse>> GetPagedAsync(
        int page,
        int pageSize,
        CancellationToken ct = default
    )
    {
        page = Math.Max(page, 1);
        pageSize = Math.Clamp(pageSize, 1, 100);

        var result = await jobs.GetPagedAsync(page, pageSize, ct);
        return result.Map(job => job.ToResponse());
    }

    public async Task<IReadOnlyList<JobResponse>> ListAllAsync(CancellationToken ct = default)
    {
        var all = await jobs.ListAsync(ct);
        return all.Select(job => job.ToResponse()).ToList();
    }

    public async Task<JobResponse> CreateAsync(JobRequest request, CancellationToken ct = default)
    {
        await validator.ValidateAndThrowAsync(request, ct);

        if (await companies.GetByIdAsync(request.CompanyId, ct) is null)
        {
            throw new BadRequestException($"Company with id '{request.CompanyId}' does not exist.");
        }

        var job = Job.Create(
            request.CompanyId,
            request.JobTitle,
            request.JobDescription,
            request.JobType,
            request.JobAddress?.ToDomain(),
            request.Vacancies,
            request.BasicPay?.ToDomain(),
            request.FunctionalArea,
            request.RequiredSkills.Select(s => s.ToDomain()).ToList(),
            request.RequiredQualifications.Select(q => q.ToDomain()).ToList(),
            request.RequiredExperienceLevel,
            request.PreferredQualifications,
            request.JobResponsibilities,
            request.Benefits,
            request.Tags,
            request.WorkEnvironment,
            request.ApplicationDeadline
        );

        jobs.Add(job);
        await unitOfWork.SaveChangesAsync(ct);

        return job.ToResponse();
    }

    public async Task UpdateAsync(Guid id, JobRequest request, CancellationToken ct = default)
    {
        await validator.ValidateAndThrowAsync(request, ct);

        var job = await jobs.GetByIdAsync(id, ct) ?? throw new NotFoundException(nameof(Job), id);

        job.Update(
            request.JobTitle,
            request.JobDescription,
            request.JobType,
            request.JobAddress?.ToDomain(),
            request.Vacancies,
            request.BasicPay?.ToDomain(),
            request.FunctionalArea,
            request.RequiredSkills.Select(s => s.ToDomain()).ToList(),
            request.RequiredQualifications.Select(q => q.ToDomain()).ToList(),
            request.RequiredExperienceLevel,
            request.PreferredQualifications,
            request.JobResponsibilities,
            request.Benefits,
            request.Tags,
            request.WorkEnvironment,
            request.ApplicationDeadline
        );

        await unitOfWork.SaveChangesAsync(ct);
    }

    public async Task DeleteAsync(Guid id, CancellationToken ct = default)
    {
        var job = await jobs.GetByIdAsync(id, ct) ?? throw new NotFoundException(nameof(Job), id);
        jobs.Remove(job);
        await unitOfWork.SaveChangesAsync(ct);
    }
}
