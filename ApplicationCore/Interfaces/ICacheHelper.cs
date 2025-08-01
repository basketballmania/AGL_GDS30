namespace AGL.Api.ApplicationCore.Interfaces
{
    public interface ICacheHelper
    {   
        Task SetAsync<T>(string key, T value) where T : class;
        List<string> GetAllKeysAsync();
        Task<string?> GetStringAsync(string key);
        Task<T?> GetAsync<T>(string key)  where T : class;
        Task RemoveAsync(string key);
        Task RemoveCacheByPrefixAsync(string prefixKey);
        Task RemoveAllCache();
    }
}
