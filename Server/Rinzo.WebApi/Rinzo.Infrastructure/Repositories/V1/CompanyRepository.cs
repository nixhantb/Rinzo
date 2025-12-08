using JobLeet.WebApi.JobLeet.Api.Models.Companies.V1;
using JobLeet.WebApi.JobLeet.Core.Entities.Companies.V1;
using JobLeet.WebApi.JobLeet.Core.Interfaces.Companies.V1;
using JobLeet.WebApi.JobLeet.Infrastructure.Data.Contexts;
using JobLeet.WebApi.JobLeet.Mappers.V1;
using Microsoft.EntityFrameworkCore;

namespace JobLeet.WebApi.JobLeetInfrastructure.Repositories.Companies.V1
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
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException(nameof(entity));
                }

                var saveToDb = CompanyMapper.ToCompanyDataBase(entity);
                await _dbContext.Companies.AddAsync(saveToDb);
                await _dbContext.SaveChangesAsync();

                var apiResponse = CompanyMapper.ToCompanyModel(saveToDb);
                return apiResponse;
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding company", ex);
            }
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CompanyModel>> GetAllAsync()
        {
            try
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
            catch (Exception ex)
            {
                throw new Exception("Error Retriving company", ex);
            }
        }

        public async Task<CompanyModel> GetByIdAsync(string id)
        {
            try
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
                var companyModel = CompanyMapper.ToCompanyModel(company);
                return companyModel;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving company by id", ex);
            }
        }

        public Task UpdateAsync(Company entity)
        {
            throw new NotImplementedException();
        }
    }
}
