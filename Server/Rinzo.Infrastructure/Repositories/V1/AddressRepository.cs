using Microsoft.EntityFrameworkCore;
using Rinzo.Core.Entities.Common.V1;
using Rinzo.Core.Interfaces.Common.V1;
using Rinzo.Infrastructure.Data.Contexts;

namespace Rinzo.Infrastructure.Repositories.Common.V1
{
    public class AddressRepository : IAddressRepository
    {
        private readonly BaseDBContext _dbContext;

        public AddressRepository(BaseDBContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public Task<Address> AddAsync(Address entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Address>> GetAllAsync()
        {
            return await _dbContext.Addresses.ToListAsync();
        }

        public Task<Address> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Address entity)
        {
            throw new NotImplementedException();
        }
    }
}
