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

- APIM : If backend is accepts HTTP(S) Then Basic AUTH or Certificate will work.

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

- **Question 28**