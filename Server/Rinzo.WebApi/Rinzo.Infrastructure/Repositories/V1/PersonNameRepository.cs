using System.Data.Common;
using JobLeet.WebApi.JobLeet.Api.Models.Common.V1;
using JobLeet.WebApi.JobLeet.Core.Entities.Common.V1;
using JobLeet.WebApi.JobLeet.Core.Interfaces.Common.V1;
using JobLeet.WebApi.JobLeet.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace JobLeet.WebApi.JobLeet.Infrastructure.Repositories.Common.V1
{
    public class PersonNameRepository : IPersonNameRepository
    {
        #region Initialization
        // <returns>The list of initializations</returns>
        private readonly BaseDBContext _dbContext;

        public PersonNameRepository(BaseDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        #region Retrieve Person Asynchronously
        /// <returns>The list of person names.</returns>
        /// <exception cref="Exception">Thrown when there is an error while fetching data from the database.</exception>
        /// <remarks>This method fetches all person names from the database using Entity Framework Core.</remarks>
        public async Task<List<PersonNameModel>> GetAllAsync()
        {
            try
            {
                var result = await _dbContext
                    .PersonNames.Select(e => new PersonNameModel
                    {
                        Id = e.Id,
                        FirstName = e.FirstName,
                        MiddleName = e.MiddleName,
                        LastName = e.LastName,
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

        #region Retrieve Person ID Asynchronously
        /// <returns>The list of person names by ID.</returns>
        /// <exception cref="Exception">Thrown when there is an error while fetching data from the database.</exception>
        /// <remarks>This method fetches all person names from the database using Entity Framework Core.</remarks>
        public async Task<PersonNameModel> GetByIdAsync(string id)
        {
            try
            {
                var person = await _dbContext
                    .PersonNames.Where(e => e.Id == id)
                    .Select(e => new PersonNameModel
                    {
                        Id = e.Id,
                        FirstName = e.FirstName,
                        MiddleName = e.MiddleName,
                        LastName = e.LastName,
                    })
                    .FirstOrDefaultAsync();
                return person == null
                    ? throw new KeyNotFoundException($"PersonName with id {id} not found")
                    : person;
            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"An Error occured while fetching a person with id: {id}: {ex.Message}"
                );
            }
        }
        #endregion
        public Task<PersonNameModel> AddAsync(PersonName entity)
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
