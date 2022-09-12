using CosmosDbApp204.Operations.Entities;
using Microsoft.Azure.Cosmos;

namespace CosmosDbApp204.Operations
{
    internal class ComosDbOps
    {
        private string CosmosDbEndpointUri { get; set; }

        private string CosmosDbKey { get; set; }

        private CosmosClient CosmosClient { get; set; }

        public ComosDbOps(string comosDbEndPoint, string cosmosDbKey)
        {
            CosmosDbEndpointUri = comosDbEndPoint;

            CosmosDbKey = cosmosDbKey;

            CosmosClient = new(CosmosDbEndpointUri, CosmosDbKey);
        }

        public async Task CreateDataBase(string databaseName)
        {
            await CosmosClient.CreateDatabaseIfNotExistsAsync(databaseName);

            Console.WriteLine("DataBase created");
        }

        public async Task CreateContainer(string databaseName, string containerName, string partitionKey)
        {
            Database database = CosmosClient.GetDatabase(databaseName);

            await database.CreateContainerIfNotExistsAsync(containerName, partitionKey);

            Console.WriteLine("Container created");
        }

        public async Task AddItem(
            string databaseName,
            string containerName,
            Customer customer)
        {
            Database database = CosmosClient.GetDatabase(databaseName);

            Container container = database.GetContainer(containerName);

            Customer customerToCreate = new
            (
                customer.customerId,
                customer.customerName,
                customer.customerCity,
                customer.orders
            );

            ItemResponse<Customer> response = await container.CreateItemAsync<Customer>
                (customerToCreate,
                new PartitionKey(customerToCreate.customerCity));

            Console.WriteLine("Added item with Customer Id {0}", customerToCreate.customerId);

            Console.WriteLine("Request Units consumed {0}", response.RequestCharge);
        }

        public async Task AddSomeItems()
        {
            await AddItem("appdb204", "Customer",
                new Customer(
                    "C1",
                    "CustomerA",
                    "New York",
                    orders: new List<Order>() {
                            new Order
                            {
                                orderId = "O1",
                                category = "Laptop",
                                quantity = 100
                            },
                             new Order
                             {
                                 orderId = "O2",
                                 category = "Mobile",
                                 quantity = 10
                             }
                       }
            ));

            await AddItem("appdb204", "Customer",
                new Customer(
                    "C2",
                    "CustomerB",
                    "Chicago",
                    orders: new List<Order>() {
                           new Order
                            {
                                orderId = "O3",
                                category = "Laptop",
                                quantity = 20
                            }
                       }
            ));

            await AddItem("appdb204", "Customer",
                new Customer(
                    "C3",
                    "CustomerC",
                    "Miami",
                    orders: new List<Order>() {
                                new Order
                                {
                                    orderId = "O4",
                                    category = "Desktop",
                                    quantity = 30
                                },
                                 new Order
                                 {
                                     orderId = "O5",
                                     category = "Mobile",
                                     quantity = 40
                                 } }));
        }

        public async Task ReadItems(string databaseName, string containerName)
        {
            Database database = CosmosClient.GetDatabase(databaseName);

            Container container = database.GetContainer(containerName);

            string sqlQuery = "SELECT o.orderId,o.category,o.quantity FROM Orders o";

            QueryDefinition queryDefinition = new(sqlQuery);

            using FeedIterator<Order> feedIterator = container.GetItemQueryIterator<Order>(
                queryDefinition);

            while (feedIterator.HasMoreResults)
            {
                FeedResponse<Order> respose = await feedIterator.ReadNextAsync();
                foreach (Order order in respose)
                {
                    Console.WriteLine("Order Id {0}", order.orderId);
                    Console.WriteLine("Category {0}", order.category);
                    Console.WriteLine("Quantity {0}", order.quantity);
                }
            }
        }

        public async Task ReplaceItems(string databaseName, string containerName)
        {
            Database database = CosmosClient.GetDatabase(databaseName);

            Container container = database.GetContainer(containerName);

            string orderId = "O1";
            string sqlQuery = $"SELECT o.id,o.category FROM Orders o WHERE o.orderId='{orderId}'";

            string id = "";
            string category = "";

            QueryDefinition queryDefinition = new(sqlQuery);

            using FeedIterator<Order> feedIterator = container.GetItemQueryIterator<Order>(queryDefinition);

            while (feedIterator.HasMoreResults)
            {
                FeedResponse<Order> respose = await feedIterator.ReadNextAsync();
                foreach (Order order in respose)
                {
                    id = order.id;
                    category = order.category;
                }
            }

            // Get the specific item first
            ItemResponse<Order> orderResponse = await container.ReadItemAsync<Order>(id, new PartitionKey(category));

            var item = orderResponse.Resource;

            item.quantity = 1987;

            // Now let's replace the item
            await container.ReplaceItemAsync<Order>(item, id, new PartitionKey(item.category));

            Console.WriteLine("Item is updated");
        }

        public async Task DeleteItems(string databaseName, string containerName)
        {
            Database database = CosmosClient.GetDatabase(databaseName);

            Container container = database.GetContainer(containerName);

            string orderId = "O1";

            string sqlQuery = $"SELECT o.id,o.category FROM Orders o WHERE o.orderId='{orderId}'";

            string id = "";
            string category = "";

            QueryDefinition queryDefinition = new(sqlQuery);

            using FeedIterator<Order> feedIterator = container.GetItemQueryIterator<Order>(queryDefinition);

            while (feedIterator.HasMoreResults)
            {
                FeedResponse<Order> respose = await feedIterator.ReadNextAsync();
                foreach (Order order in respose)
                {
                    id = order.id;
                    category = order.category;
                }
            }

            // Get the specific item first
            ItemResponse<Order> orderResponse = await container.DeleteItemAsync<Order>(id, new PartitionKey(category));

            Console.WriteLine("Item is deleted");
        }

        public async Task CallStoredProcedure(string databaseName, string containerName)
        {
            Database database = CosmosClient.GetDatabase(databaseName);

            Container container = database.GetContainer(containerName);

            var result = await container.Scripts.ExecuteStoredProcedureAsync<string>("Display", new PartitionKey(""), null);

            Console.WriteLine(result);
        }

        public async Task CallInsertionStoredProcedure(string databaseName, string containerName)
        {
            Database database = CosmosClient.GetDatabase(databaseName);

            Container container = database.GetContainer(containerName);

            dynamic[] orderItems = new dynamic[]
            {
                new {
                    id = Guid.NewGuid().ToString(),
                    orderId = "01",
                    category  = "Laptop",
                    quantity  = 100
                },
                new {
                    id = Guid.NewGuid().ToString(),
                    orderId = "02",
                    category  = "Laptop",
                    quantity  = 200
                },
                new {
                    id = Guid.NewGuid().ToString(),
                    orderId = "03",
                    category  = "Laptop",
                    quantity  = 75
                }
           };

            var result = await container.Scripts.ExecuteStoredProcedureAsync<string>(
                "CreateItems", 
                new PartitionKey("Laptop"), new[] { orderItems });

            Console.WriteLine(result);
        }

        public async Task CreateItemUsingTrigger(string databaseName, string containerName)
        {
            Database database = CosmosClient.GetDatabase(databaseName);

            Container container = database.GetContainer(containerName);

            dynamic orderItem =
                new
                {
                    id = Guid.NewGuid().ToString(),
                    orderId = "O1",
                    category = "Laptop"
                };

            await container.CreateItemAsync(orderItem, null, new ItemRequestOptions { PreTriggers = new List<string> { "validateItem" } });

            Console.WriteLine("Item has been inserted");

        }
    }
}
