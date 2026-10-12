using Rinzo.Core.Entities.Common.V1;
using Rinzo.Core.Interfaces.Common.V1;
using Rinzo.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Rinzo.Infrastructure.Repositories.Common.V1
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
