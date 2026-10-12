using Rinzo.Core.Entities.Jobs.V1;
using Rinzo.Core.Interfaces.Jobs.V1;

namespace Rinzo.Core.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository _applicationRepository;

        public ApplicationService(IApplicationRepository applicationRepository)
        {
            _applicationRepository =
                applicationRepository
                ?? throw new ArgumentNullException(nameof(applicationRepository));
        }

        public Task<Application> AddAsync(Application entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            return _applicationRepository.AddAsync(entity);
        }

        public Task<Application> ApplyForJobAsync(
            string seekerId,
            string jobId,
            string companyId
        ) => _applicationRepository.ApplyForJobAsync(seekerId, jobId, companyId);

        public Task DeleteAsync(string id) => _applicationRepository.DeleteAsync(id);

        public Task<List<Application>> GetAllAsync() => _applicationRepository.GetAllAsync();

        public Task<List<Application>> GetApplicationBySeekersId(string seekerId) =>
            _applicationRepository.GetApplicationBySeekersId(seekerId);

        public Task<Application> GetApplicationDetailsAsync(string applicationId)
        {
            throw new NotImplementedException();
        }

        public Task<Application> GetByIdAsync(string id) => _applicationRepository.GetByIdAsync(id);

        public Task<Application> UpdateApplicationStatusAsync(string applicationId, Status status)
        {
            if (status == null)
                throw new ArgumentNullException(nameof(status));
            return _applicationRepository.UpdateApplicationStatusAsync(applicationId, status);
        }

        public Task UpdateAsync(Application entity) => _applicationRepository.UpdateAsync(entity);
    }
}
