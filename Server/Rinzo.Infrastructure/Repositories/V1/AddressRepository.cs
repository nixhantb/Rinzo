using Rinzo.Core.Models.Common.V1;
using Rinzo.Core.Entities.Common.V1;
using Rinzo.Core.Interfaces.Common.V1;
using Rinzo.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Rinzo.Infrastructure.Repositories.Common.V1
{
    public class AddressRepository : IAddressRepository
    {
        #region Initialization
        // <returns>The list of initializations</returns>
        private readonly BaseDBContext _dbContext;

        public AddressRepository(BaseDBContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        #endregion
        public Task<AddressModel> AddAsync(Address entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        #region Retrieve Address Asynchronously
        /// <returns>The list of Addresses.</returns>
        /// <exception cref="Exception">Thrown when there is an error while fetching data from the database.</exception>
        /// <remarks>This method fetches all Addresses from the database using Entity Framework Core.</remarks>
        public async Task<List<AddressModel>> GetAllAsync()
        {
            return await _dbContext
                .Addresses.Select(e => new AddressModel
                {
                    Id = e.Id,
                    Street = e.Street,
                    City = e.City,
                    State = e.State,
                    PostalCode = e.PostalCode,
                    Country = e.Country,
                })
                .ToListAsync();
        }
        #endregion
        public Task<AddressModel> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Address entity)
        {
            throw new NotImplementedException();
        }
    }
}
