using Microsoft.Extensions.Caching.Memory;

namespace JobLeet.WebApi.JobLeet.Api.Caching
{
    public class BaseCacheHelper<T>
    {
        protected readonly SemaphoreSlim Semaphore = new SemaphoreSlim(1, 1);
        protected readonly IMemoryCache Cache;

        public BaseCacheHelper(IMemoryCache memoryCache)
        {
            Cache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
        }

        public async Task<T> GetCachedResponse(
            string cacheKey,
            Func<Task<T>> dataRetrivalFunction,
            MemoryCacheEntryOptions cacheOptions
        )
        {
            if (string.IsNullOrWhiteSpace(cacheKey))
            {
                throw new ArgumentException("Cache key cannot be null or empty");
            }

            if (dataRetrivalFunction == null)
            {
                throw new ArgumentNullException(nameof(cacheOptions));
            }

            if (cacheOptions == null)
            {
                throw new ArgumentNullException(nameof(cacheOptions));
            }

            if (Cache.TryGetValue(cacheKey, out T cachedData))
            {
                return cachedData;
            }

            await Semaphore.WaitAsync();
            try
            {
                if (Cache.TryGetValue(cacheKey, out cachedData))
                {
                    return cachedData;
                }
                cachedData = await dataRetrivalFunction();
                if (cachedData != null)
                {
                    Cache.Set(cacheKey, cachedData, cacheOptions);
                }
            }
            finally
            {
                Semaphore.Release();
            }

            return cachedData;
        }
    }
}
