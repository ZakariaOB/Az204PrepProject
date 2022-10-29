using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Producer;
using EventHub204.Entities;
using Newtonsoft.Json;
using System.Text;

namespace EventHub204.Operations
{
    internal class Ops
    {
        public  string ConnectionString { get; set; }

        public string EventHubName { get; set; }

        string ConsumerGroup = "$Default";

        public Ops(string connectionString, string eventHubName)
        {
            ConnectionString = connectionString;

            EventHubName = eventHubName;
        }

        public async Task SendData(List<Device> deviceList)
        {
            EventHubProducerClient eventHubProducerClient = new (ConnectionString, EventHubName);
            
            EventDataBatch eventBatch = await eventHubProducerClient.CreateBatchAsync();

            foreach (Device device in deviceList)
            {
                EventData eventData = new (Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(device)));
                if (!eventBatch.TryAdd(eventData))
                {
                    Console.WriteLine("Error has occured");
                }
            }

            await eventHubProducerClient.SendAsync(eventBatch);
            
            Console.WriteLine("Events sent");
            
            await eventHubProducerClient.DisposeAsync();
        }

        public async Task GetPartitionIds()
        {
            EventHubConsumerClient eventHubConsumerClient = new EventHubConsumerClient(ConsumerGroup, ConnectionString);

            string[] partitionIds = await eventHubConsumerClient.GetPartitionIdsAsync();
            
            foreach (string partitionId in partitionIds)
            {
                Console.WriteLine("Partition Id {0}", partitionId);
            }
        }

        public async Task ReadEvents()
        {
            EventHubConsumerClient eventHubConsumerClient = new (ConsumerGroup, ConnectionString);

            CancellationTokenSource cancellationSource = new ();
            
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(300));

            await foreach (PartitionEvent partitionEvent 
                in eventHubConsumerClient.ReadEventsAsync(cancellationSource.Token))
            {
                Console.WriteLine($"Partition ID {partitionEvent.Partition.PartitionId}");

                Console.WriteLine($"Data Offset {partitionEvent.Data.Offset}");
                
                Console.WriteLine($"Sequence Number {partitionEvent.Data.SequenceNumber}");
                
                Console.WriteLine($"Partition Key {partitionEvent.Data.PartitionKey}");
                
                Console.WriteLine(Encoding.UTF8.GetString(partitionEvent.Data.EventBody));
            }
        }

        public async Task SendDataUsingPartitions(IEnumerable<Device> deviceList, string partitionKey)
        {
            EventHubProducerClient eventHubProducerClient = new (ConnectionString, EventHubName);
            
            List<EventData> eventData = new ();

            foreach (Device device in deviceList)
            {
                eventData.Add(new EventData(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(device))));
            }

            await eventHubProducerClient.SendAsync(eventData, new SendEventOptions() { PartitionKey = partitionKey }, new CancellationToken());

            Console.WriteLine("Events sent");
            
            await eventHubProducerClient.DisposeAsync();
        }

        public async Task ReadEventsFromDifferentPartitions()
        {
            EventHubConsumerClient eventHubConsumerClient = new (ConsumerGroup, ConnectionString);
            
            var cancellationSource = new CancellationTokenSource();
            
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(300));

            await foreach (PartitionEvent _event in eventHubConsumerClient.ReadEventsAsync(cancellationSource.Token))
            {
                Console.WriteLine($"Partition ID {_event.Partition.PartitionId}");
                Console.WriteLine($"Data Offset {_event.Data.Offset}");
                Console.WriteLine($"Sequence Number {_event.Data.SequenceNumber}");
                Console.WriteLine($"Partition Key {_event.Data.PartitionKey}");
                Console.WriteLine(Encoding.UTF8.GetString(_event.Data.EventBody));
            }
        }
    }
}
