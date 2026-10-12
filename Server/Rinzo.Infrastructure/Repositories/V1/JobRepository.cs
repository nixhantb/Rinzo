using Microsoft.EntityFrameworkCore;
using Rinzo.Core.Entities.Jobs.V1;
using Rinzo.Core.Interfaces.Jobs.V1;
using Rinzo.Infrastructure.Data.Contexts;

namespace Rinzo.Infrastructure.Repositories.Jobs.V1
{
    public class JobRepository : IJobRepository
    {
        private readonly BaseDBContext _dbContext;

        public JobRepository(BaseDBContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<JobEntity> AddAsync(JobEntity entity)
        {
            _dbContext.Jobs.Add(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<JobEntity>> GetAllAsync()
        {
            return await _dbContext
                .Jobs.Include(j => j.CompanyDescription)
                .ThenInclude(c => c.Profile)
                .ThenInclude(p => p.ContactEmail)
                .Include(j => j.CompanyDescription)
                .ThenInclude(c => c.Profile)
                .ThenInclude(p => p.CompanyAddress)
                .Include(j => j.CompanyDescription)
                .ThenInclude(c => c.Profile)
                .ThenInclude(p => p.ContactPhone)
                .Include(j => j.JobAddress)
                .Include(j => j.SkillsRequired)
                .Include(j => j.RequiredQualification)
                .Include(j => j.RequiredExperience)
                .ToListAsync();
        }

        public async Task<JobEntity> GetByIdAsync(string id)
        {
            var jobEntry = await _dbContext
                .Jobs.Include(j => j.CompanyDescription)
                .ThenInclude(c => c.Profile)
                .ThenInclude(p => p.ContactEmail)
                .Include(j => j.CompanyDescription)
                .ThenInclude(c => c.Profile)
                .ThenInclude(p => p.CompanyAddress)
                .Include(j => j.CompanyDescription)
                .ThenInclude(c => c.Profile)
                .ThenInclude(p => p.ContactPhone)
                .Include(j => j.JobAddress)
                .Include(j => j.SkillsRequired)
                .Include(j => j.RequiredQualification)
                .Include(j => j.RequiredExperience)
                .FirstOrDefaultAsync(j => j.Id == id);

            return jobEntry ?? throw new KeyNotFoundException($"Job with id {id} not found");
        }

        public Task UpdateAsync(JobEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
