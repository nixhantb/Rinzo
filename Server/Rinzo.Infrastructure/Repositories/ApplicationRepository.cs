using Microsoft.EntityFrameworkCore;
using Rinzo.Core.Entities.Jobs;
using Rinzo.Core.Interfaces.Jobs;
using Rinzo.Infrastructure.Data.Contexts;
using Rinzo.Infrastructure.Data.Contexts.Identity;

namespace Rinzo.Infrastructure.Repositories.Companies
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly BaseDBContext _dbContext;
        private readonly ApplicationDbContext _authContext;

        public ApplicationRepository(BaseDBContext dbContext, ApplicationDbContext authContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _authContext = authContext ?? throw new ArgumentNullException(nameof(authContext));
        }

        // Shared by GetAllAsync/GetApplicationBySeekersId so the two can't silently drift
        // apart. All single-reference includes - no collections here, so no
        // cartesian-explosion risk in this one.
        private IQueryable<Application> ApplicationsWithDetails() =>
            _dbContext
                .Applications.Include(p => p.Company)
                .ThenInclude(p => p.Profile)
                .Include(p => p.Company)
                .ThenInclude(p => p.Profile)
                .ThenInclude(p => p.CompanyAddress)
                .Include(p => p.Company)
                .ThenInclude(p => p.Profile)
                .ThenInclude(p => p.ContactEmail)
                .Include(p => p.Company)
                .ThenInclude(p => p.Profile)
                .ThenInclude(p => p.ContactPhone)
                .Include(p => p.Company)
                .ThenInclude(p => p.Profile)
                .ThenInclude(p => p.IndustryTypes)
                .Include(j => j.Jobs)
                .ThenInclude(j => j.JobAddress)
                .Include(j => j.ApplicationDate)
                .Include(j => j.Status);

        public async Task<Application> AddAsync(Application entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            // The seeker (and status) embedded in the application share the owning
            // record's id, mirroring the shared-key relationship used elsewhere.
            var userId = _authContext.Users.FirstOrDefault()?.Id;
            if (entity.Seekers != null)
            {
                entity.Seekers.Id = userId;
            }
            if (entity.Status != null)
            {
                entity.Status.Id = entity.Id;
            }

            await _dbContext.Applications.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<Application> ApplyForJobAsync(
            string seekerId,
            string jobId,
            string companyId
        )
        {
            // Cheapest check first: if they've already applied, there's no point
            // touching Seekers/Companies/Jobs at all.
            var alreadyApplied = await _dbContext.Applications.AnyAsync(a =>
                a.SeekerId == seekerId && a.JobsId == jobId
            );
            if (alreadyApplied)
            {
                throw new ApplicationException("Seeker has already applied for this job.");
            }

            // These three are existence checks only - the application below is built
            // from the raw ids, not from the fetched entities - so there's no reason to
            // pull Seeker/Company/Job (and everything EF would eagerly include with them)
            // across the wire just to find out whether a row with that id exists.
            var seekerExists = await _dbContext.Seekers.AnyAsync(s => s.Id == seekerId);
            if (!seekerExists)
            {
                throw new KeyNotFoundException($"Seeker with id {seekerId} not found");
            }

            var companyExists = await _dbContext.Companies.AnyAsync(c => c.Id == companyId);
            if (!companyExists)
            {
                throw new KeyNotFoundException($"Company with id {companyId} not found");
            }

            var jobExists = await _dbContext.Jobs.AnyAsync(j => j.Id == jobId);
            if (!jobExists)
            {
                throw new KeyNotFoundException($"Job with id {jobId} not found");
            }

            var application = new Application
            {
                SeekerId = seekerId,
                JobsId = jobId,
                CompanyId = companyId,
                Seekers = null,
                Jobs = null,
                Company = null,
                ApplicationDate = new()
                {
                    SubmitDate = DateTime.UtcNow,
                    ReviewDate = DateTime.UtcNow,
                    DecisionDate = DateTime.UtcNow,
                    Comments = "Successfully Applied to the new Job",
                },
                Status = new Status { StatusName = StatusName.Active },
            };

            _dbContext.Add(application);
            await _dbContext.SaveChangesAsync();

            return application;
        }

        public async Task DeleteAsync(string id)
        {
            // Nothing else holds an FK back to Application, so removing the row itself
            // can never hit a constraint. ApplicationDate and Status are included anyway
            // because - unlike Company/Jobs/Seekers, which Application only references and
            // must never delete - each Application gets its own fresh ApplicationDate and
            // Status created just for it (see AddAsync/ApplyForJobAsync), so leaving them
            // out would just orphan them instead of actually cleaning up.
            var existing = await _dbContext
                .Applications.Include(a => a.ApplicationDate)
                .Include(a => a.Status)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (existing == null)
            {
                throw new KeyNotFoundException($"Application with id {id} not found");
            }

            _dbContext.Applications.Remove(existing);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Application>> GetAllAsync()
        {
            return await ApplicationsWithDetails().ToListAsync();
        }

        public async Task<Application> GetByIdAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException("Application ID cannot be null or empty.");
            }

            var application = await _dbContext
                .Applications.Include(a => a.Seekers)
                .Include(a => a.Jobs)
                .Include(a => a.Company)
                .Include(a => a.ApplicationDate)
                .FirstOrDefaultAsync(a => a.Id == id);

            return application
                ?? throw new KeyNotFoundException($"Application with id {id} not found");
        }

        public async Task<List<Application>> GetApplicationBySeekersId(string seekerId)
        {
            if (string.IsNullOrEmpty(seekerId))
            {
                throw new ArgumentException("Seeker ID cannot be null or empty.");
            }

            return await ApplicationsWithDetails().Where(a => a.SeekerId == seekerId).ToListAsync();
        }

        public async Task<Application> UpdateApplicationStatusAsync(
            string applicationId,
            Status status
        )
        {
            if (status == null)
            {
                throw new ArgumentNullException(nameof(status));
            }

            var existing = await _dbContext
                .Applications.Include(a => a.Status)
                .FirstOrDefaultAsync(a => a.Id == applicationId);

            if (existing == null)
            {
                throw new KeyNotFoundException($"Application with id {applicationId} not found");
            }

            // Status is exclusively this application's own (created fresh in
            // AddAsync/ApplyForJobAsync), so mutating it in place is safe - it's not a
            // shared row like Company.
            existing.Status ??= new Status();
            existing.Status.StatusName = status.StatusName;

            await _dbContext.SaveChangesAsync();

            return existing;
        }

        public async Task UpdateAsync(Application entity)
        {
            var existing = await ApplicationsWithDetails()
                .FirstOrDefaultAsync(a => a.Id == entity.Id);
            if (existing == null)
            {
                throw new KeyNotFoundException($"Application with id {entity.Id} not found");
            }

            UpdateDetails(existing, entity);

            await _dbContext.SaveChangesAsync();
        }

        private static void UpdateDetails(Application existing, Application updated)
        {
            existing.SeekerId = updated.SeekerId;
            existing.CompanyId = updated.CompanyId;
            existing.JobsId = updated.JobsId;

            if (updated.ApplicationDate != null)
            {
                existing.ApplicationDate ??= new ApplicationDate();
                existing.ApplicationDate.SubmitDate = updated.ApplicationDate.SubmitDate;
                existing.ApplicationDate.ReviewDate = updated.ApplicationDate.ReviewDate;
                existing.ApplicationDate.DecisionDate = updated.ApplicationDate.DecisionDate;
                existing.ApplicationDate.Comments = updated.ApplicationDate.Comments;
            }

            if (updated.Status != null)
            {
                existing.Status ??= new Status();
                existing.Status.StatusName = updated.Status.StatusName;
            }
        }
    }
}
