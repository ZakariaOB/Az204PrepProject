## Topic 1

- Hyper-V specifically provides hardware virtualization. That means each virtual machine runs on virtual hardware. 
  Hyper-V lets you create virtual hard drives, virtual switches, and a number of other virtual devices all of which 
  can be added to virtual machines
  - *Question* > To migrate an Azure VM between Hyper V you will need to redploy it . 
  - When you redeploy a VM, it moves the VM to a new node within the Azure infrastructure and then powers it back on, retaining   all your configuration options and associated resources.

- Password protection: Key Vault + Access Policy.
  Using Key Vault we create a secret containing our Password
  Using an Access Policy we allow access to the previously created secret.

- The number of fault domains for managed availability sets varies by region - either two or three per region
   -  Answer D Max Value. [ values could be 1,2,3 ]

- Each availability set can be configured with up to three fault domains and twenty update domains.

- Check Update domain / Fault domain defintion again

- For azure fuction Consumption Plan (Keep costs low) 
   - Send Grid Binding (Send Email). 

- *mongorestore* can be used to restore a MongoDB backup to the Azure Cosmos DB account using the MongoDB API.

- A managed identity from Azure Active Directory allows your app to easily access other AAD-protected resources such as Azure Key Vault.
Reference

- For Native Applications you need to provide a Redirect URI, which Azure AD will use to return token responses

- You are creating an Azure key vault using PowerShell. Objects deleted from the key vault must be kept for a set period of 90 days.
Which two of the following parameters must be used in conjunction to meet the requirement
  - *EnablePurgeProtection* and *EnableSoftDelete*

- You need to make sure that database developers can connect to the SQL database via Microsoft SQL Server Management Studio (SSMS). You also need to make sure the developers use their on-premises Active Directory account for authentication
  - *Active Directory integrated authentication*

- You want to configure the application to allow recovery of an accidental deletion of the key vault or key vault objects for 90 days after deletion.
  - *Run the az keyvault update --enable-soft-delete true --enable-purge-protection*

- You want to be notified whenever the Web App uses more than 85 percent of the available CPU cores over a 5 minute period
  - *window size - avg Percentage CPU*

- You want to implement automatic scaling when CPU load is above 80 percent. Your solution must minimize costs.
What should you do ***FIRST*** ?
  - Switch to the Standard App Service tier plan

- The Azure Log Analytics workspace is set up to gather performance counters associated with security from these linked servers
  - Metric alerts in Azure Monitor provide a way to get notified when one of your metrics cross a threshold. Metric alerts work on a range of multi-dimensional platform metrics, custom metrics, Application Insights standard and custom metrics.

- APIM : If backend accepts HTTP(S) Then Basic AUTH or Certificate will work.

- Azure function custom handler
  - Http
  - CustomHandler
  - For HTTP-triggered functions with no additional bindings or outputs, you may want your handler to work directly with the HTTP request and response instead of the custom handler request and response payloads => "enableForwardingHttpRequest": true
  
- The HyperText Transfer Protocol (HTTP) 401 Unauthorized response status code indicates that the client request has not been completed because it lacks valid authentication credentials for the requested resource.

- The HyperText Transfer Protocol (HTTP) 302 Found redirect status response code indicates that the resource requested has been temporarily moved to the URL given by the Location header

- Azure static Web apps
  - It's common to require authentication for every route in an application. To enable this, add a rule that matches all routes and include the built-in authenticated role in the allowedRoles array
     ```json
        {
          "routes": [
            {
              "route": "/*",
              "allowedRoles": ["authenticated"]
            }
          ],
          "responseOverrides": {
            "401": {
              "statusCode": 302,
              "redirect": "/.auth/login/aad"
            }
          }
        }
     ```
  - add / .referer

- ARM templates | Temptae Specs
  - https://learn.microsoft.com/en-us/azure/azure-resource-manager/templates/template-specs-create-linked?tabs=azure-cli

- Web PubSub with azure function
  - bindings
      - type      : webPubSubTrigger
      - eventType : user
          - Required - the value must be set as the event type of messages for the function to be triggered. The value should be either user or system.


- They are asking for high performance workloads which is supported by Premium tier https://learn.microsoft.com/en-us/azure/virtual-machines/disks-types
Also they are asking for zone redundancy (if datacenter goes down, NOT region outage). Also managed disk doesn't support GRS https://learn.microsoft.com/en-us/azure/virtual-machines/disks-redundancy
 => Premium SSD, ZRS

 - Container group is the only logical answer that can have shared lifecycle https://learn.microsoft.com/en-us/azure/container-instances/container-instances-container-groups?source=recommendations#what-is-a-container-group
Azure files need root permission
Secret is for secrets and read-only
EmtyDir can persist through crash and redeployed on stop and restart
https://learn.microsoft.com/en-us/azure/container-instances/container-instances-volume-emptydir#emptydir-volume
Cloned Git Repo also does the job but it needs more details like Git URL and stuff which are not mentioned to be available in the question


## Topic 2

- There are four customers that use this service, and each instance of the WebJob processes data for a single customer and must run as a singleton instance. So, the number of VM should be 4. WebJobs is a feature of Azure App Service that enables you to run a program or script in the same instance as a web app. Like running background tasks.

- Azure resources must be located in an isolated network .
In the Isolated tier, the App Service Environment defines the number of isolated workers that run your apps, and each worker is charged. In addition, there's a flat Stamp Fee for the running the App Service Environment itself. Isolated: This tier runs dedicated Azure VMs on dedicated Azure Virtual Networks. It provides network isolation on top of compute isolation to your apps. It provides the maximum scale-out capabilities.

- Kubernetes
  - Azure Function code             > Deployment
  - Polling Interval                > Scaled Object
  - Azure Storage connection string > Secret

- You need to design the process that starts the photo processing.
  Solution: Trigger the photo processing from Blob storage events.The trick is in the "less than one minute" detail.
    - You can read about "..10-minute delay in processing new blobs.." in "3-Minimizing latency" description.
    Microsoft says: ".....Use Event Grid instead of the Blob storage trigger for the following scenarios:"
    1-Blob-only storage accounts: Blob-only storage accounts are supported for blob input and output bindings but not for blob triggers.
   - High-scale: High scale can be loosely defined as containers that have more than 100,000 blobs in them or storage accounts that  have more than 100 blob updates per second.
   3-Minimizing latency: If your function app is on the Consumption plan, there can be up to a ##10-minute delay in processing new   blobs## if a function app has gone idle. To avoid this latency, you can switch to an App Service plan with Always On enabled. You   can also use an Event Grid trigger with your Blob storage account. For an example, see the Event Grid tutorial.

- Slots and custom warm ups
  - Some apps might require custom warm-up actions before the swap. The applicationInitialization configuration element in web.config lets you specify custom initialization actions. The swap operation waits for this custom warm-up to finish before swapping with the target slot. Here's a sample web.config fragment.
    ```xml
    <system.webServer>
      <applicationInitialization>
      <add initializationPage="/" hostName="[app hostname]" />
      <add initializationPage="/Home/About" hostName="[app hostname]" />
      </applicationInitialization>
    </system.webServer>
    ```

- Accessing the client certificate from App Service => **Http request Header / Base64**
If you are using ASP.NET and configure your app to use client certificate authentication, the certificate will be available through the HttpRequest.ClientCertificate property. For other application stacks, the client cert will be available in your app through a base64 encoded value in the "X-ARR-ClientCert" request header. Your application can create a certificate from this value and then use it for authentication and authorization purposes in your application

- Group create > Plan create > App create > config container > config hostname

- 1. Premium plan (avoid any cold starts and connect to a VNet)
  Overview of plans here: https://docs.microsoft.com/th-th/azure/azure-functions/functions-scale
  2. create system-assigned => "A system-assigned identity is tied to your application and is deleted if your app is deleted."
  3. create an access policy

- Change feed support in Azure Blob Storage
The purpose of the change feed is to provide transaction logs of all the changes that occur to the blobs and the blob metadata in your storage account. The change feed provides ordered, guaranteed, durable, immutable, read-only log of these changes. Client applications can read these logs at any time, either in streaming or in batch mode. The change feed enables you to build efficient and scalable solutions that process change events that occur in your Blob Storage account at a low cost

- Docker steps
  - FROM
  - WORKDIR
  - COPY
  - RUN
  - CMD

