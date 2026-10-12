using Rinzo.Core.Entities.Employers.V1;
using Rinzo.Core.Interfaces.Employers.V1;

namespace Rinzo.Core.Services
{
    public class EmployerService : IEmployerService
    {
        private readonly IEmployerRepository _employerRepository;

        public EmployerService(IEmployerRepository employerRepository)
        {
            _employerRepository =
                employerRepository ?? throw new ArgumentNullException(nameof(employerRepository));
        }

        public Task<Employer> AddAsync(Employer entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            return _employerRepository.AddAsync(entity);
        }

        public Task DeleteAsync(string id) => _employerRepository.DeleteAsync(id);

        public Task<List<Employer>> GetAllAsync() => _employerRepository.GetAllAsync();

        public Task<Employer> GetByIdAsync(string id) => _employerRepository.GetByIdAsync(id);

        public Task UpdateAsync(Employer entity) => _employerRepository.UpdateAsync(entity);
    }
}
