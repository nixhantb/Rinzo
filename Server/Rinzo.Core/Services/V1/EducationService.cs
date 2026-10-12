using Rinzo.Core.Entities.Common.V1;
using Rinzo.Core.Interfaces.Common.V1;

namespace Rinzo.Core.Services
{
    public class EducationService : IEducationService
    {
        private readonly IEducationRepository _educationRepository;

        public EducationService(IEducationRepository educationRepository)
        {
            _educationRepository =
                educationRepository ?? throw new ArgumentNullException(nameof(educationRepository));
        }

        public Task<Education> AddAsync(Education entity) => _educationRepository.AddAsync(entity);

        public Task DeleteAsync(string id) => _educationRepository.DeleteAsync(id);

        public Task<List<Education>> GetAllAsync() => _educationRepository.GetAllAsync();

        public Task<Education> GetByIdAsync(string id) => _educationRepository.GetByIdAsync(id);

        public Task UpdateAsync(Education entity) => _educationRepository.UpdateAsync(entity);
    }
}
