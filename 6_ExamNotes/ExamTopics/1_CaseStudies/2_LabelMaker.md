- Comos db consistency level : **Strong**
   When the consistency level is set to strong, the staleness window is equivalent to zero, and the clients are guaranteed to read the   latest committed value of the write operation.
   Scenario: Changes to the Order data must reflect immediately across all partitions. All reads to the Order data must fetch the most   recent writes.
   Note: You can choose from five well-defined models on the consistency spectrum. From strongest to weakest, the models are: Strong,   Bounded staleness,
   Session, Consistent prefix, Eventual

- **Azure cosmos db SQL API** 
Scenario: You identify the following requirements for data management and manipulation:
Order data is stored as nonrelational JSON and must be queried using Structured Query Language (SQL).


- **Order Workflow**
  - The 'Default' policy does 4 exponential retries and from my experience the interval times are often too short in situations.
  - PT60S
      We could set a fixed interval, e.g. 5 retries every 60 seconds (PT60S).
      **PT60S is 60 seconds**
      **Count: 5**
      Scenario: Calls to the Printer API App fail periodically due to printer communication timeouts.
      Printer communication timeouts occur after 10 seconds. The label printer must only receive up to 5 attempts within one minute.

- **ACR** You need to deploy a new version of the LabelMaker application to ACR
  - Build a new application image by using Dockerfile
  - Create an alias of the image with the new qualified path to the registry
  - Log in to the registry and push the image