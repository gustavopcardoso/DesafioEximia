using Eximia.CreditoConsignado.Application.ServiceInterfaces;
using StackExchange.Redis;

namespace Eximia.CreditoConsignado.Cache
{
    public class CacheService(IConnectionMultiplexer _redis) : ICacheService
    {
        public Task<T?> GetCacheValueAsync<T>(string key)
        {
            throw new NotImplementedException();
        }

        public Task SetCacheValueAsync<T>(string key, T value, TimeSpan expiration)
        {
            throw new NotImplementedException();
        }
    }
}
