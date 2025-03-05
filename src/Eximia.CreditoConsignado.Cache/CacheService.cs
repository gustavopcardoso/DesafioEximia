using Eximia.CreditoConsignado.Domain.Services;
using StackExchange.Redis;
using System.Text.Json;

namespace Eximia.CreditoConsignado.Cache
{
    public class CacheService(IConnectionMultiplexer _redis) : ICacheService
    {
        public async Task<T?> GetCacheValueAsync<T>(string key)
        {
            var db = _redis.GetDatabase();
            var json = await db.StringGetAsync(key);
            return json.HasValue ? JsonSerializer.Deserialize<T>(json.ToString()) : default;
        }

        public async Task SetCacheValueAsync<T>(string key, T value, TimeSpan expiration)
        {
            var db = _redis.GetDatabase();
            var json = JsonSerializer.Serialize(value);
            await db.StringSetAsync(key, json, expiration);
        }
    }
}
