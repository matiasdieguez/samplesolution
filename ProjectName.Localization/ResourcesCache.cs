using System;
using System.Configuration;
using System.Runtime.Caching;
using ProjectName.Common;
using ProjectName.Common.Configuration;
using ProjectName.Common.Cache;

namespace ProjectName.Localization
{
    public class ResourcesCache : ICacheService
    {
        public T GetOrSet<T>(string cacheKey, Func<T> getItemCallback) where T : class
        {
            if (!(MemoryCache.Default.Get(cacheKey) is T item))
            {
                item = getItemCallback();

                var expiration = Convert.ToInt32(ConfigurationManager.AppSettings["AppConfig:ResourcesCacheExpirationMinutes"]);
                MemoryCache.Default.Add(cacheKey, item, DateTime.Now.AddMinutes(expiration));
            }
            return item;
        }
    }
}