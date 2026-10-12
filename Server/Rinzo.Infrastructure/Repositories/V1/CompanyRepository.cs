using Rinzo.Core.Models.Companies.V1;
using Rinzo.Core.Entities.Companies.V1;
using Rinzo.Core.Interfaces.Companies.V1;
using Rinzo.Infrastructure.Data.Contexts;
using Rinzo.Infrastructure.Mappers.V1;
using Microsoft.EntityFrameworkCore;

namespace Rinzo.Infrastructure.Repositories.Companies.V1
{
    public class CompanyRepository : ICompanyRepository
    {
        #region Initialization
        private readonly BaseDBContext _dbContext;

        #endregion

        public CompanyRepository(BaseDBContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<CompanyModel> AddAsync(Company entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var saveToDb = CompanyMapper.ToCompanyDataBase(entity);
            await _dbContext.Companies.AddAsync(saveToDb);
            await _dbContext.SaveChangesAsync();

            return CompanyMapper.ToCompanyModel(saveToDb);
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CompanyModel>> GetAllAsync()
        {
            var companies = await _dbContext
                .Companies.Include(c => c.Profile)
                .ThenInclude(p => p.ContactEmail)
                .Include(c => c.Profile)
                .ThenInclude(p => p.CompanyAddress)
                .Include(c => c.Profile)
                .ThenInclude(p => p.ContactPhone)
                .Include(c => c.Profile)
                .ThenInclude(p => p.IndustryTypes)
                .ToListAsync();

            return companies.Select(CompanyMapper.ToCompanyModel).ToList();
        }

        public async Task<CompanyModel> GetByIdAsync(string id)
        {
            var company = await _dbContext
                .Companies.Where(c => c.Id.Equals(id))
                .Include(c => c.Profile)
                .ThenInclude(p => p.ContactEmail)
                .Include(c => c.Profile)
                .ThenInclude(p => p.CompanyAddress)
                .Include(c => c.Profile)
                .ThenInclude(p => p.ContactPhone)
                .Include(c => c.Profile)
                .ThenInclude(p => p.IndustryTypes)
                .FirstOrDefaultAsync();

            if (company == null)
            {
                throw new KeyNotFoundException($"Company with id {id} not found");
            }

            return CompanyMapper.ToCompanyModel(company);
        }

        public Task UpdateAsync(Company entity)
        {
            throw new NotImplementedException();
        }
    }
}