- Using Azure Function on processing images as quickly as possible after they are uploaded, and the solution must minimize latency
  Use an App Service plan. Configure the Function App to use an Azure Blob Storage trigger.
Consumption plan can cause a 10-min delay in processing new blobs if a function app has gone idle. To avoid this latency, you can switch to an App Service plan with Always On enabled.

- Working with a queue and a an azure function to process messages
 - maxDequeueCount - The number of times to try processing a message before moving it to the poison queue. Default value is 5.
 - When there are multiple queue messages waiting, the queue trigger retrieves a batch of messages and invokes function instances         concurrently to process them.By default, the batch size is 16. When the number being processed gets down to 8, the runtime gets another batch and starts processing those messages. So the maximum number of concurrent messages being processed per function on one virtual machine (VM) is 24.
 - [Table("Orders")]ICollector<Order> table bindings
  And in the code it adds the order:
  tableBindings.Add(JsonConvert.DeserializeObject<Object>(myQueueItem.AsString));

- Azure cosmos Db consistency levels
  - Strong: Strong consistency offers a linearizability guarantee. The reads are guaranteed to return the most recent committed version of an item. A client never sees an uncommitted or partial write. Users are always guaranteed to read the latest committed write
  - Bounded staleness -
  Bounded staleness: The reads are guaranteed to honor the consistent-prefix guarantee. The reads might lag behind writes by at most "K" versions (that is
  "updates") of an item or by "t" time interval. When you choose bounded staleness, the "staleness" can be configured in two ways:
  The number of versions (K) of the item
  The time interval (t) by which the reads might lag behind the writes
  - Eventual
    There's no ordering guarantee for reads. In the absence of any further writes, the replicas eventually converge.
    Incorrect Answers:
    Consistent prefix: Updates that are returned contain some prefix of all the updates, with no gaps. Consistent prefix guarantees that reads never see out-of-order writes.

- **To Do** : Difference bewteen Bounded staleness and Consistent prefix

- **Deploy a website to an Azure Web App from a GitHub repository**
  - In Azure, you can run your functions directly from a deployment package file in your function app. The other option is to deploy your  files in the d:\home\site\wwwroot directory of your function app (see A above).
   To enable your function app to run from a package, you just add a WEBSITE_RUN_FROM_PACKAGE setting to your function app settings.
   Note: The host.json metadata file contains global configuration options that affect all functions for a function app.
  - D: To customize your deployment, include a .deployment file in the repository root.
    You just need to add a file to the root of your repository with the name .deployment and the content:
    [config]
    command = YOUR COMMAND TO RUN FOR DEPLOYMENT
    this command can be just running a script (batch file) that has all that is required for your deployment, like copying files from the repository to the web root directory for example.

- In order to use AzCopy you have to apply the following steps
    * Export a template.
    * Modify the template by adding the target region and storage account name.
    * Create a new Template deployment
    * Deploy the template to create the new storage account.
    * Use AzCopy


- TODO Firewall config            > Run Command
  Supporting services script > Customer Script Extension

- *Managed Identity - User assigned and system assigned*
    - $vm = Get-AzVM -ResourceGroupName myResourceGroup -Name myVM
    Update-AzVM -ResourceGroupName myResourceGroup -VM $vm -IdentityType SystemAssigned
    -IdentityType: The type of identity used for the virtual machine. Valid values are SystemAssigned, UserAssigned, SystemAssignedUserAssigned, and None.

    - IdentityId: Specifies the list of user identities associated with the virtual machine. The user identity references will be ARM resource IDs .

    **$SystemAssigned**
    There are two types of managed identities:
    - *System-assigned* : Some Azure services allow you to enable a managed identity directly on a service instance. When you enable a system-assigned managed identity an identity is created in Azure AD that is tied to the lifecycle of that service instance. So when the resource is deleted, Azure automatically deletes the identity for you. By design, only that Azure resource can use this identity to request tokens from Azure AD.
    - *User-assigned* : You may also create a managed identity as a standalone Azure resource. You can create a user-assigned managed identity and assign it to one or more instances of an Azure service. In the case of user-assigned managed identities, the identity is managed separately from the resources that use it.


- For Azure functions Consumption plan can take up to several minutes to trigger the function

- **The CorrelationContext** is a way to associate contextual information with a request as it flows through the system. It allows you to track a request as it passes through different components of the system, and to identify related log entries and telemetry data. By adding the customer ID to the CorrelationContext in the web application, you can ensure that it is associated with all operations throughout the overall system. This will allow you to track the request and identify related log entries and telemetry data for a specific custome

- You are developing an Azure Function App. You develop code by using a language that is not supported by the Azure Function App host. The code language supports HTTP primitives. You must deploy the code to a production Azure Function App environment.
  - *Publish*       : code
  - *Runtime stack* : Custmo Hanlder
  - *Version*       : custom


- *Azure VM startup is stuck at Windows update*
  - https://learn.microsoft.com/en-us/troubleshoot/azure/virtual-machines/troubleshoot-stuck-updating-boot-error

- Regardless of the function app timeout setting, 230 seconds is the maximum amount of time that an HTTP triggered function can take to respond to a request.

- Large, long-running functions can cause unexpected timeout issues. General best practices include:
  - Whenever possible, refactor large functions into smaller function sets that work together and return responses fast. For example, a webhook or HTTP trigger function might require an acknowledgment response within a certain time limit; it's common for webhooks to require an immediate response. You can pass the
  - HTTP trigger payload into a queue to be processed by a queue trigger function. This approach lets you defer the actual work and return an immediate response

- The Durable Functions extension exposes a set of built-in HTTP APIs that can be used to perform management tasks on orchestrations, entities, and task hubs.
These HTTP APIs are extensibility webhooks that are authorized by the Azure Functions host but handled directly by the Durable Functions extension.
  => Check Durable functions => TODO Question 44 (Recheck)


- *Use ARM template test toolkit*
The Azure Resource Manager template (ARM template) test toolkit checks whether your template uses recommended practices. When your template isn't compliant with recommended practices, it returns a list of warnings with the suggested changes. By using the test toolkit, you can learn how to avoid common problems in template development.
 - *What-if operation*
  - ARM template deployment what-if operation
    Before deploying an Azure Resource Manager template (ARM template), you can preview the changes that will happen. Azure Resource Manager provides the what-if operation to let you see how resources will change if you deploy the template. The what-if operation doesn't make any changes to existing resources.
    Instead, it predicts the changes if the specified template is deployed


- *Orchestrator function*
  An orchestrator function is the appropriate type of Azure Durable Function to use in this scenario, because it allows you to define the overall flow of the loan process and call other functions or activities as needed. The credit check process can be implemented as a separate activity function, which can be called by the orchestrator function and run in parallel with other actions in the loan process.

  Entity functions are designed for use cases where you need to perform operations on a shared piece of state in a reliable and atomic way, such as a distributed queue or counter. In this scenario, it does not appear that there is a need to use entity functions

- TODO The *exponential backoff* retry strategy is a technique for retrying failed operations in a manner that avoids overloading the system being accessed. It works by increasing the amount of time that is waited between each retry attempt, using an exponential function to calculate the wait time.

For example, with a coefficient of 2.0 and an initial retry interval of 1 second, the wait times between retries might be 1 second, 2 seconds, 4 seconds, 8 seconds, and so on. This allows the system being accessed to recover from any failures or load spikes before the next retry attempt is made, reducing the likelihood of further failures.


## Topic 3

- For Blob storage 
  - AcquireLeaseAsync does not specify leaseTime.
   leaseTime is a TimeSpan representing the span of time for which to acquire the lease, which will be rounded down to seconds. If null, an infinite lease will be acquired. If not null, this must be 15 to 60 seconds.
  - The GetBlockBlobReference method just gets a reference to a block blob in this container.
  - The BreakLeaseAsync method initiates an asynchronous operation that breaks the current lease on this container.

- **The archive access** tier has the lowest storage cost. But it has higher data retrieval costs compared to the hot and cool tiers. Data in the archive tier can take several hours to retrieve depending on the priority of the rehydration

- **BoundedStaleness** TODO
Bounded staleness: The reads are guaranteed to honor the consistent-prefix guarantee. The reads might lag behind writes by at most "K" versions (that is,
"updates") of an item or by "T" time interval. In other words, when you choose bounded staleness, the "staleness" can be configured in two ways:
The number of versions (K) of the item
The time interval (T) by which the reads might lag behind the writes


