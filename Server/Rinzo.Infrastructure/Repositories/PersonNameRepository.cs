using Microsoft.EntityFrameworkCore;
using Rinzo.Core.Entities.Common;
using Rinzo.Core.Interfaces.Common;
using Rinzo.Infrastructure.Data.Contexts;

namespace Rinzo.Infrastructure.Repositories.Common
{
    public class PersonNameRepository : IPersonNameRepository
    {
        private readonly BaseDBContext _dbContext;

        public PersonNameRepository(BaseDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<PersonName>> GetAllAsync()
        {
            return await _dbContext.PersonNames.ToListAsync();
        }

        public async Task<PersonName> GetByIdAsync(string id)
        {
            var person = await _dbContext.PersonNames.FirstOrDefaultAsync(e => e.Id == id);
            return person ?? throw new KeyNotFoundException($"PersonName with id {id} not found");
        }

        public Task<PersonName> AddAsync(PersonName entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(PersonName entity)
        {
            throw new NotImplementedException();
        }
    }
}
