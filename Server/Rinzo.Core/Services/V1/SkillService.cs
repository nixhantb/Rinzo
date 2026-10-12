using Rinzo.Core.Entities.Common.V1;
using Rinzo.Core.Interfaces.Common.V1;

namespace Rinzo.Core.Services
{
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository _skillRepository;

        public SkillService(ISkillRepository skillRepository)
        {
            _skillRepository =
                skillRepository ?? throw new ArgumentNullException(nameof(skillRepository));
        }

        public Task<Skill> AddAsync(Skill entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            return _skillRepository.AddAsync(entity);
        }

        public Task DeleteAsync(string id) => _skillRepository.DeleteAsync(id);

        public Task<List<Skill>> GetAllAsync() => _skillRepository.GetAllAsync();

        public Task<Skill> GetByIdAsync(string id) => _skillRepository.GetByIdAsync(id);

        public Task UpdateAsync(Skill entity) => _skillRepository.UpdateAsync(entity);
    }
}
