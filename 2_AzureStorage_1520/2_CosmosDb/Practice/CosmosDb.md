- *Cosmos db*
  - Fully managed no sql sb

- *Partitions*
   - items in a container are divided into subsets called logical Partitions
   - The partition for the item is decided by the partition key that is associated with the item in the container .

- *How to choose a Key*
   - Choose a property in the values does not change
   - The property should have a wide range of values
   - Once you decide a partition key for a container you can't change it

- *Costing*
   - TODO Check the theory part of the course

- *Full screen*
   - You can always open your db account screen at Full screen

- *JOINS*
  - In Azure Cosmos DB, joins are scoped to a single item. Cross-item and cross-container joins are not supported. In NoSQL databases like Azure Cosmos DB, good data modeling can help avoid the need for cross-item and cross-container joins.
  - JOINS DOCS : https://docs.microsoft.com/en-us/azure/cosmos-db/sql/sql-query-join


- *SDK*
  - Check samples
  - In order to get cosmos db account key and connection string go to account > Keys
  - To replace an item we will need the id and the parition key
  - You can use FeedIterator<Order> feedIterator to fetch data
  - In order to add subitems to a defined item all you need is to get the element and then add the item and replace it : 
     ```
     var item = customerResponse.Resource;    
     item.orders.Add(new Order { orderId="O6",category="Desktop",quantity=300});
     // Now let's replace the item
    await container.ReplaceItemAsync<Customer>(item, customerId, new PartitionKey(customerCity));
    ```

- *SP*
  - SPs are basically written in Js

- *Trigger*
  - Triggers could also be created
  - Somthing specifi about cosmos db trigger is that you can define the trigger that you need to be called before your operation (Unlike triggers on SGSBDs for example)

- *Changes Feed*
  - Are done to check updates on a some objects
  - TODO to check more later

- *Composite index*
  - If it's needed to order by multiple properties it's necessary to have a composite index
   ```
   "compositeIndexes":[  
            [  
                {  
                    "path":"/orderId",
                    "order":"ascending"
                },
                {  
                    "path":"/category",
                    "order":"ascending"
                }
            ]
        ]
   ```


- *Consistency*
  - Rehceck various elemnts related to consistency