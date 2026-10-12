using Microsoft.EntityFrameworkCore;
using Rinzo.Core.Entities.Common.V1;
using Rinzo.Core.Interfaces.Common.V1;
using Rinzo.Infrastructure.Data.Contexts;

namespace Rinzo.Infrastructure.Repositories.Common.V1
{
    public class EmailTypeRepository : IEmaiTypeRepository
    {
        private readonly BaseDBContext _dbContext;

        public EmailTypeRepository(BaseDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Email> GetByIdAsync(string id)
        {
            var email = await _dbContext.Emails.FirstOrDefaultAsync(e => e.Id == id);
            return email ?? throw new KeyNotFoundException($"Email with id {id} not found");
        }

        public async Task<List<Email>> GetAllAsync()
        {
            return await _dbContext.Emails.ToListAsync();
        }

        public Task<Email> AddAsync(Email emailType)
        {
            throw new NotSupportedException();
        }

        public Task UpdateAsync(Email emailType)
        {
            throw new NotSupportedException();
        }

        public Task DeleteAsync(string id)
        {
            throw new NotSupportedException();
        }
    }
}
