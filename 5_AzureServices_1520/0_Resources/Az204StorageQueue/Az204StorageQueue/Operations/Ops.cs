using Az204StorageQueue.Entities;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using Newtonsoft.Json;

namespace Az204StorageQueue.Operations
{
    internal class Ops
    {
        public string ConnectionString { get; set; }

        public string QueueName { get; set; }

        public QueueClient QueueClient  => new(ConnectionString, QueueName);


        public Ops(string connectionString, string queuName)
        {
            ConnectionString = connectionString;
            QueueName = queuName;  
        }

        public void SendMessage(string message)
        {
            if (QueueClient.Exists())
            {
                QueueClient.SendMessage(message);
                Console.WriteLine("Message sent {0}", message);
            }
        }

        public void PeekMessages()
        {
            int maxMessages = 10;

            if (QueueClient.Exists())
            {
                PeekedMessage[] peekedMessages = QueueClient.PeekMessages(maxMessages);
                
                Console.WriteLine("The messages in the queue are : ");
                
                foreach (var message in peekedMessages)
                {
                    Console.WriteLine(message.Body);
                }
            }
        }

        public void ReceiveMessage()
        {
            int maxMessages = 10;

            QueueMessage[] queueMessages = QueueClient.ReceiveMessages(maxMessages);

            Console.WriteLine("The messages in the queue are");
            
            foreach (var message in queueMessages)
            {
                Console.WriteLine(message.Body);
                
                QueueClient.DeleteMessage(message.MessageId, message.PopReceipt);
            }
        }

        public int GetQueueLength()
        {
            if (QueueClient.Exists())
            {
                QueueProperties queueProperties = QueueClient.GetProperties();

                return queueProperties.ApproximateMessagesCount;
            }
            return 0;
        }

        public async Task SendMessageAsObject(string orderid, int quantity)
        {
            if (QueueClient.Exists())
            {
                Order order = new Order { OrderId = orderid, Quantity = quantity };
                
                await QueueClient.SendMessageAsync(JsonConvert.SerializeObject(order));
                
                Console.WriteLine("Order Id {0} sent", orderid);
            }
        }

        public async Task PeekMessagesAsObjects()
        {
            int maxMessages = 10;

            if (QueueClient.Exists())
            {
                PeekedMessage[] peekedMessages = await QueueClient.PeekMessagesAsync(maxMessages);

                Console.WriteLine("The orders in the queue");
                
                foreach (var message in peekedMessages)
                {
                    Order order = JsonConvert.DeserializeObject<Order>(message.Body.ToString());

                    Console.WriteLine("Order Id {0}", order.OrderId);
                    
                    Console.WriteLine("Order Quantity {0}", order.Quantity);
                }
            }
        }

        public async Task SendMessageInBase64(string orderid, int quantity)
        {
            if (!QueueClient.Exists())
            {
                return;
            }

            Order order = new() { OrderId = orderid, Quantity = quantity };
            
            var jsonObject = JsonConvert.SerializeObject(order);
            
            var bytes = System.Text.Encoding.UTF8.GetBytes(jsonObject);
            
            var message = Convert.ToBase64String(bytes);
            
            await QueueClient.SendMessageAsync(message);
            
            Console.WriteLine("Order Id {0} sent", orderid);
        }

        public async Task PeekMessagesInBase64()
        {
            if (!QueueClient.Exists())
            {
                return;
            }

            int maxMessages = 10;

            PeekedMessage[] peekedMessages = await QueueClient.PeekMessagesAsync(maxMessages);
            
            Console.WriteLine("The orders in the queue");
            
            foreach (var message in peekedMessages)
            {
                var base64String = Convert.FromBase64String(message.Body.ToString());
                
                var stringData = System.Text.Encoding.UTF8.GetString(base64String);
                
                Order? order = JsonConvert.DeserializeObject<Order>(stringData);
                
                if (order == null)
                {
                    return;
                }

                Console.WriteLine("Order Id {0}", order.OrderId);
                
                Console.WriteLine("Order Quantity {0}", order.Quantity);
            }
        }
    }
}
