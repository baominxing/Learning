using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;

namespace CacheHelper
{
    /// <summary>
    /// 自定义字典缓存帮助类
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public class SynchronisedDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private Dictionary<TKey, TValue> innerDict; // 缓存内容
        private ReaderWriterLockSlim readWriteLock; // 读写锁

        /// <summary>
        /// 初始化构造函数
        /// </summary>
        /// <param name="dic"></param>
        public SynchronisedDictionary(Dictionary<TKey, TValue> dic)
        {
            this.readWriteLock = new ReaderWriterLockSlim();
            this.innerDict = dic ?? new Dictionary<TKey, TValue>();
        }

        /// <summary>
        /// 使用lambda初始化构造函数
        /// </summary>
        /// <param name="getKey"></param>
        /// <param name="list"></param>
        public SynchronisedDictionary(Func<TValue, TKey> getKey, List<TValue> list)
        {
            this.readWriteLock = new ReaderWriterLockSlim();
            this.innerDict = new Dictionary<TKey, TValue>();

            if (list != null && list.Count > 0)
            {
                foreach (var item in list)
                {
                    var key = getKey(item);
                    if (this.innerDict.ContainsKey(key))
                    {
                        this.innerDict[key] = item;
                    }
                    else
                    {
                        this.innerDict.Add(getKey(item), item);
                    }
                }
            }
        }

        /// <summary>
        /// 同步缓存
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="value">缓存值</param>
        /// <param name="del">是否删除</param>
        /// <remarks>
        /// 新增:SyncCache(Id,Value,false)
        /// 修改:SyncCache(Id,Value,false)
        /// 删除:SyncCache(Id,null,true)
        /// </remarks>
        public void SyncCache(TKey key, TValue value, bool del = false)
        {
            if (del)
            {
                Remove(key);
            }
            else
            {
                this[key] = value;
            }
        }

        /// <summary>
        /// 通过KeyValuePair新增缓存（建议使用SyncCache方法）
        /// </summary>
        /// <param name="item">KeyValuePair键值对</param>
        public void Add(KeyValuePair<TKey, TValue> item)
        {
            using (new AcquireWriteLock(this.readWriteLock))
            {
                this.innerDict[item.Key] = item.Value;
            }
        }

        /// <summary>
        /// 根据Key，Value新增缓存（建议使用SyncCache方法）
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="value">缓存值</param>
        public void Add(TKey key, TValue value)
        {
            using (new AcquireWriteLock(this.readWriteLock))
            {
                this.innerDict[key] = value;
            }
        }

        /// <summary>
        /// 移除缓存（建议使用SyncCache方法）
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Remove(TKey key)
        {
            bool isRemoved;
            using (new AcquireWriteLock(this.readWriteLock))
            {
                isRemoved = this.innerDict.Remove(key);
            }
            return isRemoved;
        }

