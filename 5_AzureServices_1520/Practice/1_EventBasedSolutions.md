- # Event Hub #
  
  - This can help to analyze an important amount of data
  - This a Big data streaming platform
  - The Big parts of the Event Hub platform are
    - Event producers : An entity that sends data to an event Hub. The events can be 
      published using the protocols : HTTPS, AMPQ, Apache Kafka
    - Partitions : The data is split accross partitions to allow better performance throughput of your data onto Azure Event Hub .
    - Consumer groups : This is a view (state, position, or offset) of an entire event hub .
    - Throughput : This controls the throuput capacity of Event Hubs
    - Event receivers : This an entity that reads event data
    

 - # Working with event hubs #
  
   - You first need to create an event hub namespace
   - Inside the namespace you can create the Event Hub
   - Use shared access policies to get a connection string as done for Event service Bus
   - Message retention : It's the retention period for events. You can set the retention period between 1 and 7 days. Learn more about Message Retention
   - You can basically have various consumers that can consume events from EventHub

- # Some concepts #
  
  - Consumer will continously read the data from Events Hubs
  - No deletion will occur after reading an Event
  - There is no method to delete events
  - Up to message retention time defined the event will stay on the HUB
  - But your program needs to have a track of read events to avoid duplication on reads
     - You read the latest partition by using ```EventPosition.Latest```
       ```
       await ... ReadEventsFromPartitionAsync(partitionID,EventPosition.Latest)
       ```
  - Event processor
     - Provides a base for creating a custom processor which consumes events across all partitions of a given Event Hub for a specific consumer group. The processor is capable of collaborating with other instances for the same Event Hub and consumer group pairing to share work by using a common storage platform to communicate. Fault tolerance is also built-in, allowing the processor to be resilient in the face of errors.
     - Using the Event processor class could give you the advantage to store data in an azure storage account .

- Azure Event Hubs - Other concepts
  - Throuput capacity is the amount of data that will go in and out from your event Hub .
  - You might start get ServerBusyException when the ingress traffic goes byond the limit
  - Recommendation
    - 1 receiver per partition
    - You can have 5 concurrent reader per partition per consumer group
    - You have to be careful not to duplicate the process of reading the same message .

- Capture format
  - Should record data on a storage account
  - The capture is done in avro format

- Lecture 313 : You can use streaming diagnostics data from an Azure SQL database


- # Event Grid #

- Can be used to check events emitted from azure resources

- You can also send events to our customer applications that can react as an events hook

- Azure Functions – Azure Event Grid
  - You can create a function as an event Grid trigger which will run whenever an event grid is fired .
  - We will need to subscribe at storage account to our created Function
  - Many services support events feature
  - Events : Blob created, Blob Deleted
  - Steps
     - Create a storage account to trigger events
     - Create a function app to use to get the storage account data
     - To check the logs you need to go to Monitor > Logs

- For blobs events we can also use the native blob trigger
   - For a new event created or updates
   - More functionnality could be provided using Azure Grids

- It's also possible to get blob content using Functions :
  ```
  [FunctionName("ProcessBlob")]
        public void Run([BlobTrigger("data/{name}", Connection = "connectionString")]Stream streamBlob, string name, ILogger log)
        {
            
            StreamReader streamReader=new StreamReader(streamBlob);
            string blob = streamReader.ReadToEnd();
            log.LogInformation(blob);
        }
  ```
- It's also possible to copy blob , However if you run your app from VS locally you should be  aware of defining a storage account on your settings . Also note that your function will automatically instantiate a BlobClient for you and a streamBlob using Method attributes .
  
  ```
  [FunctionName("ProcessBlob")]
        public async Task Run(
            [BlobTrigger("data/{name}", Connection = "connectionString")]Stream streamBlob, 
            [Blob("newdata/{name}", FileAccess.ReadWrite)] BlobClient newBlob, ILogger log)
        {
            
            await newBlob.UploadAsync(streamBlob);
        }
  ```
- Event Grid – Debug locally
   - ngrok can help with forwarding events directly to your local machine
   - Azure event grid will not be able to contact my local machine
   - If I will use Event grid with my local app i have to use Webhook for trigger at event subscription level
   - ngrok.exe http --host-header=localhost 7071 => ngrok will forward to localhost
   - https://6dcd-102-78-241-230.eu.ngrok.io/runtime/webhooks/EventGrid?functionName=GetBlobDetails
   - The idea is the ngrok can be used to forward requests from EventGrid to the localhost

- Event Grid Schema (What to expect while receiving an event)
    - [
      {
        "topic": string,
        "subject": string,
        "id": string,
        "eventType": string,
        "eventTime": string,
        "data":{
          object-unique-to-each-publisher
        },
        "dataVersion": string,
        "metadataVersion": string
      }
    ]

- Storage queue handler
  - Create a new queue at storage account
  - You can trigger the creation of a new elements in a queue from the EventGrid

- Event Grid filters
  - You can determine events that you want to receive
  - Let us we want to detected only img.jpg
  - You can go to the filter section of the subscription and Hit on save
  - To check later : I was not able to add filter at store subscription level (Event)
  - You can use : Subject begins with or Subject ends with

- Events at the resource group level
  - Same principal will be applied at entire ressource group level
  - The events types could be different at resource group level  : Resource created, resource deleted etc ..

- You can also create your own topics and use them > Lab - Custom topics
