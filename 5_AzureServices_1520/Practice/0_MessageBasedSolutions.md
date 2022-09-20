# Azure storage Queue #

  - A storage queue could be created from an azure storage account
  - You can use the connection string part of the account service
  - Peek method : 
           Retrieves one or more messages from the front of the queue but does not alter
           the visibility of the message. For more information, see Peek Messages.
  - Receive message :
     - it's a 2 steps process
     - After receiving a message a deqeue count will be 1
     - To delete the message we could simply use
             ```QueueClient.DeleteMessage(message.MessageId, message.PopReceipt);```

  - To send and receive objects you can simply Serialize and Deserialize your objects
  
  - You can create an zure function to trigger a call if a new item is added to your function .
  - The input is not a valid Base-64 string as it contains a non-base 64 character, more than two padding characters, or an illegal character among the padding characters.
  - Azure function is expecting the message received to be base 64
  - A subsquet queue will be created with the suffix : poison will be created to contain the elements that was not sent .
  - Base64 : ```https://stackoverflow.com/questions/3538021/why-do-we-use-base64```
  - The Azure function will receive process and delete the message from the Queue

  - It's also possible to Get Objects instead of strings from the Azure function
    ```[FunctionName("GetMessages")]
        public void Run([QueueTrigger("appqueue", Connection = "connectionString")]Order order, ILogger log)```
  - However you should send your data in a way that could be deconstructed as an object
  - It's also possible to output the data of the queue to an azure table => Storage preview => Table => Refresh
  - More details : ```https://learn.microsoft.com/en-us/azure/azure-functions/functions-bindings-storage-queue-trigger?tabs=in-process%2Cextensionv5&pivots=programming-language-csharp```




# Azure Service Bus #

- Azure storage queue vs Azure service Bus queues
  - Azure storage Queue 
     - If you need more than 80 GB of messages in the queue
  - Azure Service Bus Queue
     - You queue size will not go beyond 80 GB
     - You need guaranteed FIFO delivery of messages
     - Duplicate detection
- More on the differences : ```https://medium.com/awesome-azure/azure-difference-between-azure-storage-queue-and-service-bus-queue-azure-queue-storage-vs-servicebus-3f7921b0159e#:~:text=TL%3BDR%3A,and%20more%20advanced%20integration%20patterns.```

-  Azure service Bus
  - Need to create first a service Bus namespace
  - For a given azure queue you will need to create an azure policy in order to use a connection string
  - You can send or receive messages from the queue
  - No message queue is deleted , the peek will simply make the item as 'Delivery Count = 1'
- It's a message broker system
- You can use the Service Bus explorer to peek send receive message to the queue
- In order to interact with the Service Bus you will need a Shared access policy
- To receive messages instead of peeking them you could use 
  ```ServiceBusReceiver serviceBusReceiver = serviceBusClient.CreateReceiver(queueName,
        new ServiceBusReceiverOptions() { ReceiveMode = ServiceBusReceiveMode.ReceiveAndDelete });```

- Modes of receiving/peeking messages 
  ```public enum ServiceBusReceiveMode
    {
        /// <summary>
        /// Once a message is received in this mode, the receiver has a lock on the message for a
        /// particular duration. If the message is not settled by this time, it lands back on Service Bus
        /// to be fetched by the next receive operation.
        /// </summary>
        ///
        /// <remarks>This is the default value for <see cref="ServiceBusReceiveMode" />, and should be used for guaranteed delivery.</remarks>
        PeekLock,

        /// <summary>
        /// ReceiveAndDelete will delete the message from Service Bus as soon as the message is delivered.
        /// </summary>
        ReceiveAndDelete,
    }
  ```

- You can add some custom properties to your messages
- You can also use a custom messages process to wrap receiving messages by marking a start and
  an end to the receiving operation.

- Peek lock or receive and delete
  - Message lock duration is by default = 30 seconds
  - If the message is processed it will be locked (Invisile to other consumer)
  - It's up to you to treat the message on 30 seconds
  - { ReceiveMode = ServiceBusReceiveMode.PeekLock });

- Message time to live by default > 14 days

- You can make the time to live as you wish for every message on the queue : 30 seconds for example:  ``` serviceBusMessage.TimeToLive = TimeSpan.FromSeconds(30); ```

- Dead letter queue
  - Are not processed properly or reach their time to live
  - Dead lettering can be activated/decativated at service BUS level

- Duplicate message detection
  - At queue creation you can activate duplicate detection
  - Duplicate detection window : If a message has already been sent with the same Message Id then the Azure service Bus queue will not accepet any other message with the same Id for the detction window period .
  - This is disabled by default
  - This can happen if for reason a message is sent but for some reaon sent again
  - The duplication could not be a good thing
  - In order for the queue to detect duplication , a messageId is mandatory
  - Duplicate window detection ??
  - You can specify MessageId property
  - ```serviceBusMessage.MessageId = messageId.ToString();```

- Topics
  - In order to start getting messages from a Topic you should create subscriptions
  - If you send a message to the topic all the subscriptions will get notified
  - A topic subscription resembles a virtual queue that receives copies of the messages that  are sent to the topic. Consumers receive messages from a subscription identically to the way they receive messages from a queue
  - This is how you create the receiver (Using topicName and subscriptionName):
       ```
       ServiceBusReceiver serviceBusReceiver = ServiceBusClient.CreateReceiver(
                topicName, 
                subscriptionName,
                new ServiceBusReceiverOptions() { ReceiveMode = ServiceBusReceiveMode.ReceiveAndDelete });
        ```
  - Sending or receiving from a Topic is the same , it only differs on ServiceBusReceuver creation constructor parameters .
  - For the connection string you will need to create a Shared Access Policy at Topic level .

- TODO Azure Service Bus Queue - Azure Functions