        /// <summary>
        /// 移除缓存（建议使用SyncCache方法）
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            using (new AcquireWriteLock(this.readWriteLock))
            {
                return this.innerDict.Remove(item.Key);
            }
        }

        /// <summary>
        /// 清空所有缓存
        /// </summary>
        public void Clear()
        {
            using (new AcquireWriteLock(this.readWriteLock))
            {
                this.innerDict.Clear();
            }
        }

        /// <summary>
        /// 是否包含指定元素
        /// </summary>
        /// <param name="item">KeyValuePair键值对</param>
        /// <returns></returns>
        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            using (new AcquireReadLock(this.readWriteLock))
            {
                return this.innerDict.Contains<KeyValuePair<TKey, TValue>>(item);
            }
        }

        /// <summary>
        /// 是否包含指定的键
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool ContainsKey(TKey key)
        {
            using (new AcquireReadLock(this.readWriteLock))
            {
                return this.innerDict.ContainsKey(key);
            }
        }

        /// <summary>
        /// copy到指定Array中
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            using (new AcquireReadLock(this.readWriteLock))
            {
                this.innerDict.ToArray<KeyValuePair<TKey, TValue>>().CopyTo(array, arrayIndex);
            }
        }

        /// <summary>
        /// 获取枚举数
        /// 可用foreach
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            using (new AcquireReadLock(this.readWriteLock))
            {
                return this.innerDict.GetEnumerator();
            }
        }

        IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
        {
            using (new AcquireReadLock(this.readWriteLock))
            {
                return this.innerDict.GetEnumerator();
            }
        }

        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="value">缓存值</param>
        /// <returns></returns>
        public bool TryGetValue(TKey key, out TValue value)
        {
            using (new AcquireReadLock(this.readWriteLock))
            {
                return this.innerDict.TryGetValue(key, out value);
            }
        }

        /// <summary>
        /// 获取缓存的所有KEY
        /// </summary>
        public ICollection<TKey> Keys
        {
            get
            {
                using (new AcquireReadLock(this.readWriteLock))
                {
                    return this.innerDict.Keys;
                }
            }
        }

        /// <summary>
        /// 获取缓存的所有VALUE
        /// </summary>
        public ICollection<TValue> Values
        {
            get
            {
                using (new AcquireReadLock(this.readWriteLock))
                {
                    return this.innerDict.Values;
                }
            }
        }

        /// <summary>
        /// 获取缓存长度
        /// </summary>
        public int Count
        {
            get
            {
                using (new AcquireReadLock(this.readWriteLock))
                {
                    return this.innerDict.Count;
                }
            }
        }

        /// <summary>
        /// TValue属性读写
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public TValue this[TKey key]
        {
            get
            {
                using (new AcquireReadLock(this.readWriteLock))
                {
                    return this.innerDict[key];
                }
            }
            set
            {
                using (new AcquireWriteLock(this.readWriteLock))
                {
                    this.innerDict[key] = value;
                }
            }
        }

        /// <summary>
        /// 是否只读
        /// </summary>
        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }
    }

    /// <summary>
    /// 自定义列表缓存帮助类
    /// </summary>
    /// <typeparam name="TValue"></typeparam>
    public class SynchronisedList<TValue> : IList<TValue>
    {
        private List<TValue> innerList; // 缓存内容
        private ReaderWriterLockSlim readWriteLock; // 读写锁

        /// <summary>
        /// 初始化构造函数
        /// </summary>
        /// <param name="list"></param>
        public SynchronisedList(IEnumerable<TValue> list)
        {
            innerList = new List<TValue>();
            readWriteLock = new ReaderWriterLockSlim();
            if (list != null && list.Count() > 0)
            {
                this.innerList.AddRange(list);
            }
        }

        /// <summary>
        /// 获取缓存内容列表
        /// </summary>
        /// <returns></returns>
        public List<TValue> GetList()
        {
            return this.innerList;
        }

        /// <summary>
        /// 获取索引
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int IndexOf(TValue item)
        {
            using (new AcquireReadLock(this.readWriteLock))
            {
                return innerList.IndexOf(item);
            }
        }

        /// <summary>
        /// 根据索引插入值
        /// </summary>
        /// <param name="index"></param>
        /// <param name="item"></param>
        public void Insert(int index, TValue item)
        {
            using (new AcquireWriteLock(this.readWriteLock))
            {
                innerList.Insert(index, item);
            }
        }

        /// <summary>
        /// 根据索引移除值
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            using (new AcquireWriteLock(this.readWriteLock))
            {
                innerList.RemoveAt(index);
            }
        }

        /// <summary>
        /// TValue属性读写
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public TValue this[int index]
        {
            get
            {
                using (new AcquireReadLock(this.readWriteLock))
                {
                    return innerList[index];
                }
            }
            set
            {
                using (new AcquireWriteLock(this.readWriteLock))
                {
                    innerList[index] = value;
                }
            }
        }

        /// <summary>
        /// 插入值
        /// </summary>
        /// <param name="item"></param>
        public void Add(TValue item)
        {
            using (new AcquireWriteLock(this.readWriteLock))
            {
                innerList.Add(item);
            }
        }

        /// <summary>
        /// 清除缓存
        /// </summary>
        public void Clear()
        {
            using (new AcquireWriteLock(this.readWriteLock))
            {
                innerList.Clear();
            }
        }

        /// <summary>
        /// 是否包含
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(TValue item)
        {
            using (new AcquireReadLock(this.readWriteLock))
            {
                return innerList.Contains(item);
            }
        }

        /// <summary>
        /// copy到指定Array中
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        public void CopyTo(TValue[] array, int arrayIndex)
        {
            using (new AcquireReadLock(this.readWriteLock))
            {
                innerList.CopyTo(array, arrayIndex);
            }
        }

        /// <summary>
        /// 获取缓存长度
        /// </summary>
        public int Count
        {
            get
            {
                using (new AcquireReadLock(this.readWriteLock))
                {
                    return innerList.Count;
                }
            }
        }

        /// <summary>
        /// 只读属性
        /// </summary>
        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// 移除值
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Remove(TValue item)
        {
            using (new AcquireWriteLock(this.readWriteLock))
            {
                return innerList.Remove(item);
            }
        }

        /// <summary>
        /// 获取枚举数
        /// 可用foreach
        /// </summary>
        /// <returns></returns>
        public IEnumerator<TValue> GetEnumerator()
        {
            using (new AcquireReadLock(this.readWriteLock))
            {
                return innerList.GetEnumerator();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            using (new AcquireReadLock(this.readWriteLock))
            {
                return innerList.GetEnumerator();
            }
        }
    }

    class AcquireReadLock : IDisposable
    {
        private ReaderWriterLockSlim rwLock;
        private bool disposedValue;

        public AcquireReadLock(ReaderWriterLockSlim rwLock)
        {
            this.rwLock = new ReaderWriterLockSlim();
            this.disposedValue = false;
            this.rwLock = rwLock;
            this.rwLock.EnterReadLock();
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue && disposing)
            {
                this.rwLock.ExitReadLock();
            }
            this.disposedValue = true;
        }
    }

    class AcquireWriteLock : IDisposable
    {
        private ReaderWriterLockSlim rwLock;
        private bool disposedValue;

        public AcquireWriteLock(ReaderWriterLockSlim rwLock)
        {
            this.rwLock = new ReaderWriterLockSlim();
            this.disposedValue = false;
            this.rwLock = rwLock;
            this.rwLock.EnterWriteLock();
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue && disposing)
            {
                this.rwLock.ExitWriteLock();
            }
            this.disposedValue = true;
        }
    }

    /// <summary>
    /// 内存缓存帮助类，支持绝对过期时间、滑动过期时间、文件依赖三种缓存方式。
    /// </summary>
    class MemoryCacheHelper
    {
        private static readonly object _locker1 = new object(), _locker2 = new object();

        /// <summary>
        /// 取缓存项，如果不存在则返回空。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T GetCacheItem<T>(string key)
        {
            try
            {
                return (T)MemoryCache.Default[key];
            }
            catch
            {
                return default(T);
            }
        }

        /// <summary>
        /// 是否包含指定键的缓存项
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool Contains(string key)
        {
            return MemoryCache.Default.Contains(key);
        }

        /// <summary>
        /// 取缓存项，如果不存在则新增缓存项。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="cachePopulate"></param>
        /// <param name="slidingExpiration"></param>
        /// <param name="absoluteExpiration"></param>
        /// <returns></returns>
        public static T GetOrAddCacheItem<T>(string key, Func<T> cachePopulate, TimeSpan? slidingExpiration = null, DateTime? absoluteExpiration = null)
        {
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentException("Invalid cache key");
            if (cachePopulate == null) throw new ArgumentNullException("cachePopulate");
            if (slidingExpiration == null && absoluteExpiration == null) throw new ArgumentException("Either a sliding expiration or absolute must be provided");

            if (MemoryCache.Default[key] == null)
            {
                lock (_locker1)
                {
                    if (MemoryCache.Default[key] == null)
                    {
                        T cacheValue = cachePopulate();
                        if (!typeof(T).IsValueType && cacheValue == null)   //如果是引用类型且为NULL则不存缓存
                        {
                            return cacheValue;
                        }

                        var item = new CacheItem(key, cacheValue);
                        var policy = CreatePolicy(slidingExpiration, absoluteExpiration);

                        MemoryCache.Default.Add(item, policy);
                    }
                }
            }

            return (T)MemoryCache.Default[key];
        }

        /// <summary>
        /// 取缓存项，如果不存在则新增缓存项。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="cachePopulate"></param>
        /// <param name="dependencyFilePath"></param>
        /// <returns></returns>
        public static T GetOrAddCacheItem<T>(string key, Func<T> cachePopulate, string dependencyFilePath)
        {
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentException("Invalid cache key");
            if (cachePopulate == null) throw new ArgumentNullException("cachePopulate");

            if (MemoryCache.Default[key] == null)
            {
                lock (_locker2)
                {
                    if (MemoryCache.Default[key] == null)
                    {
                        T cacheValue = cachePopulate();
                        if (!typeof(T).IsValueType && cacheValue == null)   //如果是引用类型且为NULL则不存缓存
                        {
                            return cacheValue;
                        }

                        var item = new CacheItem(key, cacheValue);
                        var policy = CreatePolicy(dependencyFilePath);

                        MemoryCache.Default.Add(item, policy);
                    }
                }
            }

            return (T)MemoryCache.Default[key];
        }

        /// <summary>
        /// 指定缓存项的一组逐出和过期详细信息
        /// </summary>
        /// <param name="slidingExpiration"></param>
        /// <param name="absoluteExpiration"></param>
        /// <returns></returns>
        private static CacheItemPolicy CreatePolicy(TimeSpan? slidingExpiration, DateTime? absoluteExpiration)
        {
            var policy = new CacheItemPolicy();

            if (absoluteExpiration.HasValue)
            {
                policy.AbsoluteExpiration = absoluteExpiration.Value;
            }
            else if (slidingExpiration.HasValue)
            {
                policy.SlidingExpiration = slidingExpiration.Value;
            }

            policy.Priority = CacheItemPriority.Default;

            return policy;
        }

        /// <summary>
        /// 指定缓存项的一组逐出和过期详细信息
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        private static CacheItemPolicy CreatePolicy(string filePath)
        {
            CacheItemPolicy policy = new CacheItemPolicy();
            policy.ChangeMonitors.Add(new HostFileChangeMonitor(new List<string>() { filePath }));
            policy.Priority = CacheItemPriority.Default;
            return policy;
        }

        /// <summary>
        /// 移除指定键的缓存项
        /// </summary>
        /// <param name="key"></param>
        public static void RemoveCacheItem(string key)
        {
            if (Contains(key))
            {
                MemoryCache.Default.Remove(key);
            }
        }
    }
}