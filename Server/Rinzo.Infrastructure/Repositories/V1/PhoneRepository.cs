using Rinzo.Core.Entities.Common.V1;
using Rinzo.Core.Interfaces.Common.V1;
using Rinzo.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Rinzo.Infrastructure.Repositories.Common.V1
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
