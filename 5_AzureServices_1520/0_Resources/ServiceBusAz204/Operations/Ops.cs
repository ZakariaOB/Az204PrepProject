using Azure.Messaging.ServiceBus;
using Microsoft.Azure.Amqp.Framing;
using Newtonsoft.Json;
using ServiceBusAz204.Entities;
using System;

namespace ServiceBusAz204.Operations
{
    internal class Ops
    {
        private string ConnectionString { get; set; }

        private string QueueName { get; set; }

        private string TopicConnectionString { get; set; }

        private ServiceBusClient ServiceBusClient => new (ConnectionString);

        private ServiceBusSender ServiceBusSender => ServiceBusClient.CreateSender(QueueName);


        private readonly string[] Importance = new string[] { "High", "Medium", "Low" };


        public Ops (string connectionSting, string queueName, string topicName)
        {
            ConnectionString = connectionSting;
            QueueName = queueName;
            TopicConnectionString = topicName;
        }

        public async Task SendMessage(List<Order> orders)
        {
            if (orders == null || !orders.Any())
            {
                return;
            }
            
            ServiceBusMessageBatch serviceBusMessageBatch = await ServiceBusSender.CreateMessageBatchAsync();

            foreach (Order order in orders)
            {
                ServiceBusMessage serviceBusMessage = new (JsonConvert.SerializeObject(order));
                
                serviceBusMessage.ContentType = "application/json";
                
                if (!serviceBusMessageBatch.TryAddMessage(serviceBusMessage))
                {
                    throw new Exception("Error occured");
                }
            }
            
            Console.WriteLine("Sending messages");
            
            await ServiceBusSender.SendMessagesAsync(serviceBusMessageBatch);
        }

        public async Task PeekMessages()
        {
            ServiceBusReceiver serviceBusReceiver = ServiceBusClient.CreateReceiver(
                QueueName,
                new ServiceBusReceiverOptions() { ReceiveMode = ServiceBusReceiveMode.PeekLock });

            IAsyncEnumerable<ServiceBusReceivedMessage> messages = serviceBusReceiver.ReceiveMessagesAsync();

            await foreach (ServiceBusReceivedMessage message in messages)
            {
                Order? order = JsonConvert.DeserializeObject<Order>(message.Body.ToString());
                
                if (order == null)
                {
                    return;
                }

                Console.WriteLine("Order Id {0}", order.OrderId);
                
                Console.WriteLine("Quantity {0}", order.Quantity);
                
                Console.WriteLine("Unit Price {0}", order.UnitPrice);
            }
        }

        public async Task GetMessagesProperties()
        {
            ServiceBusReceiver serviceBusReceiver = ServiceBusClient.CreateReceiver(
                QueueName,
                new ServiceBusReceiverOptions() { ReceiveMode = ServiceBusReceiveMode.PeekLock });

            IAsyncEnumerable<ServiceBusReceivedMessage> messages = serviceBusReceiver.ReceiveMessagesAsync();
            await foreach (ServiceBusReceivedMessage message in messages)
            {
                Console.WriteLine("Sequence number {0}", message.SequenceNumber);
                
                Console.WriteLine("Message Id {0}", message.MessageId);
            }
        }

        public async Task SendMessagesWithAdditionProperties(IEnumerable<Order> orders)
        {
            ServiceBusMessageBatch serviceBusMessageBatch = await ServiceBusSender.CreateMessageBatchAsync();

            int i = 0;
            
            foreach (Order order in orders)
            {

                ServiceBusMessage serviceBusMessage = new ServiceBusMessage(JsonConvert.SerializeObject(order));
                
                serviceBusMessage.ContentType = "application/json";
                
                serviceBusMessage.ApplicationProperties.Add("Importance", Importance[i]);
                
                i++;
                
                if (!serviceBusMessageBatch.TryAddMessage(serviceBusMessage))
                {
                    throw new Exception("Error occured");
                }

            }
            Console.WriteLine("Sending messages");
            
            await ServiceBusSender.SendMessagesAsync(serviceBusMessageBatch);
            
            await ServiceBusSender.DisposeAsync();
        }

