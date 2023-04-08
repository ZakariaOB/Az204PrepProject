- Azure Key Vault name: cpandlkeyvault
  - Secret name: PostgreSQLConn
  - Id: 80df3e46ffcd4f1cb187f79905e9a1e8
  https://**cpandlkeyvault**.vault.azure.net//secrets/**PostgreSQLConn**/4387e9f3d6e14c459867679a90fd0f79?api-version=7.1

  - Environment
      If a reference is not resolved properly, the reference value will be used instead. This means that for application settings, an environment variable would be created


- To fix the certification issue : **CryptographicException**, the system cannot find the file specified.
    • Generate a certificate
    • Upload the certificate to Azure key vault
    • Import the certificate to Azure App Service
    • Add the certificate thumbprint to the WEBSITE_LOAD_CERTIFICATES app setting
    https://ankitvijay.net/2021/04/14/certificate-azure-app-service-linux/


- You need to configure API Management for authentication. Which policy values should you use?
   - **Validate JWT**
      The validate-jwt policy enforces existence and validity of a JWT extracted from either a specified HTTP Header or a specified query parameter.

   - Authentication should be done on Incoming Request and that should be done in Inbound section of the policy of course.
      This policy can be used in the following policy sections and scopes.
      Policy sections: **inbound**
      Policy scopes: all scopes


- Authentication to the corporate Website
  - **ID token signature**
  - **Azure AD endpoint URI**
  - Claims in access tokens
        JWTs (JSON Web Tokens) are split into three pieces:
        - Header - Provides information about how to validate the token including information about the type of token and how it was signed.
        - Payload - Contains all of the important data about the user or app that is attempting to call your service.
        - **Signature** - Is the raw material used to validate the token.
  - Your client can get an access token from either the v1.0 endpoint or the v2.0 endpoint using a variety of protocols.


- **Logic app** :
You test the Logic app in a development environment. The following error message displays: '400 Bad Request'.
Troubleshooting of the error shows an HttpTrigger action to call the RequestUserApproval function.
  - anonymous
  To use your logic app's managed identity in your function, you must set your function's authentication level to anonymous. Otherwise, your logic app throws a "BadRequest" error.
  - system-assigned
  Your logic app or individual connections can use either the system-assigned identity or a single user-assigned identity, which you can share across a group of logic apps, but not both. On your logic app menu, under Settings, select Identity > System assigned

- You need to configure Azure Service Bus to Event Grid integration.
Which Azure Service Bus settings should you use?
  - To enable the feature, you need the following items:
    - A Service Bus Premium namespace with at least one Service Bus queue or a Service Bus topic with at least one subscription.
    - Contributor access to the Service Bus namespace

- You need to investigate the Azure Function app error message in the development environment.
  - Azure Functions offers built-in integration with Azure Application Insights to monitor functions.
    The following areas of Application Insights can be helpful when evaluating the behavior, performance, and errors in your functions:
    Live Metrics: View metrics data as it's created in near real-time.


- You need to configure security and compliance for the corporate website files.
Which Azure Blob storage settings should you use? To answer, select the appropriate options in the answer area.
  => Restrict file access : Shared access signature (SAS)
  => Enable File auditing : Change Feed


- Async operation tracking using **Durable functions** to resolve timeouts issues
The HTTP response mentioned previously is designed to help implement long-running HTTP async APIs with Durable Functions. This pattern is sometimes referred to as the polling consumer pattern.
Both the client and server implementations of this pattern are built into the Durable Functions HTTP APIs.

- **You need to configure the integration for Azure Service Bus and Azure Event Grid.**
  az **eventgrid event-subscription** create --name es2 \
    --source-resource-id /subscriptions/{SubID} \
    --endpoint-type **servicebusqueue** \
    --endpoint /subscriptions/{SubID}/resourceGroups/TestRG/providers/Microsoft.ServiceBus/namespaces/ns1/queues/queue1


- As a solution architect/developer, you should consider using **Service Bus queues** when:
  - Your solution needs to receive messages without having to poll the queue. With Service Bus, you can achieve it by using a long-polling receive operation using the TCP-based protocols that Service Bus supports.


- Scenario: Azure Storage blob will be used (refer to the exhibit). Data storage costs must be minimized.
    - **General-purpose v2** accounts: Basic storage account type for blobs, files, queues, and tables. Recommended for most scenarios using Azure Storage.
    - **Replication: Geo-redundant Storage**  Data must be replicated to a secondary region and three availability zones. Geo-redundant storage (GRS) copies your data synchronously three times within a single physical location in the primary region using LRS. It then copies your data asynchronously to a single physical location in the secondary region.
    - **Cool**
      Data storage costs must be minimized.
      Note: Azure storage offers different access tiers, which allow you to store blob object data in the most cost-effective manner. The available access tiers include:
      Hot - Optimized for storing data that is accessed frequently.
      Cool - Optimized for storing data that is infrequently accessed and stored for at least 30 days.