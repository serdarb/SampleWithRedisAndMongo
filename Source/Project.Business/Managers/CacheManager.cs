using System;

using ServiceStack.Redis;

namespace Project.Business.Managers
{
    public static class CacheManager
    {
        public static bool Clear()
        {
            using (var redisManager = new PooledRedisClientManager())
            using (var client = redisManager.GetClient())
            {
                var typedClient = client.As<CacheObject>();
                typedClient.FlushAll();
            }
            return true;
        }

        public static bool AddOrUpdateItem(string key, object value)
        {
            using (var redisManager = new PooledRedisClientManager())
            using (var client = redisManager.GetClient())
            {
                var typedClient = client.As<CacheObject>();

                var cacheObject = new CacheObject
                {
                    Key = key,
                    Content = value
                };
                typedClient.SetValue(key, cacheObject);
            }
            return true;
        }

        public static object GetItem(string key)
        {
            using (var redisManager = new PooledRedisClientManager())
            using (var client = redisManager.GetClient())
            {
                var typedClient = client.As<CacheObject>();

                var savedCacheObject = typedClient.GetValue(key);
                return savedCacheObject?.Content;
            }
        }
    }

    public class CacheObject
    {
        public long Id { get; set; }
        public string Key { get; set; }
        public object Content { get; set; }

        public DateTime ExpireTime { get; set; }
        public DateTime AddTime { get; set; }
        public DateTime LastReachTime { get; set; }

        public CacheObject()
        {
            AddTime = DateTime.Now;
        }
    }
}