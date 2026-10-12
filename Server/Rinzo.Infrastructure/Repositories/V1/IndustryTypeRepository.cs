using Microsoft.EntityFrameworkCore;
using Rinzo.Core.Entities.Companies.V1;
using Rinzo.Core.Interfaces.Companies.V1;
using Rinzo.Infrastructure.Data.Contexts;

namespace Rinzo.Infrastructure.Repositories.Companies.V1
{
    public class IndustryTypeRepository : IIndustryTypeRepository
    {
        private readonly BaseDBContext _dbContext;

        public IndustryTypeRepository(BaseDBContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public Task<Industry> AddAsync(Industry entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Industry>> GetAllAsync()
        {
            return await _dbContext.IndustryTypes.ToListAsync();
        }

        public Task<Industry> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Industry entity)
        {
            throw new NotImplementedException();
        }
    }
}