- TODO --sku B1 --is-linux (Multiple containers not allowed in Windows)
  --deployment-container-image-name images.azurecr.io/website:v1.0.0
  -- container set --docker-registry-server-url https://images.azurecr.io -u admin -p admin


- Service bus queue TODO
You are developing a back-end Azure App Service that scales based on the number of messages contained in a Service Bus queue.
  - ActiveMessageCount: Number of messages in the queue or subscription that are in the active state and ready for delivery.
  - Average
  For special metrics such as Storage or Service Bus Queue length metric, the threshold is the average number of messages available per current number of instances.
  - Less than or equal to
  You need to add a new rule that will continuously scale down the App Service, as long as the scale up condition is not met.
  - Decrease count by

- To update Metadata of a Blob storage
  - FetchAttributesAsync
  - Metadata.Add
  - SetMetadataAsync

- "*Device data from 2,000 stores located throughout the world.*" It is a distributed data streaming. Answer is EventHub

- Azure.Storage.Queues.QueueClient: .NET v12
  Azure.Storage.Queues.CloudQueueClient: .NET v11 (Legacy)

- Since we already have a premium P1 account with gpv1. Why not:
   - Upgrade the existing one to GPv2
   - Create a new GPV2 standard account with default access level to cool
   - And then copy archive data to the GPV2 and delete the data from original storage account.

- You can copy blobs, directories, and containers between storage accounts by using the AzCopy v10 command-line utility.
The copy operation is synchronous so when the command returns, that indicates that all files have been copied.

- Azure Instance Metadata Service 
   https://learn.microsoft.com/en-us/azure/virtual-machines/instance-metadata-service?tabs=windows
  - http://169.254.169.254/metadata/identity/oauth2/token
  Sample request using the Azure Instance Metadata Service (IMDS) endpoint (recommended).
  - JsonConvert.DeserializeObject<Dictionary<string,string>>(payload);
  Deserialized token response; returning access code.

- To form azure cosmos db partitions the best way is :
  - D. a concatenation of multiple property values with a random suffix appended 
  - E. a hash suffix appended to a property value Most Voted

- Azure comsos db feed processor components
  - *The monitored container*
    The monitored container has the data from which the change feed is generated. Any inserts and updates to the monitored container are reflected in the change feed of the container.

  - *The lease container*
    The lease container acts as a state storage and coordinates processing the change feed across multiple workers. The lease container can be stored in the same account as the monitored container or in a separate account.

  - *The host* : A host is an application instance that uses the change feed processor to listen for changes. Multiple instances with  the   same lease configuration can run in parallel, but each instance should have a different instance name.

  - *The delegate*
    The delegate is the code that defines what you, the developer, want to do with each batch of changes that the change feed processor reads.
    Reference:
    https://docs.microsoft.com/en-us/azure/cosmos-db/change-feed-processor


- Blob storage account only supports block and append blobs while General purpose storage accounts support block, append & page blobs (some exception apply - please see note about replication below). So if you need to create virtual machines, you would want to choose general purpose accounts over blob accounts

- Because it is ZRS, and that does not support arhive tier, it cannot be moved to archive tier even though the questions mention the red-herring key-word "infrequently accessed" (which triggers feelings for archive tier). For no logically apparent reason Microsoft decided not to support archive tier in ZRS

- Azure cosmos Db
  - InsertOrReplace should be used instead of Insert in case we need to replace a record . Insert will fail for the same
    partition Id .
  - Each game is assigned an Id based on the series title => That does not mean that the Id is automatically the partition .

- item id is a unique identifier and is suitable for the partition key. => TODO check partitionning on ComosDb

- With the lifecycle management policy, you can: Transition blobs from cool to hot immediately when they are accessed, to optimize for performance => *"enableAutoTierToHotFromCool": true*

- Azure Cosmos DB supports two indexing modes:
*Consistent* : The index is updated synchronously as you create, update or delete items. This means that the consistency of your read queries will be the consistency configured for the account.
*None* : Indexing is disabled on the container.

- Update the application to support multi-region writes
  - Update the ConnectionPolicy class for the Cosmos client and populate the PreferredLocations property based on the geo-proximity of the application
  - Update the ConnectionPolicy class for the Cosmos client and set the UseMultipleWriteLocations property to true

- *Azure Blob index tags*
  As datasets get larger, finding a specific object in a sea of data can be difficult. Blob index tags provide data management and discovery capabilities by using key- value index tag attributes. You can categorize and find objects within a single container or across all containers in your storage account. As data requirements change, objects can be dynamically categorized by updating their index tags. Objects can remain in-place with their current container organization.

- *Azure Cognitive Search*
  Only index tags are automatically indexed and made searchable by the native Blob Storage service. Metadata can't be natively indexed or searched. You must use a separate service such as Azure Search.
  Azure Cognitive Search is the only cloud search service with built-in AI capabilities that enrich all types of information to help you identify and explore relevant content at scale. Use cognitive skills for vision, language, and speech, or use custom machine learning models to uncover insights from all types of content.


- Delete only the snapshot (blob itself is retained)
  - blob_client.delete_blob(**delete_snapshots="only"**)

- Blob storage change feed client
  changeFeedClient.GetChanges(x).AsPages()
  x = c.ContinuationToken;

- *DateTimeBin(x, 'day', 2)* Returns the nearest multiple of BinSize below the specified DateTime given the unit of measurement DateTimePart and start value of BinAtDateTime.


- Change feed estimators : monitor change feed processors progress
  Dead-letter queues     : handle errors and are able to monitor failed attempts, require failed attempts and even trigger a follow-up action (remediation or response)

- A time-based retention policy stores blob data in a Write-Once, Read-Many (WORM) format for a specified interval. When a time-based     retention policy is set, clients can create and read blobs, but can't modify or delete them. After the retention interval has expired, blobs can be deleted but not overwritten.
  https://learn.microsoft.com/en-us/azure/storage/blobs/immutable-time-based-retention-policy-overview
 - Before you can apply a time-based retention policy to a blob version, you must enable support for version-level immutability.

- To update multiple documents for a username in a single ACID operation in Azure Cosmos DB, you need to ensure that the documents are stored in the same logical partition.
    To do this, you should perform the following actions:
    - Create an unsharded collection to store documents. This will ensure that all documents are stored in the same logical partition.
    Configure Azure Cosmos DB to use the MongoDB API. The MongoDB API supports multi-document ACID transactions, which allow you to update multiple documents in a single atomic operation.


## Topic 4

- Azure Cosmos DB now provides a new RBAC role, *Cosmos DB Operator*. This new role lets you provision Azure Cosmos accounts, databases, and containers, but can't access the keys that are required to access the data. This role is intended for use in scenarios where the ability to grant access to Azure Active Directory service principals to manage deployment operations for Cosmos DB is needed, including the account, database, and containers.

- FOr group authorization in the Azure AD application's manifest, set value of the groupMembershipClaims option to All.
  Reference TODO :
  https://blogs.msdn.microsoft.com/waws/2017/03/13/azure-app-service-authentication-aad-groups/


- groupMembershipClaims option to All usage
  - https://blogs.msdn.microsoft.com/waws/2017/03/13/azure-app-service-authentication-aad-groups/


- Azure Key vault
  - *Soft delete*
    When soft-delete is enabled, resources marked as deleted resources are retained for a specified period (90 days by default). The service   further provides a mechanism for recovering the deleted object, essentially undoing the deletion.

  - *Purge protection*
  Purge protection is an optional Key Vault behavior and is not enabled by default. Purge protection can only be enabled once soft-delete is enabled.
  When purge protection is on, a vault or an object in the deleted state cannot be purged until the retention period has passed. Soft-deleted vaults and objects can still be recovered, ensuring that the retention policy will be followed.

- The API documentation only allows 3 options. It states:
    Authentication policies
    Authenticate with Basic - Authenticate with a backend service using Basic authentication.
    Authenticate with client certificate - Authenticate with a backend service using client certificates.
    Authenticate with managed identity - Authenticate with the managed identity for the API Management service.
    TODO https://docs.microsoft.com/en-us/azure/api-management/api-management-authentication-policies


