using Rinzo.Core.Models.Common.V1;
using Rinzo.Core.Models.Jobs.V1;
using Rinzo.Core.Entities.Jobs.V1;
using Rinzo.Core.Interfaces.Jobs.V1;
using Rinzo.Infrastructure.Data.Contexts;
using Rinzo.Infrastructure.Data.Contexts.V1.Identity;
using Rinzo.Infrastructure.Mappers.V1;
using Microsoft.EntityFrameworkCore;

namespace Rinzo.Infrastructure.Repositories.Companies.V1
{
    public class ApplicationRepository : IApplicationRepository
    {
        #region Initialization
        private readonly BaseDBContext _dbContext;
        private readonly ApplicationDbContext _authContext;

        #endregion

        public ApplicationRepository(BaseDBContext dbContext, ApplicationDbContext authContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _authContext = authContext ?? throw new ArgumentNullException(nameof(authContext));
        }

        public async Task<ApplicationModel> AddAsync(Application entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            var userId = _authContext.Users.FirstOrDefault()?.Id;

            var saveToDb = ApplicationMapper.ToApplicationDataBase(entity, userId);
            await _dbContext.Applications.AddAsync(saveToDb);
            await _dbContext.SaveChangesAsync();

            return ApplicationMapper.ToApplicationModel(saveToDb);
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
                Status = new Status { StatusName = Rinzo.Core.Entities.Jobs.V1.StatusName.Active },
            };

            _dbContext.Add(application);
            await _dbContext.SaveChangesAsync();

            return application;
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ApplicationModel>> GetAllAsync()
        {
            var entities = await _dbContext
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

            return entities.Select(ApplicationMapper.ToApplicationModel).ToList();
        }

        public async Task<ApplicationModel> GetByIdAsync(string id)
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

            if (application == null)
            {
                throw new KeyNotFoundException($"Application with id {id} not found");
            }

            return ApplicationMapper.ToApplicationModel(application);
        }

        public async Task<List<ApplicationModel>> GetApplicationBySeekersId(string seekerId)
        {
            if (string.IsNullOrEmpty(seekerId))
            {
                throw new ArgumentException("Seeker ID cannot be null or empty.");
            }

            var entities = await _dbContext
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

            return entities.Select(ApplicationMapper.ToApplicationModel).ToList();
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
