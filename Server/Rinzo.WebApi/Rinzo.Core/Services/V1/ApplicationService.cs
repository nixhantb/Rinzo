using JobLeet.WebApi.JobLeet.Api.Models.Jobs.V1;
using JobLeet.WebApi.JobLeet.Core.Entities.Jobs.V1;
using JobLeet.WebApi.JobLeet.Core.Interfaces.Jobs.V1;

namespace JobLeet.WebApi.JobLeet.Core.Services
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

        public async Task<ApplicationModel> AddAsync(Application entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            return await _applicationRepository.AddAsync(entity);
        }

        public async Task<Application> ApplyForJobAsync(
            string seekerId,
            string jobId,
            string companyId
        )
        {
            return await _applicationRepository.ApplyForJobAsync(seekerId, jobId, companyId);
        }

        public async Task DeleteAsync(string id)
        {
            var application = await _applicationRepository.GetByIdAsync(id);
            if (application == null)
                throw new Exception($"Application with ID {id} not found.");

            await _applicationRepository.DeleteAsync(id);
        }

        public async Task<List<ApplicationModel>> GetAllAsync()
        {
            return await _applicationRepository.GetAllAsync();
        }

        public async Task<List<ApplicationModel>> GetApplicationBySeekersId(string seekerId)
        {
            var applicationBySeekersId = await _applicationRepository.GetApplicationBySeekersId(
                seekerId
            );
            if (applicationBySeekersId == null)
            {
                throw new Exception($"Application with ID {seekerId} not found.");
            }
            return applicationBySeekersId;
        }

        public Task<Application> GetApplicationDetailsAsync(string applicationId)
        {
            throw new NotImplementedException();
        }

        public async Task<ApplicationModel> GetByIdAsync(string id)
        {
            var application = await _applicationRepository.GetByIdAsync(id);
            if (application == null)
                throw new Exception($"Application with ID {id} not found.");

            return application;
        }

        public async Task<Application> UpdateApplicationStatusAsync(
            string applicationId,
            Status status
        )
        {
            if (status == null)
                throw new ArgumentNullException(nameof(status));

            return await _applicationRepository.UpdateApplicationStatusAsync(applicationId, status);
        }

        public async Task UpdateAsync(Application entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await _applicationRepository.UpdateAsync(entity);
        }
    }
}
