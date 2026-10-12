using Microsoft.EntityFrameworkCore;
using Rinzo.Core.Entities.Common;
using Rinzo.Core.Interfaces.Common;
using Rinzo.Infrastructure.Data.Contexts;

namespace Rinzo.Infrastructure.Repositories.Common
{
    public class PhoneRepository : IPhoneRepository
    {
        private readonly BaseDBContext _dbContext;

        public PhoneRepository(BaseDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Phone> AddAsync(Phone entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Phone>> GetAllAsync()
        {
            return await _dbContext.Phones.ToListAsync();
        }

        public async Task<Phone> GetByIdAsync(string id)
        {
            var phone = await _dbContext.Phones.FirstOrDefaultAsync(e => e.Id == id);
            return phone ?? throw new KeyNotFoundException($"Phone with id {id} not found");
        }

        public Task UpdateAsync(Phone entity)
        {
            throw new NotImplementedException();
        }
    }
}
