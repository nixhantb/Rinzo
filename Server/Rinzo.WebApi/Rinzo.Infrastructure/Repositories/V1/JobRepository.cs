using System.Data.Common;
using JobLeet.WebApi.JobLeet.Api.Models.Jobs.V1;
using JobLeet.WebApi.JobLeet.Core.Entities.Jobs.V1;
using JobLeet.WebApi.JobLeet.Core.Interfaces.Jobs.V1;
using JobLeet.WebApi.JobLeet.Infrastructure.Data.Contexts;
using JobLeet.WebApi.JobLeet.Mappers.V1;
using Microsoft.EntityFrameworkCore;

namespace JobLeet.WebApi.JobLeet.Infrastructure.Repositories.Jobs.V1
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
            try
            {
                #region  To JobLeet DB

                var saveToDb = JobsMapper.ToJobDatabase(entity);

                _dbContext.Jobs.Add(saveToDb);
                await _dbContext.SaveChangesAsync();
                #endregion

                #region  To Api Response
                var apiResponses = JobsMapper.ToJobModel(saveToDb);

                #endregion
                return apiResponses;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred while logging in: {ex.Message}");
            }
        }

        public async Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<JobModel>> GetAllAsync()
        {
            try
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

                var apiResponses = entities
                    .Select(entity => JobsMapper.ToJobModel(entity))
                    .ToList();
                return apiResponses;
            }
            catch (Exception ex) when (ex is DbUpdateException || ex is DbException)
            {
                throw new Exception(
                    "Error while fetching data from the database. Please try again later."
                );
            }
        }

        public async Task<JobModel> GetByIdAsync(string id)
        {
            try
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
                    throw new Exception($"The Job with ID {id} does not exist.");
                }

                var jobModel = JobsMapper.ToJobModel(jobEntry);
                return jobModel;
            }
            catch (Exception ex) when (ex is DbUpdateException || ex is DbException)
            {
                throw new Exception(
                    "The Job with the requested ID doesn't exist or a database exception occurred.",
                    ex
                );
            }
        }

        public async Task UpdateAsync(JobEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
