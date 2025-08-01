using AGL.Api.ApplicationCore.Interfaces;
using AGL.Api.ApplicationCore.Utilities;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace AGL.Api.ApplicationCore.Helper
{
    public class RedisHelper: ICacheHelper
    {
        private readonly IConnectionMultiplexer _connectionMultiplexer;
        private readonly IDatabase _db;
        private readonly bool _isConnected;

        public RedisHelper(IConnectionMultiplexer connectionMultiplexer, IConfiguration configuration)
        {
            try
            {
                _isConnected = connectionMultiplexer.IsConnected;
                _connectionMultiplexer = connectionMultiplexer;

                var database = configuration.GetValue<int>("Redis:Database");
                _db = connectionMultiplexer.GetDatabase(database);
            }
            catch
            {
                _isConnected = false;
            } 
        }

        private readonly TimeSpan _defaultExpiration = TimeSpan.FromDays(1);

        public async Task SetAsync<T>(string key, T value) where T : class
        {
            if (!_isConnected)
            {
                return;
            }

            try
            {
                string cachedValue = JsonConvert.SerializeObject(value);
                await _db.StringSetAsync(key, cachedValue, _defaultExpiration);
            }
            catch (Exception ex)
            {
                LogService.logCustom($"Redis error in SetAsync: {ex.Message}");
                return;
            }
        }

        public List<string?> GetAllKeysAsync()
        {
            if (!_isConnected)
            {
                return [];
            }

            try
            {
                var server = _connectionMultiplexer.GetServer(_connectionMultiplexer.GetEndPoints().First());
                return server.Keys(database: _db.Database).Select(key => (string)key).ToList();
            }
            catch (Exception ex)
            {
                LogService.logCustom($"Redis error in GetAllKeysAsync: {ex.Message}");
                return [];
            }
        }

        public async Task<string?> GetStringAsync(string key)
        {
            if (!_isConnected)
            {
                return string.Empty;
            }

            try
            {
                string? cachedValue = await _db.StringGetAsync(key);

                return string.IsNullOrEmpty(cachedValue) ? string.Empty : cachedValue;
            }
            catch (Exception ex)
            {
                LogService.logCustom($"Redis error in GetStringAsync: {ex.Message}");
                return string.Empty;
            }
        }

        public async Task<T?> GetAsync<T>(string key) where T : class
        {
            if (!_isConnected)
            {
                return null;
            }

            try
            {
                string? cachedValue = await _db.StringGetAsync(key);

                if (string.IsNullOrEmpty(cachedValue))
                {
                    return null;
                }

                return JsonConvert.DeserializeObject<T>(cachedValue);
            }
            catch (Exception ex)
            {
                LogService.logCustom($"Redis error in GetAsync: {ex.Message}");
                return null;
            }
        }

        public async Task<T?> GetAsync<T>(string key, Func<Task<T>> factory) where T : class
        {
            if (!_isConnected)
            {
                return null;
            }

            try
            {
                var cachedValue = await GetAsync<T>(key);

                if (cachedValue != null)
                {
                    return cachedValue;
                }

                cachedValue = await factory();

                if (cachedValue != null)
                {
                    await SetAsync(key, cachedValue);
                }

                return cachedValue;
            }
            catch (Exception ex)
            {
                LogService.logCustom($"Redis error in GetAsync with factory: {ex.Message}");
                return null;
            }
        }

        public async Task RemoveAsync(string key)
        {
            if (!_isConnected)
            {
                return;
            }

            try
            {
                await _db.KeyDeleteAsync(key);
            }
            catch (Exception ex)
            {
                LogService.logCustom($"Redis error in RemoveAsync: {ex.Message}");
            }
        }

        public async Task RemoveCacheByPrefixAsync(string prefixKey)
        {
            if (!_isConnected)
            {
                return;
            }

            try
            {
                var server = _connectionMultiplexer.GetServer(_connectionMultiplexer.GetEndPoints().First());
                var keysToRemove = server.Keys(pattern: $"{prefixKey}*").ToArray();

                if (keysToRemove.Any())
                {
                    foreach (var key in keysToRemove)
                    {
                        await _db.KeyDeleteAsync(key);
                    }
                }
            }
            catch (Exception ex)
            {
                LogService.logCustom($"Redis error in RemoveCacheByPrefixAsync: {ex.Message}");
            }
        }

        public async Task RemoveAllCache()
        {
            if (!_isConnected)
            {
                return;
            }
            
            try
            {
                var server = _connectionMultiplexer.GetServer(_connectionMultiplexer.GetEndPoints().First());

                // 특정 DB에서만 키 삭제
                var keysToRemove = server.Keys(database: _db.Database).ToArray();
                
                if (keysToRemove.Any())
                {
                    foreach (var key in keysToRemove)
                    {
                        await _db.KeyDeleteAsync(key);
                    }
                }
            }
            catch (Exception ex)
            {
                LogService.logCustom($"Redis error in FlushAllAsync: {ex.Message}");
            }
        }
    }
}