- The built-in *user_impersonation* scope indicates that the token is being requested on behalf of the user. Azure Storage exposes a single delegation scope named user_impersonation that permits applications to take any action allowed by the user.
 - delegated and User.Read/ Microsft Graph
  https://stackoverflow.com/questions/31404128/azure-ad-app-application-permissions-vs-delegated-permissions
  https://docs.microsoft.com/en-us/azure/active-directory/develop/v2-permissions-and-consent
  https://docs.microsoft.com/en-us/azure/storage/common/storage-auth-aad-app?tabs=dotnet
  https://docs.microsoft.com/en-us/rest/api/storageservices/authorize-with-azure-active-directory

- UseAuthentication, Use Authorization
  - *UseAzureAppConfiguration*
  https://docs.microsoft.com/en-us/azure/azure-app-configuration/enable-dynamic-configuration-aspnet-core?tabs=core5x

- Create a single user-assigned Managed Identity with permission to access Key Vault and configure each App Service to use that Managed Identity.
Because we have more than one App (Web App and other Function Apps) , So we agree it is going to be a managed identity but should I create one for each app or one for all apps?
If I create system MI then there should be one for each App.
If I create user MI then I can re-use it for any App I want with minimum change to AD

- *Client side encryption* is a valid method to do this. Asymmetric key can be used (RSA in keyvault). If using Asymetric key then client side encryption should be done with the public key because it can only be decrypted with a private key (which other people do not have). One will encrypt with private key only as a signature to prove she has the private key so that it can be verified with the public key.
  - *Cosmos Db not Good option*If storage is encrypted by default but you need to encrypt the content so when downloaded, its useless to unauthorised party.  
   Instead use an Azure Key vault and public key encryption. Store the encrypted from in Azure Storage Blob storage.

- 1. Get-AzSubscription
  2. Set-AzContext –SubscriptionId $subscriptionID
  3. Get-AzKeyVaultSecret –VaultName $vaultName
  4. Get-AzStorageAccountKey –ResourceGroupName $resGroup –Name $storAcct
  5. $secretvalue = ConvertTo-SecureString $storAcctkey –AsPlainText –Force
     Set-AzKeyVaultSecret –VaultName $vaultName –Name $secretName –SecretValue $secretvalue

- You must grant a virtual machine (VM) access to specific resource groups in Azure Resource Manager.
  You need to obtain an Azure Resource Manager access token .
  *Solution* : Instead run the Invoke-RestMethod cmdlet to make a request to the local managed identity for Azure resources endpoint


- Using CDN if the coming request are form an IPHONE
  1 *DeliveryRuleDeviceConditionParameters*- we are first checking for a device condition, hence we need to use the condition of DeliveryRuleDeviceConditionParameters
  2.*Mobile* - The devices can be either Desktop or Mobile. These are the two accepted values. Here since we need to route requests based on mobile devices, we need to choose the value of Mobile.
  3.*DeliveryRequestHeaderConditionParameters*. we need to understand the type of operating system running on the device. We can get this information from the request headers. Hence, we need to use the parameter of DeliveryRequestHeaderConditionParameters.
  4.*HTTP_USER_AGENT* - we can check the HTTP_USER_AGENT property in the request header. In the user agent property of the request header, you will normally get information about the environment where the request is originating from. An example is given below where I am showing the request header from my own machine when I browse to a site.
  5.*iOS* - we need to check the operating system which will be iOS.
  
- *Microsoft Graph* is a RESTful web API that enables you to access Microsoft Cloud service resources.
Instead in the Azure AD application's manifest, set value of the groupMembershipClaims option to All. In the website, use the value of the groups claim from the
JWT for the user to determine permissions.

- Azure AD users must be able to login to the website.
  Personalization of the website must be based on membership in Active Directory groups.
  - *Solution* TODO
     - groupMembershipClaims   : "All"
     - oauth2AllowImplicitFlow : true

- Common Blob storage event scenarios include image or video processing, search indexing, or any file-oriented workflow. Asynchronous file uploads are a great fit for events. When changes are infrequent, but your scenario requires immediate responsiveness, event-based architecture can be especially efficient.
  => *Create an Event Grid topic that uses the Start-AzureStorageBlobCopy cmdlet*

