using Rinzo.Core.Models.Jobs.V1;
using Rinzo.Core.Entities.Jobs.V1;
using Rinzo.Core.Interfaces.Jobs.V1;
using Rinzo.Infrastructure.Data.Contexts;
using Rinzo.Infrastructure.Mappers.V1;
using Microsoft.EntityFrameworkCore;

namespace Rinzo.Infrastructure.Repositories.Jobs.V1
{
    public class JobRepository : IJobRepository
    {
        #region Initialization
        private readonly BaseDBContext _dbContext;

        #endregion

        public JobRepository(BaseDBContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<JobModel> AddAsync(JobEntity entity)
        {
            var saveToDb = JobsMapper.ToJobDatabase(entity);

            _dbContext.Jobs.Add(saveToDb);
            await _dbContext.SaveChangesAsync();

            return JobsMapper.ToJobModel(saveToDb);
        }

        public async Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<JobModel>> GetAllAsync()
        {
            var entities = await _dbContext
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

            return entities.Select(entity => JobsMapper.ToJobModel(entity)).ToList();
        }

        public async Task<JobModel> GetByIdAsync(string id)
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

            if (jobEntry == null)
            {
                throw new KeyNotFoundException($"Job with id {id} not found");
            }

            return JobsMapper.ToJobModel(jobEntry);
        }

        public async Task UpdateAsync(JobEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
