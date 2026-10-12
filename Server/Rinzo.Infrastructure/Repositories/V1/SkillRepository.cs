using Microsoft.EntityFrameworkCore;
using Rinzo.Core.Entities.Common.V1;
using Rinzo.Core.Interfaces.Common.V1;
using Rinzo.Infrastructure.Data.Contexts;

namespace Rinzo.Infrastructure.Repositories.Common.V1
{
    public class SkillRepository : ISkillRepository
    {
        private readonly BaseDBContext _dbContext;

        public SkillRepository(BaseDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Skill>> GetAllAsync()
        {
            return await _dbContext.Skills.ToListAsync();
        }

        public Task<Skill> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Skill> AddAsync(Skill entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Skill entity)
        {
            throw new NotImplementedException();
        }
    }
}
