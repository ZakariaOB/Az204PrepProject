using AzureCacheRedis.Operations;
using StackExchange.Redis;

string connectionString = "rediscacheinstance204zz.redis.cache.windows.net:6380,password=JAHrjklCtTlWBaxdBmRvDsw13n10mY1jrAzCaMsQd24=,ssl=True,abortConnect=False";

ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(connectionString);

// RedisTools.SetCacheData(redis);

// RedisTools.GetCacheData(redis);

// RedisTools.SetCacheData(redis, "u1", 10, 100);
// RedisTools.SetCacheData(redis, "u1", 20, 200);
// RedisTools.SetCacheData(redis, "u1", 30, 300);


RedisTools.GetCacheData(redis, "u1");