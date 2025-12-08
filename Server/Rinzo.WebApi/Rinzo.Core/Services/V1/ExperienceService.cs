using JobLeet.WebApi.JobLeet.Api.Models.Common.V1;
using JobLeet.WebApi.JobLeet.Core.Entities.Common.V1;
using JobLeet.WebApi.JobLeet.Core.Interfaces.Common.V1;

namespace JobLeet.WebApi.JobLeet.Core.Services
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

        public async Task<ExperienceModel> AddAsync(Experience entity)
        {
            var experience = await _experienceRepository.AddAsync(entity);
            return experience;
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ExperienceModel>> GetAllAsync()
        {
            var experience = await _experienceRepository.GetAllAsync();
            return experience;
        }

        public async Task<ExperienceModel> GetByIdAsync(string id)
        {
            var experience = await _experienceRepository.GetByIdAsync(id);
            if (experience == null)
            {
                throw new Exception($"Job with ID {id} not found.");
            }
            return experience;
        }

        public async Task UpdateAsync(Experience entity)
        {
            await _experienceRepository.UpdateAsync(entity);
        }
    }
}
