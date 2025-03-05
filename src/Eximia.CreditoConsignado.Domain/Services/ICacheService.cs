﻿namespace Eximia.CreditoConsignado.Domain.Services
{
    public interface ICacheService
    {
        Task SetCacheValueAsync<T>(string key, T value, TimeSpan expiration);
        Task<T?> GetCacheValueAsync<T>(string key);
    }
}
