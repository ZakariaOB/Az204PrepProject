- If an anomaly is detected, an Azure Function that emails administrators is called by using an HTTP WebHook. endpointType: The type of endpoint for the subscription (webhook/HTTP, Event Hub, or queue).
  => EndPointType : Webhook
    - All Azure App Service Web Apps must write logs to Azure Blob storage. All log files should be saved to a container named logdrop. Logs must remain in the container for 15 days.
            {
            "properties": {
            "destination": {
            **"endpointType": "webhook"**,
            "properties": {
            "endpointUrl": "https://example.azurewebsites.net/api/HttpTriggerCSharp1?code=VXbGWce53l48Mt8wuotr0GPmyJ/nDT4hgdFj9DpBiRt38qqnnm5OFg=="
            }
            },
            "filter": {
            **"includedEventTypes": [ "Microsoft.Storage.BlobCreated", "Microsoft.Storage.BlobDeleted" ]**,
            **"subjectBeginsWith": "blobServices/default/containers/mycontainer/log"**,
            [1]
            "isSubjectCaseSensitive ": "true"
            }
            }
         }
    - The idea behind this case is that the EventGrid should react to the events added after populating the Blob storage .



- Application Insights provides three additional data types for custom telemetry:
  - **Trace**: used either directly, or through an adapter to implement diagnostics logging using an instrumentation framework that is familiar to you, such as Log4Net or System.Diagnostics.
  - **Event**: typically used to capture user interaction with your service, to analyze usage patterns.
  - **Metric**: used to report periodic scalar measurements.
    Scenario:
    Policy service must use Application Insights to automatically scale with the number of policy actions that it is performing.
    => **Answer** : **Metric**


- EventId is held by class EventGridController
  - You **can add properties to telemetry by implementing ITelemetryInitializer** which defines the Initialize method.
  - ITelemetry.Context.Properties is correct, but shouldnt be used any more as obsoloete

    public class IncludeEventId : ITelemetryInitializer
    {
        public void Initialize (ITelemetry telemetry)
        {
            telemetry.Context.Properties["EventId"] = EventgridController.EventId.Value;
        }
    }

- You need to add code in EventGridController.cs to ensure that the Log policy applies to all services
  if (@event["data"]["**status**"].ToString() == "Suceeded") 
  &&
  (@event["data"]["**operationName**"].ToString() == "Microsoft.Web/sites/write") 


- Event Grid **dataVersion** is the schema version of the data object. The publisher defines the schema version.
Scenario: Authentication events are used to monitor users signing in and signing out. All authentication events must be processed by Policy service. Sign outs must be processed as quickly as possible.
The following example shows the properties that are used by all event publishers:
      [
      {
      "**topic**": string,
      "**subject**": string,
      "**id**": string,
      "**eventType**": string,
      "eventTime": string,
      "data":{
        object-unique-to-each-publisher
      },
      "**dataVersion**": string,
      "metadataVersion": string
      }
      ]


- **EnsureLogging** 
    - All log files should be saved to a container named logdrop.
    - Logs must remain in the container for 15 days.
    - **UpdateApplicationSettings** : All Azure App Service Web Apps must write logs to Azure Blob storage.


- **Azure Functions Always On** can run on either a Consumption Plan or a dedicated App Service Plan. If you run in a dedicated mode, you need to turn on the Always On setting for your Function App to run properly. The Function runtime will go idle after a few minutes of inactivity, so only HTTP triggers will actually "wake up" your functions. This is similar to how WebJobs must have Always On enabled.
Scenario: Notification latency: Users report that anomaly detection emails can sometimes arrive several minutes after an anomaly is detected.
Anomaly detection service: You have an anomaly detection service that analyzes log information for anomalies. It is implemented as an Azure Machine Learning model. The model is deployed as a web service.
If an anomaly is detected, an Azure Function that emails administrators is called by using an HTTP WebHook.
