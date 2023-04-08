- Your team has developed an application API based on the OpenAPI specification. You have to ensure that he API can be accessed via an Azure API management service instance. Which of the following Azure powershell command would you run =>  
  <b>New-AzureRmApiManagement -ResourceGroupName $skillcertlabs-rg -Name $skillcertlabsname -Location $Location -Organization "skillcertlabs" -AdminEmail $skillcertlabsadmin</b>

- For the Event typre schema always try : id, topic, eventype

- “A find-and-replace policy to update the response body with the user profile information” => Outbound

- If the average number of Active messages in a service bus queue is greater than 1000 => To scale down you will need less than or equal

- Topics are only consumed through subscriptions

- It is better to create separate topics. Since the sign-outs need to be processed immediately, you should create a separate topic for the sign in a separate topic for the sign-out process.

- Azure Search : Ability to search the index by using regular expressions : queryType
  https://docs.microsoft.com/en-us/azure/search/search-query-overview

- Azure Search : “Ability to organize results by counts for name-value pairs” : Facets
  https://docs.microsoft.com/en-us/azure/search/search-filters-facets

- For more information on troubleshooting Azure Logic Apps, one can go to the below link
https://docs.microsoft.com/en-us/azure/logic-apps/logic-apps-diagnosing-failures
   - Review the run history.
   - Review the trigger history.

-  -Destination "Software"
   We have to ensure a software key is created for the disk encryption
   https://docs.microsoft.com/en-us/azure/virtual-machines/windows/encrypt-disks

- TODO Since you need to update the latest messages during the normal synchronization cycles, you can use the incremental sync operation. You can also use the sorting for the updatedAt column. This is also mentioned in the Microsoft documentation as given below.
  https://docs.microsoft.com/en-us/azure/app-service-mobile/app-service-mobile-offline-data-sync


- TODO If you have multiple topics, then an order needs to be sent to all topics. Then deleting an order once it has been picked by a driver will an issue. So, Option A gets ruled out.
  => This config could not use topics


- There is no 
    az webapp config redis 
    But : az webapp config appsettings

- You have to ensure that data is streamed from the Event Hub to Azure BLOB storage
  TODO : Event Hubs Capture

- Batch service context 
  - List<ResourceFile> whizlabInputFiles = new List<ResourceFile>();
  - Using  BatchSharedKeyCredentials

- CRON every 2 hours : 0 0 */2 * * *”

- "A find-and-replace" policy to update the response body with the user profile information” => Inbound !!!
  This seems like an Outbound .
  TODO https://docs.microsoft.com/en-us/azure/api-management/api-management-sample-send-request

- AppRoles usage at API Level : Expose API

- TODO Recheck topics and multiple subscriptions

- Since the question already states that we have a resource group and namespace in place, we can just use the “New-AzureRmServiceBusQueue” to create a new queue in the namespace.
