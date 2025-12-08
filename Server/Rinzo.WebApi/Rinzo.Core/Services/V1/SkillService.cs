using JobLeet.WebApi.JobLeet.Api.Models.Common.V1;
using JobLeet.WebApi.JobLeet.Core.Entities.Common.V1;
using JobLeet.WebApi.JobLeet.Core.Interfaces.Common.V1;

namespace JobLeet.WebApi.JobLeet.Core.Services
{
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository _skillRepository;

        public SkillService(ISkillRepository skillRepository)
        {
            _skillRepository =
                skillRepository ?? throw new ArgumentNullException(nameof(skillRepository));
        }

        public async Task<SkillModel> AddAsync(Skill entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            var result = await _skillRepository.AddAsync(entity);
            return result;
        }

        public async Task DeleteAsync(string id)
        {
            await _skillRepository.DeleteAsync(id);
        }

        public async Task<List<SkillModel>> GetAllAsync()
        {
            var skills = await _skillRepository.GetAllAsync();
            return skills;
        }

        public async Task<SkillModel> GetByIdAsync(string id)
        {
            var skill = await _skillRepository.GetByIdAsync(id);
            if (skill == null)
            {
                throw new Exception($"Skill with ID {id} not found.");
            }
            return skill;
        }

        public async Task UpdateAsync(Skill entity)
        {
            await _skillRepository.UpdateAsync(entity);
        }
    }
}
