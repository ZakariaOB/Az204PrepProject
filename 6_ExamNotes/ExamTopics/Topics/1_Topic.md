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

