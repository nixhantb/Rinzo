using Rinzo.Core.Models.Common.V1;
using Rinzo.Core.Entities.Common.V1;
using Rinzo.Core.Interfaces.Common.V1;
using Rinzo.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Rinzo.Infrastructure.Repositories.Common.V1
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
            return await _dbContext
                .Phones.Select(e => new PhoneModel
                {
                    Id = e.Id,
                    CountryCode = e.CountryCode,
                    PhoneNumber = e.PhoneNumber,
                })
                .ToListAsync();
        }
        #endregion
        #region Retrieve Phone ID Asynchronously
        /// <returns>The list of phones by ID.</returns>
        /// <exception cref="Exception">Thrown when there is an error while fetching data from the database.</exception>
        /// <remarks>This method fetches the Phone from the database using Entity Framework Core.</remarks>
        public async Task<PhoneModel> GetByIdAsync(string id)
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
            return phone ?? throw new KeyNotFoundException($"Phone with id {id} not found");
        }
        #endregion
        public Task UpdateAsync(Phone entity)
        {
            throw new NotImplementedException();
        }
    }
}
