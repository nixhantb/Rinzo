using System.Data.Common;
using JobLeet.WebApi.JobLeet.Api.Models.Common.V1;
using JobLeet.WebApi.JobLeet.Core.Entities.Common.V1;
using JobLeet.WebApi.JobLeet.Core.Interfaces.Common.V1;
using JobLeet.WebApi.JobLeet.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace JobLeet.WebApi.JobLeet.Infrastructure.Repositories.Common.V1
{
    public class PhoneRepository : IPhoneRepository
    {
        #region Initialization
        // <returns>The list of initializations</returns>
        private readonly BaseDBContext _dbContext;

        public PhoneRepository(BaseDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion
        public Task<PhoneModel> AddAsync(Phone entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        #region Retrieve Phones Asynchronously
        /// <returns>The list of phones.</returns>
        /// <exception cref="Exception">Thrown when there is an error while fetching data from the database.</exception>
        /// <remarks>This method fetches the Phones from the database using Entity Framework Core.</remarks>
        public async Task<List<PhoneModel>> GetAllAsync()
        {
            try
            {
                var result = await _dbContext
                    .Phones.Select(e => new PhoneModel
                    {
                        Id = e.Id,
                        CountryCode = e.CountryCode,
                        PhoneNumber = e.PhoneNumber,
                    })
                    .ToListAsync();
                return result;
            }
            catch (Exception ex) when (ex is DbUpdateException || ex is DbException)
            {
                throw new Exception(
                    "Error while fetching data from the database. Please try again later."
                );
            }
        }
        #endregion
        #region Retrieve Phone ID Asynchronously
        /// <returns>The list of phones by ID.</returns>
        /// <exception cref="Exception">Thrown when there is an error while fetching data from the database.</exception>
        /// <remarks>This method fetches the Phone from the database using Entity Framework Core.</remarks>
        public async Task<PhoneModel> GetByIdAsync(string id)
        {
            try
            {
                var phone = await _dbContext
                    .Phones.Where(e => e.Id == id)
                    .Select(e => new PhoneModel
                    {
                        Id = e.Id,
                        CountryCode = e.CountryCode,
                        PhoneNumber = e.PhoneNumber,
                    })
                    .FirstOrDefaultAsync();
                return phone == null
                    ? throw new KeyNotFoundException($"Phone with id {id} not found")
                    : phone;
            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"An Error occured while fetching a phone with id: {id}: {ex.Message}"
                );
            }
        }
        #endregion
        public Task UpdateAsync(Phone entity)
        {
            throw new NotImplementedException();
        }
    }
}
