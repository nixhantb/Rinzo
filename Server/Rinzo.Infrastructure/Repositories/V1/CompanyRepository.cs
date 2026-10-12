using Microsoft.EntityFrameworkCore;
using Rinzo.Core.Entities.Companies.V1;
using Rinzo.Core.Interfaces.Companies.V1;
using Rinzo.Infrastructure.Data.Contexts;

namespace Rinzo.Infrastructure.Repositories.Companies.V1
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly BaseDBContext _dbContext;

        public CompanyRepository(BaseDBContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<Company> AddAsync(Company entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await _dbContext.Companies.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Company>> GetAllAsync()
        {
            return await _dbContext
                .Companies.Include(c => c.Profile)
                .ThenInclude(p => p.ContactEmail)
                .Include(c => c.Profile)
                .ThenInclude(p => p.CompanyAddress)
                .Include(c => c.Profile)
                .ThenInclude(p => p.ContactPhone)
                .Include(c => c.Profile)
                .ThenInclude(p => p.IndustryTypes)
                .ToListAsync();
        }

        public async Task<Company> GetByIdAsync(string id)
        {
            var company = await _dbContext
                .Companies.Where(c => c.Id == id)
                .Include(c => c.Profile)
                .ThenInclude(p => p.ContactEmail)
                .Include(c => c.Profile)
                .ThenInclude(p => p.CompanyAddress)
                .Include(c => c.Profile)
                .ThenInclude(p => p.ContactPhone)
                .Include(c => c.Profile)
                .ThenInclude(p => p.IndustryTypes)
                .FirstOrDefaultAsync();

            return company ?? throw new KeyNotFoundException($"Company with id {id} not found");
        }

        public Task UpdateAsync(Company entity)
        {
            throw new NotImplementedException();
        }
    }
}
