using JobLeet.WebApi.JobLeet.Api.Models.Common.V1;
using JobLeet.WebApi.JobLeet.Core.Entities.Common.V1;
using JobLeet.WebApi.JobLeet.Core.Interfaces.Common.V1;

namespace JobLeet.WebApi.JobLeet.Core.Services
{
    public class EducationService : IEducationService
    {
        private readonly IEducationRepository _educationRepository;

        public EducationService(IEducationRepository educationRepository)
        {
            _educationRepository =
                educationRepository ?? throw new ArgumentNullException(nameof(educationRepository));
        }

        public async Task<EducationModel> AddAsync(Education entity)
        {
            var education = await _educationRepository.AddAsync(entity);
            return education;
        }

        public async Task DeleteAsync(string id)
        {
            await _educationRepository.DeleteAsync(id);
        }

        public async Task<List<EducationModel>> GetAllAsync()
        {
            var education = await _educationRepository.GetAllAsync();
            return education;
        }

        public async Task<EducationModel> GetByIdAsync(string id)
        {
            var education = await _educationRepository.GetByIdAsync(id);
            if (education == null)
            {
                throw new Exception($"Job with ID {id} not found.");
            }
            return education;
        }

        public async Task UpdateAsync(Education entity)
        {
            await _educationRepository.UpdateAsync(entity);
        }
    }
}
