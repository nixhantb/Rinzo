using Microsoft.EntityFrameworkCore;
using Rinzo.Core.Entities.Common;
using Rinzo.Core.Interfaces.Common;
using Rinzo.Infrastructure.Data.Contexts;

namespace Rinzo.Infrastructure.Repositories.Common
{
    public class QualificationTypeRepository : IQualificationTypeRepository
    {
        private readonly BaseDBContext _dbContext;

        public QualificationTypeRepository(BaseDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Qualification> AddAsync(Qualification entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Qualification>> GetAllAsync()
        {
            return await _dbContext.Qualifications.ToListAsync();
        }

        public Task<Qualification> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Qualification entity)
        {
            throw new NotImplementedException();
        }
    }
}
