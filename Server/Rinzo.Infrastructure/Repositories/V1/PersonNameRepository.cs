using Rinzo.Core.Models.Common.V1;
using Rinzo.Core.Entities.Common.V1;
using Rinzo.Core.Interfaces.Common.V1;
using Rinzo.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Rinzo.Infrastructure.Repositories.Common.V1
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
            return await _dbContext
                .PersonNames.Select(e => new PersonNameModel
                {
                    Id = e.Id,
                    FirstName = e.FirstName,
                    MiddleName = e.MiddleName,
                    LastName = e.LastName,
                })
                .ToListAsync();
        }
        #endregion

        #region Retrieve Person ID Asynchronously
        /// <returns>The list of person names by ID.</returns>
        /// <exception cref="Exception">Thrown when there is an error while fetching data from the database.</exception>
        /// <remarks>This method fetches all person names from the database using Entity Framework Core.</remarks>
        public async Task<PersonNameModel> GetByIdAsync(string id)
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
            return person ?? throw new KeyNotFoundException($"PersonName with id {id} not found");
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
