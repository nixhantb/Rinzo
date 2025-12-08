using JobLeet.WebApi.JobLeet.Api.Models.Employers.V1;
using JobLeet.WebApi.JobLeet.Core.Entities.Employers.V1;
using JobLeet.WebApi.JobLeet.Core.Interfaces.Employers.V1;

namespace JobLeet.WebApi.JobLeet.Core.Services
{
    public class EmployerService : IEmployerService
    {
        private readonly IEmployerRepository _employerRepository;

        public EmployerService(IEmployerRepository employerRepository)
        {
            _employerRepository =
                employerRepository ?? throw new ArgumentNullException(nameof(employerRepository));
        }

        public async Task<EmployerModel> AddAsync(Employer entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            var result = await _employerRepository.AddAsync(entity);
            return result;
        }

        public async Task DeleteAsync(string id)
        {
            await _employerRepository.DeleteAsync(id);
        }

        public async Task<List<EmployerModel>> GetAllAsync()
        {
            var employer = await _employerRepository.GetAllAsync();
            return employer;
        }

        public async Task<EmployerModel> GetByIdAsync(string id)
        {
            var employer = await _employerRepository.GetByIdAsync(id);
            if (employer == null)
            {
                throw new Exception($"Job with ID {id} not found.");
            }
            return employer;
        }

        public async Task UpdateAsync(Employer entity)
        {
            await _employerRepository.UpdateAsync(entity);
        }
    }
}
