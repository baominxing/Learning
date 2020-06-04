using System;
using System.Runtime.Caching;

namespace FileCenter.Common
{
    public partial class MemoryCacheManager
    {
        #region Methods
        public T Get<T>(string key)
        {
            return (T)MemoryCache.Default[key];
        }

        /// <summary>
        /// 设置缓存，并且设置过期时间，按秒计算
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="cacheTime"></param>
        /// <param name="slidingExpiration"></param>
        public void Set<T>(string key, T value, int? cacheTime = null, int? slidingExpiration = null)
        {
            if (value == null)
            {
                return;
            }
            var policy = new CacheItemPolicy();
            if (cacheTime.HasValue)
            {
                policy.AbsoluteExpiration = DateTime.Now + TimeSpan.FromSeconds(cacheTime.Value);
            }
            if (slidingExpiration.HasValue)
            {
                policy.SlidingExpiration = TimeSpan.FromSeconds(slidingExpiration.Value);
            }
            policy.Priority = CacheItemPriority.Default;
            MemoryCache.Default.Add(new CacheItem(key, value), policy);
        }

        public bool IsSet(string key)
        {
            return (MemoryCache.Default.Contains(key));
        }


        public void Remove(string key)
        {
            MemoryCache.Default.Remove(key);
        }

        public void Clear()
        {
            foreach (var item in MemoryCache.Default)
            {
                Remove(item.Key);
            }
        }
        #endregion
    }
}