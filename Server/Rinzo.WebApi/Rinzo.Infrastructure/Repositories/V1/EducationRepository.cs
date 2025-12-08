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
    public class EducationRepository : IEducationRepository
    {
        #region Initialization
        // <returns>The list of initializations</returns>
        private readonly BaseDBContext _dbContext;
        private readonly BaseCacheHelper<List<EducationModel>> _cacheHelper;

        public EducationRepository(BaseDBContext dbContext, IMemoryCache memoryCache)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _cacheHelper = new BaseCacheHelper<List<EducationModel>>(memoryCache);
        }
        #endregion
        public Task<EducationModel> AddAsync(Education entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        #region Retrieve Education Asynchronously
        /// <returns>The list of educations.</returns>
        /// <exception cref="Exception">Thrown when there is an error while fetching data from the database.</exception>
        /// <remarks>This method fetches all educations from the database using Entity Framework Core.</remarks>
        public async Task<List<EducationModel>> GetAllAsync()
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
                            .Educations.Select(e => new EducationModel
                            {
                                Id = e.Id,
                                Degree = e.Degree,
                                Major = e.Major,
                                Institution = e.Institution,
                                GraduationDate = e.GraduationDate,
                                Cgpa = e.Cgpa,
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

        public Task<EducationModel> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Education entity)
        {
            throw new NotImplementedException();
        }
    }
}
