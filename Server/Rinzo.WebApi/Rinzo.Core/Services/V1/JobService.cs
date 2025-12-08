using JobLeet.WebApi.JobLeet.Api.Models.Jobs.V1;
using JobLeet.WebApi.JobLeet.Core.Entities.Jobs.V1;
using JobLeet.WebApi.JobLeet.Core.Interfaces.Jobs.V1;

namespace JobLeet.WebApi.JobLeet.Core.Services
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository;

        public JobService(IJobRepository jobRepository)
        {
            _jobRepository =
                jobRepository ?? throw new ArgumentNullException(nameof(jobRepository));
        }

        public async Task<JobModel> AddAsync(JobEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            var result = await _jobRepository.AddAsync(entity);
            return result;
        }

        public async Task DeleteAsync(string id)
        {
            await _jobRepository.DeleteAsync(id);
        }

        public async Task<List<JobModel>> GetAllAsync()
        {
            var jobs = await _jobRepository.GetAllAsync();
            return jobs;
        }

        public async Task<JobModel> GetByIdAsync(string id)
        {
            var job = await _jobRepository.GetByIdAsync(id);
            if (job == null)
            {
                throw new Exception($"Job with ID {id} not found.");
            }
            return job;
        }

        public async Task UpdateAsync(JobEntity entity)
        {
            await _jobRepository.UpdateAsync(entity);
        }
    }
}
