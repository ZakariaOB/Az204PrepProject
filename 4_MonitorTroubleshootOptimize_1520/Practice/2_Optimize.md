- Cache Redis
 - In momory cache to store the most frequently accessed data
 - Azure cashe for redis in just an implementation on Azure
 - Example : Top 10 courses for the day
 - How to interact with Redis : AzureCacheRedis

- Cache redis practice
  - lrange ul:cartitems 0 -1
  - lrange top:3:courses 0 -1

- Invalidate Cache keys
  - database.KeyExpire(key, expiry);