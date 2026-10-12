using Rinzo.Core.Entities.Common.V1;
using Rinzo.Core.Interfaces.Common.V1;

namespace Rinzo.Core.Services
{
    public class ExperienceService : IExperienceService
    {
        private readonly IExperienceRepository _experienceRepository;

        public ExperienceService(IExperienceRepository experienceRepository)
        {
            _experienceRepository =
                experienceRepository
                ?? throw new ArgumentNullException(nameof(experienceRepository));
        }

        public Task<Experience> AddAsync(Experience entity) =>
            _experienceRepository.AddAsync(entity);

        public Task DeleteAsync(string id) => _experienceRepository.DeleteAsync(id);

        public Task<List<Experience>> GetAllAsync() => _experienceRepository.GetAllAsync();

        public Task<Experience> GetByIdAsync(string id) => _experienceRepository.GetByIdAsync(id);

        public Task UpdateAsync(Experience entity) => _experienceRepository.UpdateAsync(entity);
    }
}
