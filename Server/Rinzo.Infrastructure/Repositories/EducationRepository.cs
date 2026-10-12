using Microsoft.EntityFrameworkCore;
using Rinzo.Core.Entities.Common;
using Rinzo.Core.Interfaces.Common;
using Rinzo.Infrastructure.Data.Contexts;

namespace Rinzo.Infrastructure.Repositories.Common
{
    public class EducationRepository : IEducationRepository
    {
        private readonly BaseDBContext _dbContext;

        public EducationRepository(BaseDBContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public Task<Education> AddAsync(Education entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Education>> GetAllAsync()
        {
            return await _dbContext.Educations.ToListAsync();
        }

        public Task<Education> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Education entity)
        {
            throw new NotImplementedException();
        }
    }
}
