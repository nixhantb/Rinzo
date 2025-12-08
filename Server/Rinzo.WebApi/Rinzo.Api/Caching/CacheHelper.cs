using Microsoft.Extensions.Caching.Memory;

namespace JobLeet.WebApi.JobLeet.Api.Caching
{
    public static class CacheHelper
    {
        public static string CacheKey(string keyName)
        {
            return $"{keyName} _CacheKey";
        }

        public static MemoryCacheEntryOptions GetCacheOptions(TimeSpan expirationTime)
        {
            return new MemoryCacheEntryOptions { AbsoluteExpirationRelativeToNow = expirationTime };
        }
    }
}
