using System.Collections.Concurrent;
using AGL.Api.ApplicationCore.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace AGL.Api.ApplicationCore.Helper
{
    public class CacheHelper : ICacheHelper
    {
        private readonly IMemoryCache _memoryCache;
        private readonly MemoryCacheEntryOptions _cacheEntryOptions;
        private static readonly ConcurrentDictionary<string, bool> CacheKeys = new();

        public CacheHelper(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
            _cacheEntryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(1),
            };
        }

        public async Task SetAsync<T>(string cacheKey, T value) where T : class
        {
            try 
            {
                string cachedValue = JsonConvert.SerializeObject(value);
                _memoryCache.Set(cacheKey, cachedValue, _cacheEntryOptions);
                CacheKeys.TryAdd(cacheKey, false);
            } 
            catch(Exception e) 
            {
                throw new Exception(e.Message);
            }
        }

        public List<string> GetAllKeysAsync()
        {
            return CacheKeys.Keys.ToList();
        }

        public async Task<string?> GetStringAsync(string cacheKey)
        {
            if (_memoryCache.TryGetValue(cacheKey, out string? jsonData))
            {
                return jsonData;
            }

            return null;
        }

        public Task<T?> GetAsync<T>(string key) where T : class
        {
            if (_memoryCache.TryGetValue(key, out string? jsonData))
            {
                if (!string.IsNullOrEmpty(jsonData))
                {
                    var value = JsonConvert.DeserializeObject<T>(jsonData);
                    return Task.FromResult(value);
                }
            }
            return Task.FromResult<T?>(default);
        }

        public async Task RemoveAsync(string cacheKey)
        {
            _memoryCache.Remove(cacheKey);
            CacheKeys.TryRemove(cacheKey, out _);
        }

        public async Task RemoveCacheByPrefixAsync(string prefixKey)
        {
            var keysToRemove = CacheKeys.Keys.Where(x => x.StartsWith(prefixKey)).ToList();

            foreach (var key in keysToRemove)
            {
                await RemoveAsync(key);
            }
        }

        public async Task RemoveAllCache()
        {
            foreach (var key in CacheKeys.Keys)
            {
                await RemoveAsync(key);
            }
        }
    }
}
