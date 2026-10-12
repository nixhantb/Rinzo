using Rinzo.Core.Entities.Jobs.V1;
using Rinzo.Core.Interfaces.Jobs.V1;

namespace Rinzo.Core.Services
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository;

        public JobService(IJobRepository jobRepository)
        {
            _jobRepository =
                jobRepository ?? throw new ArgumentNullException(nameof(jobRepository));
        }

        public Task<JobEntity> AddAsync(JobEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            return _jobRepository.AddAsync(entity);
        }

        public Task DeleteAsync(string id) => _jobRepository.DeleteAsync(id);

        public Task<List<JobEntity>> GetAllAsync() => _jobRepository.GetAllAsync();

        public Task<JobEntity> GetByIdAsync(string id) => _jobRepository.GetByIdAsync(id);

        public Task UpdateAsync(JobEntity entity) => _jobRepository.UpdateAsync(entity);
    }
}
