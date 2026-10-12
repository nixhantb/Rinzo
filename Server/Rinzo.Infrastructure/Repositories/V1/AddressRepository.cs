using System.Data.Common;
using Rinzo.Infrastructure.Caching;
using Rinzo.Core.Models.Common.V1;
using Rinzo.Core.Entities.Common.V1;
using Rinzo.Core.Interfaces.Common.V1;
using Rinzo.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Rinzo.Infrastructure.Repositories.Common.V1
{
    public class AddressRepository : IAddressRepository
    {
        #region Initialization
        // <returns>The list of initializations</returns>
        private readonly BaseDBContext _dbContext;
        private readonly BaseCacheHelper<List<AddressModel>> _cacheHelper;

        public AddressRepository(BaseDBContext dbContext, IMemoryCache memoryCache)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _cacheHelper = new BaseCacheHelper<List<AddressModel>>(memoryCache);
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
            var cacheKey = CacheHelper.CacheKey("RandomKey");
            MemoryCacheEntryOptions cacheOptions = CacheHelper.GetCacheOptions(
                TimeSpan.FromMinutes(1)
            );
            return await _cacheHelper.GetCachedResponse(
                cacheKey,
                async () =>
                {
                    try
                    {
                        var results = await _dbContext
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

                        return results;
                    }
                    catch (Exception ex) when (ex is DbUpdateException || ex is DbException)
                    {
                        throw new Exception(
                            "Error while fetching data from the database. Please try again later."
                        );
                    }
                },
                cacheOptions
            );
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
