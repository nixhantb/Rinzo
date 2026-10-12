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
            var seeker = await _dbContext
                .Seekers.Include(s => s.Phone)
                .Include(s => s.Education)
                .Include(s => s.Address)
                .Include(s => s.Skills)
                .FirstOrDefaultAsync(s => s.Id == seekerId);
            if (seeker == null)
            {
                throw new KeyNotFoundException($"Seeker with id {seekerId} not found");
            }

            var company = await _dbContext
                .Companies.Include(c => c.Profile)
                .FirstOrDefaultAsync(c => c.Id == companyId);
            if (company == null)
            {
                throw new KeyNotFoundException($"Company with id {companyId} not found");
            }

            var job = await _dbContext
                .Jobs.Include(j => j.CompanyDescription)
                .Include(j => j.SkillsRequired)
                .FirstOrDefaultAsync(j => j.Id == jobId);
            if (job == null)
            {
                throw new KeyNotFoundException($"Job with id {jobId} not found");
            }

            var existingApplication = await _dbContext.Applications.FirstOrDefaultAsync(a =>
                a.SeekerId == seekerId && a.JobsId == jobId
            );
            if (existingApplication != null)
            {
                throw new ApplicationException("Seeker has already applied for this job.");
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

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Application>> GetAllAsync()
        {
            return await _dbContext
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
                .Include(j => j.Status)
                .ToListAsync();
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

            return await _dbContext
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
                .Include(j => j.Status)
                .Where(a => a.SeekerId == seekerId)
                .ToListAsync();
        }

        public Task<Application> UpdateApplicationStatusAsync(string applicationId, Status status)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Application entity)
        {
            throw new NotImplementedException();
        }
    }
}