        public async Task GetMessagesWithAdditionalProperties()
        {
            ServiceBusReceiver serviceBusReceiver = ServiceBusClient.CreateReceiver(
                QueueName,
                new ServiceBusReceiverOptions() { ReceiveMode = ServiceBusReceiveMode.PeekLock });

            IAsyncEnumerable<ServiceBusReceivedMessage> messages = serviceBusReceiver.ReceiveMessagesAsync();
            
            string ParseMessage(IReadOnlyDictionary<string, object> dictionnary)
            {
                if (dictionnary != null && dictionnary.ContainsKey("Importance"))
                {
                    return dictionnary["Importance"].ToString();
                }
                return "Undefined Importance";
            } 

            await foreach (ServiceBusReceivedMessage message in messages)
            {
                Console.WriteLine("Message Id {0}", message.MessageId);
                
                Console.WriteLine("Sequence Number {0}", message.SequenceNumber);

                Console.WriteLine("Message Importance {0}", ParseMessage(message.ApplicationProperties));
            }
            
            await serviceBusReceiver.DisposeAsync();
            
            await ServiceBusClient.DisposeAsync();
        }

        public async Task GetMessagesUsingProcessor()
        {
            ServiceBusProcessor serviceBusProcessor = ServiceBusClient.CreateProcessor(QueueName, new ServiceBusProcessorOptions());

            serviceBusProcessor.ProcessMessageAsync += ProcessMessage;
            
            serviceBusProcessor.ProcessErrorAsync += ErrorHandler;

            await serviceBusProcessor.StartProcessingAsync();
            
            Console.WriteLine("Waiting for messages");
            
            Console.ReadKey();

            await serviceBusProcessor.StopProcessingAsync();

            await serviceBusProcessor.DisposeAsync();

            await ServiceBusClient.DisposeAsync();

            static async Task ProcessMessage(ProcessMessageEventArgs messageEvent)
            {
                Order order = JsonConvert.DeserializeObject<Order>(messageEvent.Message.Body.ToString());

                Console.WriteLine("Order Id {0}", order.OrderId);
                
                Console.WriteLine("Quantity {0}", order.Quantity);
                
                Console.WriteLine("Unit Price {0}", order.UnitPrice);
            }

            static Task ErrorHandler(ProcessErrorEventArgs args)
            {
                Console.WriteLine(args.Exception.ToString());
                
                return Task.CompletedTask;
            }
        }
        
        public async Task SendTopicMessages(List<Order> orders, string topicName)
        {
            ServiceBusClient serviceBusClient = new ServiceBusClient(TopicConnectionString);
            ServiceBusSender serviceBusSender = serviceBusClient.CreateSender(topicName);

            ServiceBusMessageBatch serviceBusMessageBatch = await serviceBusSender.CreateMessageBatchAsync();
            int messageId = 1;
            foreach (Order order in orders)
            {
                ServiceBusMessage serviceBusMessage = new ServiceBusMessage(JsonConvert.SerializeObject(order));
                serviceBusMessage.ContentType = "application/json";
                serviceBusMessage.MessageId = messageId.ToString();
                messageId++;

                if (!serviceBusMessageBatch.TryAddMessage(
                    serviceBusMessage))
                {
                    throw new Exception("Error occured");
                }

            }
            Console.WriteLine("Sending messages");
            await serviceBusSender.SendMessagesAsync(serviceBusMessageBatch);

            await serviceBusSender.DisposeAsync();
            await serviceBusClient.DisposeAsync();

        }
        public async Task ReceiveTopicsMessages(string topicName, string subscriptionName)
        {
            ServiceBusReceiver serviceBusReceiver = (new ServiceBusClient(TopicConnectionString)).CreateReceiver(
                topicName, 
                subscriptionName,
                new ServiceBusReceiverOptions() { ReceiveMode = ServiceBusReceiveMode.PeekLock });

            IAsyncEnumerable<ServiceBusReceivedMessage> messages = serviceBusReceiver.ReceiveMessagesAsync();

            await foreach (ServiceBusReceivedMessage message in messages)
            {
                Order order = JsonConvert.DeserializeObject<Order>(message.Body.ToString());
                Console.WriteLine("Order Id {0}", order.OrderId);
                Console.WriteLine("Quantity {0}", order.Quantity);
                Console.WriteLine("Unit Price {0}", order.UnitPrice);
            }
        }
    }
}
