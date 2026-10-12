using Rinzo.Core.Models.Companies.V1;
using Rinzo.Core.Entities.Companies.V1;
using Rinzo.Core.Interfaces.Companies.V1;
using Rinzo.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Rinzo.Infrastructure.Repositories.Companies.V1
{
    public class IndustryTypeRepository : IIndustryTypeRepository
    {
        #region Initialization
        private readonly BaseDBContext _dbContext;

        #endregion

        public IndustryTypeRepository(BaseDBContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public Task<IndustryModel> AddAsync(Industry entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<IndustryModel>> GetAllAsync()
        {
            return await _dbContext
                .IndustryTypes.Select(e => new IndustryModel
                {
                    Id = e.Id,
                    IndustryType = e.IndustryType,
                })
                .ToListAsync();
        }

        public Task<IndustryModel> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Industry entity)
        {
            throw new NotImplementedException();
        }
    }
}
