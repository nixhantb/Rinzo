using System.Data.Common;
using JobLeet.WebApi.JobLeet.Api.Caching;
using JobLeet.WebApi.JobLeet.Api.Models.Common.V1;
using JobLeet.WebApi.JobLeet.Core.Entities.Common.V1;
using JobLeet.WebApi.JobLeet.Core.Interfaces.Common.V1;
using JobLeet.WebApi.JobLeet.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace JobLeet.WebApi.JobLeet.Infrastructure.Repositories.Common.V1
{
    public class ExperienceRepository : IExperienceRepository
    {
        #region Initialization
        // <returns>The list of initializations</returns>
        private readonly BaseDBContext _dbContext;
        private readonly BaseCacheHelper<List<ExperienceModel>> _cacheHelper;

        public ExperienceRepository(BaseDBContext dbContext, IMemoryCache memoryCache)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _cacheHelper = new BaseCacheHelper<List<ExperienceModel>>(memoryCache);
        }
        #endregion
        public Task<ExperienceModel> AddAsync(Experience entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        #region Retrieve Experience Asynchronously
        /// <returns>The list of experiences.</returns>
        /// <exception cref="Exception">Thrown when there is an error while fetching data from the database.</exception>
        /// <remarks>This method fetches all experiences from the database using Entity Framework Core.</remarks>
        public async Task<List<ExperienceModel>> GetAllAsync()
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
                            .Experiences.Select(e => new ExperienceModel
                            {
                                Id = e.Id,
                                ExperienceLevel = (Api.Models.Common.V1.ExperienceLevel)
                                    e.ExperienceLevel,
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

        #region Retrieve Experience ID Asynchronously
        /// <returns>The list of experience Id's.</returns>
        /// <exception cref="Exception">Thrown when there is an error while fetching data from the database.</exception>
        /// <remarks>This method fetches all experience Id's from the database using Entity Framework Core.</remarks>
        public Task<ExperienceModel> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }
        #endregion
        public Task UpdateAsync(Experience entity)
        {
            throw new NotImplementedException();
        }
    }
}
