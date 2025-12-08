using System.Data.Common;
using JobLeet.WebApi.JobLeet.Api.Models.Companies.V1;
using JobLeet.WebApi.JobLeet.Core.Entities.Companies.V1;
using JobLeet.WebApi.JobLeet.Core.Interfaces.Companies.V1;
using JobLeet.WebApi.JobLeet.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace JobLeet.WebApi.JobLeetInfrastructure.Repositories.Companies.V1
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
            try
            {
                var response = await _dbContext
                    .IndustryTypes.Select(e => new IndustryModel
                    {
                        Id = e.Id,
                        IndustryType = (JobLeet.Api.Models.Companies.V1.IndustryCategory)
                            e.IndustryType,
                    })
                    .ToListAsync();

                return response;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(
                    "Error while fetching the database. Please try again later" + ex.Message
                );
            }
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
