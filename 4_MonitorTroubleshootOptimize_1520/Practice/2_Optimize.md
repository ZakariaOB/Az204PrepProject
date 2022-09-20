- Cache Redis
 - In momory cache to store the most frequently accessed data
 - Azure cash for redis in just an implementation on Azure
 - Example : Top 10 courses for the day
 - How to interact with Redis : AzureCacheRedis

- Cache redis practice
  - lrange ul:cartitems 0 -1
  - lrange top:3:courses 0 -1

- Invalidate Cache keys
  - database.KeyExpire(key, expiry);

- ASP.NET Example - Azure Cache for Redis
  - You can create a Redis database 
  - IDatabase database = _redis.GetDatabase(); string key = "productlist";
  - ```if (await database.KeyExistsAsync(key))
            {
                long listLength = database.ListLength(key);
                for (int i = 0; i < listLength; i++)
                {
                    string value = database.ListGetByIndex(key, i);
                    Product product = JsonConvert.DeserializeObject<Product>(value);
                    _product_lst.Add(product);
                }
                return _product_lst;
            }```


- Content Delivery Network
  - CDN caching
  - For static website it's good to implement caching for websites
  - For dynamic websites it could be a little bit tricky
  - It's possible to cache every call with a query string parameter
  - With caching you should always think about the origin refresh 

- Azure Front Door
  - https://docs.microsoft.com/en-us/azure/frontdoor/front-door-overview