- *Front Door cache* : You need to purge individual assets from the Front Door cache.
  => *Solution* : Single path purge 
  - Single path purge: Purge individual assets by specifying the full path of the asset (without the protocol and domain), with the file extension, for example, /pictures/strasbourg.png;
  - Wildcard purge: Asterisk (*) may be used as a wildcard. Purge all folders, subfolders, and files under an endpoint with /* in the path or purge all subfolders and files under a specific folder by specifying the folder followed by /*, for example, /pictures/*.
  - Root domain purge: Purge the root of the endpoint with "/" in the path.

- Validate-jwt for Open ID, API, secure authentication. TODO

- APM 
  - Set-variable        : inbound
  - Cache-lookup-value  : inbound
  - Cache-store-value   : inbound
  - Find-and-replace    : Outbound
  - *LINK* : https://learn.microsoft.com/en-us/azure/api-management/api-management-sample-cache-by-key#fragment-caching


- In below example, the name of your key vault is expanded to the key vault URI, in the format 
  "https://<your-key-vault-name>.vault.azure.net". This example is using 'DefaultAzureCredential()' class from Azure Identity Library, which allows to use the same code across different environments with different options to provide identity. string keyVaultName = Environment.GetEnvironmentVariable("KEY_VAULT_NAME"); var kvUri = "https://" + keyVaultName + ".vault.azure.net"; var client = new SecretClient(new Uri(kvUri), new DefaultAzureCredential());
  Reference:
  *https://docs.microsoft.com/en-us/azure/key-vault/secrets/quick-create-net* TODO


- If you believe that a SAS has been compromised, then you should revoke the SAS. You can revoke 
  a user delegation SAS either by 
    - Revoking the user delegation key
    - Or by changing or removing RBAC role assignments for the security principal used to create the SAS."

- To perform a key transfer, a user performs following steps:
    ✑ Generate KEK.
    ✑ Retrieve the public key of the KEK.
    ✑ Using HSM vendor provided BYOK tool - Import the KEK into the target HSM and exports the Target Key protected by the KEK.
    ✑ Import the protected Target Key to Azure Key Vault.
     - Step 1: Generate a Key Exchange Key (KEK).
     - Step 2: Retrieve the Key Exchange Key (KEK) public key.
     - Step 3: Generate a key transfer blob file by using the HSM vendor-provided tool.
    Generate key transfer blob using HSM vendor provided BYOK tool
     - Step 4: Run the az keyvault key import command
    Upload key transfer blob to import HSM-key.
    Customer will transfer the Key Transfer Blob (".byok" file) to an online workstation and then run 
    a az keyvault key import command to import this blob as a new
    HSM-backed key into Key Vault.
    To import an RSA key use this command: az keyvault key import
    Reference:
    https://docs.microsoft.com/en-us/azure/key-vault/keys/byok-specification

- *User-assigned* keys are individual components. Even if the logic apps are deleted, the keys remain. But in case of system-assigned keys, those are auto generated and are deleted when the Azure resources themselves are deleted.


- Azure cosmos Db
  - You set the highest, or maximum RU/s Tmax you don't want the system to exceed. 
    The system automatically scales the throughput T such that 0.1* Tmax <= T <=Tmax.
    In this example we have autoscaleMaxThroughput = 5000, so the minimum throughput for the container is 500 R/Us.
  - First query: *SELECT * FROM c WHERE c.EmployeeId > '12345'*
    Here's a query that has a range filter on the partition key and won't be scoped to a single physical partition. In order to be an in-partition query, the query must have an equality filter that includes the partition key .
  - Consider the below query with an equality filter on DeviceId. If we run this query on a container partitioned on DeviceId, 
    this   query   will filter to a single physical partition.
    *SELECT * FROM c WHERE c.DeviceId = 'XMS-0001'*


- Applications and container orchestrators can perform unattended, or "headless," authentication by using an Azure Active Directory (Azure AD) **service principal**

- AcrPush provides pull/push permissions only and meets the principle of least privilege.

- When validating an Azure AD request in the app code, it is important to validate the ID **token signature** to ensure the authenticity of the token. The ID token contains information about the authenticated user, including the user's identity and any claims or permissions associated with the user. By validating the signature, you can ensure that the token has not been tampered with and that it was indeed issued by Azure AD.

- *APP registration*
  - 1. Select AD instance - select AD tenant in portal
  - 2. In App Registration, select new registration - use switched tenant
  - 3. Create a new application and provide the name

- Azure AD Multi-Factor Authentication and Conditional Access policies give the flexibility to enable MFA for users during specific sign-in events. The recommended way to enable and use Azure AD Multi-Factor Authentication is with Conditional Access policies.
You need a working Azure AD tenant with at least an Azure AD Premium P1.

- *FeatureGate*
  - https://docs.microsoft.com/en-us/azure/azure-app-configuration/use-feature-flags-dotnet-core https://csharp.christiannagel.com/2020/05/19/azureappconfiguration/ https://stackoverflow.com/questions/61899063/how-to-use-azure-app-configuration-rest-api


- The **oauth2AllowImplicitFlow** attribute Specifies whether this web app can request OAuth2.0 implicit flow access tokens. The default is false. This flag is used for browser-based apps, like JavaScript single-page apps.
In implicit flow, the app receives tokens directly from the Azure Active Directory (Azure AD) authorize endpoint, without any server-to-server exchange. All authentication logic and session handling is done entirely in the JavaScript client with either a page redirect or a pop-up box.


- A service SAS is secured with the storage account key. A service SAS delegates access to a resource in only one of the Azure Storage services: Blob storage, Queue storage, Table storage, or Azure Files.
Stored access policies give you the option to revoke permissions for a service SAS without having to regenerate the storage account keys.
Incorrect Answers:
*Account SAS* : Account SAS is specified at the account level. It is secured with the storage account key.
User Delegation SAS: A user delegation SAS applies to Blob storage only.

- **oid** -The object identifier for the user in Azure AD. This value is the immutable and non-reusable identifier of the user. Use this value, not email, as a unique identifier for users; email addresses can change. If you use the Azure AD Graph API in your app, object ID is that value used to query profile information.

- Add Key Vault secrets reference in the Function App configuration.
Syntax: **@Microsoft.KeyVault(SecretUri={copied identifier for the username secret})**
Reference: https://daniel-krzyczkowski.github.io/Integrate-Key-Vault-Secrets-With-Azure-Functions/

- You develop a Python application for image rendering that uses GPU resources to optimize rendering processes. You deploy the application to an Azure Container Instances (ACI) Linux container.
The application requires a secret value to be passed when the container is started. The value must only be accessed from within the container.
 :
    - A: Secure environment variables -
    Another method (another than a secret volume) for providing sensitive information to containers (including Windows containers) is through the use of secure environment variables.
    - E: Use a secret volume to supply sensitive information to the containers in a container group. The secret volume stores your secrets in files within the volume, accessible by the containers in the container group. By storing secrets in a secret volume, you can avoid adding sensitive data like SSH keys or database credentials to your application code.
    Reference:

- **Data Connect** grants a more granular control and consent model: you can manage data, see who is accessing it, and request specific properties of an entity. This enhances the Microsoft Graph model, which grants or denies applications access to entire entities.
Microsoft Graph Data Connect augments Microsoft Graph's transactional model with an intelligent way to access rich data at scale. The data covers how workers communicate, collaborate, and manage their time across all the applications and services in Microsoft 365.

- *AddAzureAppConfiguration* - Load data from App Configuration
  
- *ManagedIdentityCredential* Use managed identities to access App Configuration

- Using **CustomerProvidedKey**
https://docs.microsoft.com/en-us/azure/storage/blobs/storage-blob-customer-provided-key


- **Scope** is the parameter used to specify the permissions that the web application is requesting to access the user's resources, such as the calendar and the ability to send an email as the user. The scope parameter is typically included in the API call or in the authorization request sent to the Microsoft identity platform

- *Assign a managed identity to App1.*
To grant App1 access to Vault1 and automatically rotate credentials without storing them in code, you should assign a managed identity to App1. Managed identities for Azure resources enable Azure services to authenticate to other Azure resources without needing to manage the authentication details.
After you enable a managed identity for App1, you can grant the identity access to Vault1 and use Azure Key Vault's built-in rotation feature to automatically rotate the credentials.
Additionally, you can use Azure Key Vault's built-in rotation feature to automatically rotate the credentials

- **Always Encrypted** In order to configure Always Encrypted for the Java application, you need to first create a customer-managed key (CMK) using Azure Key Vault. This key will be used to encrypt and decrypt the sensitive data stored in Cosmos DB.
After creating the key, you should store it in a new Azure Key Vault instance, which will be used to manage and secure the key.
Once you have the key stored in Key vault, you can use Azure Cosmos DB SDK to encrypt the sensitive data and store it in Cosmos DB.
It's important to note that Always Encrypted in Azure Cosmos DB is a client-side encryption feature that encrypts and decrypts sensitive data inside the application and not in the Azure Cosmos DB service. TODO

- You develop a web app that interacts with Azure Active Directory (Azure AD) groups by using Microsoft Graph.
You build a web page that shows all Azure AD groups that are not of the type 'Unified'.
=> *~/groups?$filter=NOT groupTypes/any(c:c eq 'Unified')&$count=true*

- Check *SecretClient* and *DefaultAzureCredentials*

- from azure.identity import DefaultAzureCredential
from azure.appconfiguration import AzureAppConfigurationClient
credential = DefaultAzureCredential()
client = AzureAppConfigurationClient(base_url="your_endpoint_url", credential=credential)

- **DefaultAzureCredential** is a class provided by the Azure SDK for .NET that simplifies the process of authenticating with Azure services. It provides a way to chain multiple authentication mechanisms, such as environment variables, managed identities, and service principals, to obtain a credential that can be used to access Azure services.
When you use DefaultAzureCredential in your code, it automatically tries to authenticate using the available authentication mechanisms in a specific order. For example, it first tries to authenticate using a managed identity if it's available, then falls back to a service principal if that's available, and finally uses a shared token cache if both managed identity and service principal are unavailable.
This approach makes it easier for developers to write code that can run in different environments, such as locally, in a development environment, or in production, without having to modify the authentication code for each environment.
In summary, DefaultAzureCredential provides a convenient and flexible way to authenticate with Azure services, and it's a recommended way to obtain credentials for most Azure SDKs in .NET.

## Topic 5

- *Autoscaling*
  Configure the web app to the Standard App Service Tier
  The Standard tier supports auto-scaling, and we should minimize the cost.
  Enable autoscaling on the web app
  Add a scale rule 
  Add a Scale condition 

- You are developing and deploying several ASP.NET web applications to Azure App Service. You plan to save session state information and HTML output => Deploy and configure Azure Cache for Redis

- *Redis KeyDelete* to invalidate the cache : If you use StringSet you will set Teams to the value of Empty string and a future request to Teams will return an empty string and not null

- In the context of Azure, the terms Users, Funnels, Impact, Retention, and User Flows refer to different types of analytics or insights that can be obtained from user data.

  **Users**: This refers to the total number of unique users who have interacted with your application or service during a specified period of time. The Users metric is used to measure the overall reach and engagement of your application or service.

  **Funnels**: Funnels refer to a sequence of steps or events that a user must complete to achieve a specific goal, such as making a purchase or signing up for a service. The Funnels metric is used to measure how effectively users are moving through these steps, and to identify where users are dropping off in the conversion process.

  **Impact**: Impact refers to the changes in user behavior or metrics that result from specific changes or experiments in your application or service. The Impact metric is used to measure the effectiveness of different features or changes, and to identify areas for further optimization.

  **Retention**: Retention refers to the percentage of users who return to your application or service after their initial interaction. The Retention metric is used to measure user loyalty and engagement over time.

  **User Flows**: User Flows refer to the paths or routes that users take through your application or service. The User Flows metric is used to visualize and understand how users are navigating your application or service, and to identify areas for improvement or optimization.

  In summary, Users, Funnels, Impact, Retention, and User Flows are all different types of metrics or insights that can be used to understand user behavior and optimize the performance of your application or service in Azure.


- **The OpenAPI specification** (formerly known as Swagger) is an open standard that describes the interface of a RESTful API in a language-agnostic way. It defines a format for documenting APIs, including endpoints, parameters, responses, and other details, that enables developers to understand and interact with the API more easily.

- *Import-AzureRmApiManagementApi -Context $ApiMgmtContext -SpecificationFormat "Swagger" -SpecificationPath $SwaggerPath -Path $Path*
This command allows you to import the OpenAPI (formerly known as Swagger) specification of the news API into an Azure API Management instance, which enables you to expose the news API through the API Management gateway.


- To implement a reply trail auditing solution, you need to ensure that each transaction record includes information about the alarm type that was activated. This can be achieved by using the SessionID and MessageId properties of the hazard message.
Action A assigns the SessionID property of the hazard message to the ReplyToSessionId property. This ensures that when an alarm controller receives an alarm signal, it can reply back to the signaling server with the same SessionID, which can be used to correlate the reply with the original hazard message.
Action D assigns the MessageId property of the hazard message to the CorrelationId property. This ensures that each transaction record includes the MessageId of the original hazard message, which can be used to correlate the transaction record with the original hazard message.

- In a messaging system, such as Azure Service Bus, there are four important message properties that are used to manage and track messages. These properties are:

 - *MessageId*: A unique identifier that is assigned to each message by the sender. It can be used to track the message as it moves through the messaging system.
 - *SessionId*: A value that is used to group related messages together. If a sender wants to ensure that a group of messages is processed by the same receiver, it can assign the same SessionId to each message in the group.
- *CorrelationId*: A value that is used to link related messages together. If a sender wants to track a message and its associated replies, it can assign the same CorrelationId to each message in the conversation.
- *ReplyToSessionId*: A value that is used to specify the SessionId of the queue or subscription to which the reply message should be sent.
- The main differences between these properties are:
    *MessageId is a unique identifier assigned to each message, whereas SessionId and CorrelationId are values used to group and link related messages.
    SessionId is used to ensure that a group of related messages is processed by the same receiver, whereas CorrelationId is used to link related messages in a conversation.
    ReplyToSessionId is used to specify the SessionId of the queue or subscription to which the reply message should be sent, whereas SessionId is used to group related messages.
    In summary, these properties are all used to manage and track messages in a messaging system, but each has a slightly different purpose and use case.*

- **Azure Functions Premium plan** With the Premium plan the max outbound connections per instance is unbounded compared to the 600 active (1200 total) in a Consumption plan.
Note: The number of available connections is limited partly because a function app runs in a sandbox environment. One of the restrictions that the sandbox imposes on your code is a limit on the number of outbound connections, which is currently 600 active (1,200 total) connections per instance. When you reach this limit, the functions runtime writes the following message to the logs: Host thresholds exceeded: Connections.

- **Containers logs** To access the console logs generated from inside the container, first, turn on container logging by running the following command:
    - *az webapp log config --name <app-name> --resource-group <resource-group-name> --docker-container-logging filesystem*
   
   Once container logging is turned on, run the following command to see the log stream:
    - *az webapp log tail --name <app-name> --resource-group <resource-group-name>*
      If you don't see console logs immediately, check again in 30 seconds.

- There are three types of availability tests:
   - URL ping test: a simple test that you can create in the Azure portal.
   - Multi-step web test: A recording of a sequence of web requests, which can be played back to test more complex scenarios. Multi-step web tests are created in Visual Studio Enterprise and uploaded to the portal for execution.
   - Custom Track Availability Tests: If you decide to create a custom application to run availability tests, the TrackAvailability() method can be used to send the results to Application Insights.

- Caching type must be external since consumption plan does not support internal caching.
Downstream caching type must be private as it is not shared.
Vary by header must be authorization as it is cached per customer.

- **TrackAvailability** You can create an Azure Function with TrackAvailability() that will run periodically according to the configuration given in TimerTrigger function with your own business logic. The results of this test will be sent to your Application Insights resource, where you will be able to query for and alert on the availability results data.
This allows you to create customized tests similar to what you can do via Availability Monitoring in the portal. Customized tests will allow you to write more complex availability tests than is possible using the portal UI, monitor an app inside of your Azure VNET, change the endpoint address, or create an availability test even if this feature is not available in your region.

    ```
    public static class MyFunction
    {
        [FunctionName("MyFunction")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            // Configure the Azure Monitor Trace Exporter and OpenTelemetry Tracer Provider
            var exporter = new AzureMonitorTraceExporter(connectionString: "InstrumentationKey=<your-instrumentation-key>");
            var tracerProvider = new OpenTelemetryTracerProvider();
            tracerProvider.AddSpanProcessor(new SimpleExportSpanProcessor(exporter));

            // Initialize the tracer and start a span
            var tracer = tracerProvider.GetTracer("MyFunction");
            using (tracer.StartActiveSpan("MyFunction"))
            {
                // Call the TrackAvailability method to monitor the availability of an external resource
                var availabilityResult = tracer.TrackAvailability(
                    name: "External Resource",
                    uri: new Uri("https://www.example.com"),
                    success: true,
                    duration: TimeSpan.FromSeconds(2),
                    responseCode: "200",
                    runLocation: "eastus");

                // Log the availability result
                log.LogInformation($"Availability result: {availabilityResult.Result}");
            }

            return new OkObjectResult("Hello, world!");
        }
    }
    ```

- The app must retrieve user profile information by using a Microsoft Graph API call
    - Step 1: Register the application with the Microsoft identity platform.
    To authenticate with the Microsoft identity platform endpoint, you must first register your app at the Azure app registration portal
    - Step 2: Build a client by using the client app ID
    - Step 3: Create an authentication provider
    Create an authentication provider by passing in a client application and graph scopes.
    Code example:
    DeviceCodeProvider authProvider = new DeviceCodeProvider(publicClientApplication, graphScopes);
    // Create a new instance of GraphServiceClient with the authentication provider.
    GraphServiceClient graphClient = new GraphServiceClient(authProvider);
    - Step 4: Create a new instance of the GraphServiceClient
    - Step 5: Invoke the request to the Microsoft Graph API


- **Application insights** You must make the workspace in the portal
In Monitor you must add Application insights with the workspace
In Monitor you must activate VMInsights and add your VM's and assign a workspace to it
Then install and run the agents in each VM
    1. Create Log Analytics workspace (in Azure Portal)
    2. Create Application Insights resource (in Monitor, Application Insights with workspace attached)
    3. Add VMInsights solution (== activate VMInsights in Monitor, choose VM's, attach workspace).
    4. Install agents on VM


- In Redis, there are several data structures available to store data, including lists, sets, and channels. In addition, Redis also supports horizontal partitioning, which allows you to split a large dataset across multiple Redis instances.
Here's an overview of the differences between lists, sets, channels, and horizontal partitioning in Redis:
  - Lists:
    Lists are a collection of ordered elements, where elements can be added or removed from either end of the list. Lists in Redis are implemented as a linked list, which makes adding or removing elements from either end of the list very fast. Lists can be used for tasks such as message queues, job queues, and log storage.

  - Sets:
    Sets are a collection of unordered elements, where each element is unique. Sets in Redis are implemented as a hash table, which makes   adding, removing, and checking for the presence of an element very fast. Sets can be used for tasks such as keeping track of online   users, tracking unique visitors, and implementing caching.

  - Channels:
    Channels are a way to implement pub/sub messaging in Redis. Clients can subscribe to a channel and receive messages published to that   channel by other clients. Channels can be used for tasks such as implementing real-time chat, sending notifications, and broadcasting   events.

  - Horizontal Partitioning:
     Horizontal partitioning is a way to split a large dataset across multiple Redis instances. This can help to improve performance and    scalability by spreading the load across multiple machines. Redis supports two types of horizontal partitioning: sharding and    replication. Sharding involves splitting the dataset into smaller, more manageable pieces and storing each piece on a separate Redis    instance. Replication involves copying the dataset to multiple Redis instances, so that if one instance fails, another instance can    take over.

  In summary, lists and sets are data structures for storing collections of data, channels are a way to implement pub/sub messaging, and horizontal partitioning is a way to split a large dataset across multiple Redis instances to improve performance and scalability.


- You are developing an ASP.NET Core Web API web service. The web service uses Azure Application Insights for all telemetry and dependency tracking. The web service reads and writes data to a database other than Microsoft SQL Server.
You need to ensure that dependency tracking works for calls to the third-party database.
Which two dependency telemetry properties should you use? Each correct answer presents part of the solution
    ```
    public async Task Enqueue(string payload)
    {
    // StartOperation is a helper method that initializes the telemetry item
    // and allows correlation of this operation with its parent and children. 
    var operation = telemetryClient.StartOperation<DependencyTelemetry>("enqueue " + queueName);

    operation.Telemetry.Type = "Azure Service Bus";
    operation.Telemetry.Data = "Enqueue " + queueName;
    var message = new BrokeredMessage(payload);
    // Service Bus queue allows the property bag to pass along with the message.
    // We will use them to pass our correlation identifiers (and other context)
    // to the consumer.
    message.Properties.Add("ParentId", operation.Telemetry.Id);
    message.Properties.Add("RootId",   operation.Telemetry.Context.Operation.Id);
    ```
- Front Door can dynamically compress content on the edge, resulting in a smaller and faster response to your clients. All files are eligible for compression.
  - However, a file must be of a MIME type that is eligible for compression list.
  - Sometimes you may wish to purge cached content from all edge nodes and force them all to retrieve new updated assets. This might be due to updates to your web application, or to quickly update assets that contain incorrect information.
  - These profiles support the following compression encodings: Gzip (GNU zip), Brotli
  - Reference: https://docs.microsoft.com/en-us/azure/frontdoor/front-door-caching


- CDN caching available modes :
  - Three query string modes are available:
    - **Ignore query strings**: Default mode. In this mode, the CDN point-of-presence (POP) node passes the query strings from the requestor to the origin server on the first request and caches the asset. All subsequent requests for the asset that are served from the POP ignore the query strings until the cached asset expires.
    - **Bypass caching for query strings**: In this mode, requests with query strings are not cached at the CDN POP node. The POP node retrieves the asset directly from the origin server and passes it to the requestor with each request.
    - **Cache every unique URL**: In this mode, each request with a unique URL, including the query string, is treated as a unique asset with its own cache. For example, the response from the origin server for a request for example.ashx?q=test1 is cached at the POP node and returned for subsequent caches with the same query string. A request for example.ashx?q=test2 is cached as a separate asset with its own time-to-live setting.

- **Azure Monitor**
  - DynamicThresholdCriterion: Dynamic thresholds in metric alerts use advanced machine learning to learn metric
  - Http5XX, just a name , we are monitoring server errors, so 500 range error reponses
  - AlertSensitvity : Low The thresholds will be loose with more distance from metric series pattern. An alert rule will only trigger on large deviations, resulting in fewer alerts => Less false positive

- Azure Cache for redis eviction policies
  - *allkeys-lru policy* evict keys by trying to remove the less recently used (LRU) keys first, in order to make space for the new data added. Use the allkeys-lru policy when you expect a power-law distribution in the popularity of your requests, that is, you expect that a subset of elements will be accessed far more often than the rest.
  - *volatile-lru*: evict keys by trying to remove the less recently used (LRU) keys first, but only among keys that have an expire set, in order to make space for the new data added.
  - *allkeys-lru* policy is more memory efficient since there is no need to set an expire for the key to be evicted under memory pressure.
   Reference: https://redis.io/topics/lru-cache


- In the context of Azure Redis Cache, eviction refers to the process of removing or expiring keys from the cache to free up memory space. Redis is an in-memory data store, which means that it stores data in memory for faster access. However, since memory is a limited resource, it is important to manage the memory usage in Redis to prevent running out of memory.
Eviction can occur in Azure Redis Cache for a variety of reasons. One common reason is when the cache reaches its maximum memory limit. In this case, Redis will automatically evict keys based on a set of eviction policies to free up memory space for new data.
There are several eviction policies that can be configured in Azure Redis Cache, including:
 - *LRU* (Least Recently Used): This policy evicts the least recently used keys first.
 - *LFU* (Least Frequently Used): This policy evicts the least frequently used keys first.
 - *TTL* (Time to Live): This policy evicts keys that have expired based on their Time to Live (TTL) setting.
By default, Azure Redis Cache uses the LRU eviction policy. However, you can configure the eviction policy to meet the specific needs of your application.
In summary, eviction in Azure Redis Cache is the process of automatically removing or expiring keys from the cache to manage memory usage and prevent running out of memory.

- **App insights Live Metrics Stream :**
Deploying the latest build can be an anxious experience. If there are any problems, you want to know about them right away, so that you can back out if necessary. Live Metrics Stream gives you key metrics with a latency of about one second.
With Live Metrics Stream, you can:
  * Validate a fix while it's released, by watching performance and failure counts.
  * Etc.

- **Application insights**
  - *Smart detection* automatically warns you of potential performance problems and failure anomalies in your web application. It performs proactive analysis of the telemetry that your app sends to Application Insights. If there is a sudden rise in failure rates, or abnormal patterns in client or server performance, you get an alert. This feature needs no configuration. It operates if your application sends enough telemetry.
  - *Snapshot Debugger*
  When an exception occurs, you can automatically collect a debug snapshot from your live web application. The snapshot shows the state of source code and variables at the moment the exception was thrown. The Snapshot Debugger in Azure Application Insights monitors exception telemetry from your web app. It collects snapshots on your top-throwing exceptions so that you have the information you need to diagnose issues in production.
  - *Profiler*
  Azure Application Insights Profiler provides performance traces for applications running in production in Azure. Profiler:
  Captures the data automatically at scale without negatively affecting your users.
  Helps you identify the ג€hotג€ code path spending the most time handling a particular web request.
  Reference:
  https://docs.microsoft.com/en-us/azure/azure-monitor/app/proactive-diagnostics https://docs.microsoft.com/en-us/azure/azure-monitor/snapshot-debugger/snapshot-debugger https://docs.microsoft.com/en-us/azure/azure-monitor/profiler/profiler-overview


- **Redis disaster recovery**
The Premium tier allows you to persist data in two ways to provide disaster recovery:
  - RDB persistence takes a periodic snapshot and can rebuild the cache using the snapshot in case of failure.
  - AOF persistence saves every write operation to a log that is saved at least once per second. This creates bigger files than RDB but has less data loss.
   - So AOF has less data loss which satisfies the requirement.
   - So AOF with data written is a second storage account with ZRS should do the job.
  https://learn.microsoft.com/en-us/training/modules/develop-for-azure-cache-for-redis/3-configure-azure-cache-redis

- **On-call developer is not paged** To ensure that the on-call developer is not paged during offline processing while still logging when the application is offline, you can create an Azure Monitor action group that suppresses the alerts during that time. This action group can be configured to temporarily suspend alerts or send them to a different channel, such as an email or a different paging system.
  - **More Context**
    An on-call developer, also known as an on-call engineer or a pager-duty engineer, is a software developer who is responsible for responding to and resolving incidents outside of regular business hours. This typically involves being available on a rotating basis to receive notifications or alerts about system or application issues that require immediate attention.
    The on-call developer is often part of a larger incident response team, which includes other developers, operations personnel, and support staff. When an incident occurs, the on-call developer is responsible for assessing the severity of the issue, determining the root cause, and taking steps to resolve it as quickly as possible.
    In the context of Azure Monitor, the on-call developer would be the person who is responsible for receiving and responding to alerts generated by the monitoring system. By creating an action group that suppresses alerts during offline processing, the on-call developer can avoid being paged unnecessarily and can focus on addressing issues that require immediate attention. This helps to improve the overall reliability and availability of the application, while also reducing the burden on the on-call developer.


- **Application Insights SDK features**
  - *Sampling*              : Reduce the volume of telemetry without affecting statistics
  - *Telemetry Initializer* : Enrich telemetry with additional properties or override existing ones
  - *Telemetry processor*   : Completly replace or discard a telemetry item

- Streams seismicData : XREAD BLOCK $ TODO


## Topic 6

- Topics allows multiple subscribers, and here we need to process each event once
  - correlation filter is for subscriptions, not topics
  - even when assuming there is typo in the question and correlation filter is defined on the subscription level - it still is not a valid solution, because new stores can be opened in the future with many new device identifiers which you can't know in advance. Besides that filter make no sense in this scenario whatsoever, you just need to save data in storage account and basically partition it by device identifier.

- **Azure Queue Storage** : When you call the **GetMessageAsync** method on an Azure Storage Queue, it retrieves the next message in the queue and makes it invisible to other consumers. This is known as "peek-locking" the message. The message is still in the queue, but it's not visible to other consumers while it's being processed by the consumer that retrieved it.
Once the consumer has finished processing the message, it must call the CompleteAsync method to remove the message from the queue. If the consumer fails to complete the message (for example, due to an error or crash), the message will become visible to other consumers after the visibility timeout period expires. This allows another consumer to pick up and process the message.
If the consumer wants to defer processing of the message, it can call the AbandonAsync method, which releases the message lock and makes the message visible to other consumers. The message will remain in the queue, but it will be available for another consumer to process.
If the consumer wants to keep the message locked but not process it immediately, it can renew the message lock using the RenewMessageAsync method. This extends the lock timeout period, allowing the consumer to continue processing the message without fear of it becoming visible to other consumers.

- **Azure Service Bus** provides two main messaging entities: Queues and Topics/Subscriptions. While Queues are ideal for point-to-point communication, Topics/Subscriptions are designed for publish/subscribe scenarios.
The main difference between Queues and Topics is that Queues provide a one-to-one messaging pattern, while Topics provide a one-to-many messaging pattern. When you send a message to a Queue, it is received by only one receiver. On the other hand, when you send a message to a Topic, it can be received by multiple Subscribers, each with its own subscription filter.
Topics/Subscriptions allow you to create a single message channel to which multiple Subscribers can subscribe, whereas Queues are designed to deliver messages to a single receiver. Topics provide a more flexible way of routing messages to multiple receivers and enabling publish/subscribe messaging scenarios.
Topics also provide additional features such as subscription filters, which enable you to selectively receive only the messages you're interested in. Additionally, Topics support dead-lettering, which enables you to move failed messages to a dedicated queue for troubleshooting and analysis.
In summary, while Queues are ideal for point-to-point communication, Topics/Subscriptions provide a more flexible and scalable way of routing messages to multiple Subscribers and enable publish/subscribe messaging scenarios. Therefore, if you need to deliver messages to multiple receivers or implement a publish/subscribe pattern, Topics/Subscriptions are the better choice.

- Queue Storage does not provide transactional support and Event Hub can't be configured to store events for infinite time.

- To configure backend authentication for an API Management service instance that is hosting a RESTful service backend implemented in Azure App Service, you would use the following:

  - **Target: HTTP(s) endpoint**
  - **Gateway credential type: Basic or Client Cert**
  You would specify the URL of the RESTful service backend hosted in Azure App Service as the HTTP(s) endpoint target for backend authentication. The endpoint URL should be in the format of https://<app-service-name>.azurewebsites.net.

  - For the gateway credential type, you can choose either Basic authentication or Client Certificate authentication. Basic authentication requires a username and password to be provided in the request headers, while Client Certificate authentication requires a client certificate to be presented by the caller.
  Which one to choose depends on the security requirements and constraints of your backend. Basic authentication is easier to set up but less secure than client certificate authentication, as the credentials are transmitted in plain text. Client certificate authentication is more secure but requires additional configuration, as you need to upload a client certificate to the API Management instance and configure the backend to accept requests with client certificates.
  In summary, to configure backend authentication for an API Management service instance hosting a RESTful service backend implemented in Azure App Service, you would use an HTTP(s) endpoint as the target and either Basic or Client Certificate authentication as the gateway credential type, depending on the security requirements and constraints of your backend.


- You are creating an app that uses Event Grid to connect with other services. Your app's event data will be sent to a serverless function that checks compliance.
This function is maintained by your company.
You write a new event subscription at the scope of your resource. The event must be invalidated after a specific period of time.
You need to configure Event Grid.
 - **Answer** 
    - *Webhook event delivery* : SAS Token
    - *Topic publishing*       : ValidationCode handshake


- **APM**
  - Use the set-backend-service policy to redirect an incoming request to a different backend than the one specified in the API settings for that operation. Syntax:
    <set-backend-service base-url="base URL of the backend service" />
  - The condition is on 512k, not on 256k.
  - The set-backend-service policy changes the backend service base URL of the incoming request to the one specified in the policy.
  Reference:
  https://docs.microsoft.com/en-us/azure/api-management/api-management-transformation-policies

- **Publish-subscribe model** It is strongly recommended to use available messaging products and services that support a publish-subscribe model, rather than building your own. In Azure, consider using Service Bus or Event Grid. Other technologies that can be used for pub/sub messaging include Redis, RabbitMQ, and Apache Kafka.

- Using topic client, call RegisterMessageHandler which is used to receive messages continuously from the entity. It registers a message handler and begins a new thread to receive messages. This handler is waited on every time a new message is received by the receiver.  **subscriptionClient.RegisterMessageHandler(ReceiveMessagesAsync, messageHandlerOptions);**


- Azure Event Grid
  - Blob storage events are pushed using Azure Event Grid to subscribers such as Azure Functions, Azure Logic Apps, or even to your own http listener. Event Grid provides reliable event delivery to your applications through rich retry policies and dead-lettering.
  - Event Grid uses event subscriptions to route event messages to subscribers. 
  - The Event Grid service doesn't store events. Instead, events are stored in the Event Handlers, including ServiceBus, EventHubs, Storage Queue, WebHook endpoint, or many other supported Azure Services.

- Interacting with Azure storage Queue 
  ```
    // Retrieve storage account from connection string
    CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
        CloudConfigurationManager.GetSetting("StorageConnectionString"));
    // Create the queue client
    CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
    // Retrieve a reference to a queue
    CloudQueue queue = queueClient.GetQueueReference("myqueue");
    // Create the queue if it doesn't already exist
    queue.CreateIfNotExists();
  ```

- A software as a service (SaaS) company provides document management services. The company has a service that consists of several Azure web apps. All
Azure web apps run in an Azure App Service Plan named PrimaryASP.
You are developing a new web service by using a web app named ExcelParser. The web app contains a third-party library for processing Microsoft Excel files.
The license for the third-party library stipulates that you can only run a single instance of the library.
  - Set-AzAppServicePlan -ResourceGroupName $ResourceGroup `
      -Name $AppServicePlan -PerSiteScaling $true
  - Get the app we want to configure to use "PerSiteScaling"
    $newapp = Get-AzWebApp -ResourceGroupName $ResourceGroup -Name $webapp
    Modify the NumberOfWorkers setting to the desired value.
    $newapp.SiteConfig.NumberOfWorkers = 1
    Post updated app back to azure
    Set-AzWebApp $newapp


- **Input vs Backend** The main difference between the two types of policies is the stage at which they are executed. Backend policies are applied to the request and response as they are sent and received by the backend service, while inbound policies are applied before the request is sent to the backend service.
In summary, while there may be some overlap in the functionality of backend and inbound policies, they serve different purposes and are applied at different stages of the API request lifecycle.

- Event Hubs enables granular control over event publishers through publisher policies. Publisher policies are run-time features designed to facilitate large numbers of independent event publishers. With publisher policies, each publisher uses its own unique identifier when publishing events to an event hub.

- **Health check and Diagnostic setting**
  - Health check increases your application's availability by re-routing requests away from unhealthy instances, and replacing instances if they remain unhealthy. Your App Service plan should be scaled to two or more instances to fully utilize Health check.

  - Diagnostic setting
    Azure provides built-in diagnostics to assist with debugging an App Service app.
    With the new Azure Monitor integration, you can create Diagnostic Settings to send logs to Storage Accounts, Event Hubs and Log Analytics.

- Throttling policies for Azure Event Hubs can be used to manage the rate of incoming requests and prevent overload or abuse of the Event Hubs service. Throttling policies can be applied at the namespace level or at the Event Hub level, and can be configured to limit the number of requests per unit of time or to block requests altogether when a certain threshold is exceeded

- **Event Hub Application groups**
An application group is a collection of client applications that connect to an Event Hubs namespace sharing a unique identifying condition such as the security context - shared access policy or Azure Active Directory (Azure AD) application ID.
Azure Event Hubs enables you to define resource access policies such as throttling policies for a given application group and controls event streaming (publishing or consuming) between client applications and Event Hubs.

- When a user redeems a one-time passcode and later obtains an MSA, Azure AD account, or other federated account
  they'll continue to be authenticated using a one-time passcode. If you want to update the user's authentication method, 
  you can reset their **redemption status.**"


- Azure API management forwarding requests in case of large images treatement
  - exists-action="delete"
  - set-backend-service="base-url"

- ## Question #2 TOPIC 31 ##