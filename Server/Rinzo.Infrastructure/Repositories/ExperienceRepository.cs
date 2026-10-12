using Microsoft.EntityFrameworkCore;
using Rinzo.Core.Entities.Common;
using Rinzo.Core.Interfaces.Common;
using Rinzo.Infrastructure.Data.Contexts;

namespace Rinzo.Infrastructure.Repositories.Common
{
    public class ExperienceRepository : IExperienceRepository
    {
        private readonly BaseDBContext _dbContext;

        public ExperienceRepository(BaseDBContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public Task<Experience> AddAsync(Experience entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Experience>> GetAllAsync()
        {
            return await _dbContext.Experiences.ToListAsync();
        }

        public Task<Experience> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Experience entity)
        {
            throw new NotImplementedException();
        }
    }
}
