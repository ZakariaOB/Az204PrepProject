using AzureCacheRedis.Entities;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace AzureCacheRedis.Operations
{
    internal class RedisTools
    {
        public static void SetCacheData(ConnectionMultiplexer redis)
        {
            IDatabase database = redis.GetDatabase();

            database.StringSet("top:3:courses", "AZ-104,AZ-305,AZ-204");
            
            Console.WriteLine("Cache data set");
        }

        public static void GetCacheData(ConnectionMultiplexer redis)
        {
            IDatabase database = redis.GetDatabase();
            if (database.KeyExists("top:3:courses"))
            {
                Console.WriteLine(database.StringGet("top:3:courses"));
            }
            else
            {
                Console.WriteLine("key does not exist");
            }
        }

        public static void SetCacheData(ConnectionMultiplexer redis, string userId, int productId, int quantity)
        {
            string key = string.Concat(userId, ":cartitems");

            IDatabase database = redis.GetDatabase();

            CartItem cartItem = new CartItem { ProductId = productId, Quantity = quantity };

            database.ListRightPush(key, JsonConvert.SerializeObject(cartItem));
            
            Console.WriteLine("Cache data set");
        }

        public static void GetCacheData(ConnectionMultiplexer redis, string userId)
        {
            string key = string.Concat(userId, ":cartitems");

            IDatabase database = redis.GetDatabase();
            
            if (database.KeyExists(key))
            {
                long listLength = database.ListLength(key);

                Console.WriteLine("The number of values are {0}", listLength);
                
                for (int i = 0; i < listLength; i++)
                {
                    string value = database.ListGetByIndex(key, i);

                    CartItem cartItem = JsonConvert.DeserializeObject<CartItem>(value);
                    
                    Console.WriteLine("Product ID {0}", cartItem.ProductId);
                    
                    Console.WriteLine("Quantity {0}", cartItem.Quantity);
                }
            }
            else
            {
                Console.WriteLine("key does not exist");
            }
        }
    }
}
