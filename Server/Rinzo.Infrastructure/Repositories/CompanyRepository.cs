using Microsoft.EntityFrameworkCore;
using Rinzo.Core.Entities.Companies;
using Rinzo.Core.Interfaces.Companies;
using Rinzo.Infrastructure.Data.Contexts;

namespace Rinzo.Infrastructure.Repositories.Companies
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly BaseDBContext _dbContext;

        public CompanyRepository(BaseDBContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        // Shared by GetAllAsync/GetByIdAsync so the two can't silently drift apart.
        // All single-reference includes (Profile -> one of each) - no collections here,
        // so there's no cartesian-explosion risk to worry about in this one.
        private IQueryable<Company> CompaniesWithProfile() =>
            _dbContext
                .Companies.Include(c => c.Profile)
                .ThenInclude(p => p.ContactEmail)
                .Include(c => c.Profile)
                .ThenInclude(p => p.CompanyAddress)
                .Include(c => c.Profile)
                .ThenInclude(p => p.ContactPhone)
                .Include(c => c.Profile)
                .ThenInclude(p => p.IndustryTypes);

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
            return await CompaniesWithProfile().ToListAsync();
        }

        public async Task<Company> GetByIdAsync(string id)
        {
            var company = await CompaniesWithProfile().FirstOrDefaultAsync(c => c.Id == id);

            return company ?? throw new KeyNotFoundException($"Company with id {id} not found");
        }

        public Task UpdateAsync(Company entity)
        {
            throw new NotImplementedException();
        }
    }
}
