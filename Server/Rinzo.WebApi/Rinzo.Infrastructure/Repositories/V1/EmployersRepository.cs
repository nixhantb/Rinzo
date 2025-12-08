using JobLeet.WebApi.JobLeet.Api.Models.Employers.V1;
using JobLeet.WebApi.JobLeet.Core.Entities.Employers.V1;
using JobLeet.WebApi.JobLeet.Core.Interfaces.Employers.V1;
using JobLeet.WebApi.JobLeet.Infrastructure.Data.Contexts;
using JobLeet.WebApi.JobLeet.Mappers.V1;
using Microsoft.EntityFrameworkCore;

namespace JobLeet.WebApi.JobLeetInfrastructure.Repositories.Employers.V1
{
    public class EmployersRepository : IEmployerRepository
    {
        #region Initialization
        // <returns>The list of initializations</returns>
        private readonly BaseDBContext _dbContext;

        public EmployersRepository(BaseDBContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        #endregion
        public async Task<EmployerModel> AddAsync(Employer entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException(nameof(entity));
                }

                var saveToDb = EmployerMapper.ToEmployer(entity);
                await _dbContext.Employers.AddAsync(saveToDb);
                await _dbContext.SaveChangesAsync();

                var apiResponse = EmployerMapper.ToEmployerModel(saveToDb);

                return apiResponse;
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding employers ", ex);
            }
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<EmployerModel>> GetAllAsync()
        {
            try
            {
                var employers = await _dbContext.Employers.ToListAsync();
                return employers.Select(EmployerMapper.ToEmployerModel).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error Retriving Employers", ex);
            }
        }

        public Task<EmployerModel> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Employer entity)
        {
            throw new NotImplementedException();
        }
    }
}
