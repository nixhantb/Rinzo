using Rinzo.Core.Entities.Common.V1;
using Rinzo.Core.Interfaces.Common.V1;
using Rinzo.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Rinzo.Infrastructure.Repositories.Common.V1
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
