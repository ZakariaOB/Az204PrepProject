- Application Insights - Configure the SDK locally
  - You can install some librairies to use the telemetry locally in visual studio
  - The part responsible of that is : Application Insights search

- Azure Application Insights
  - After creating an deploying a new Azure Web app you can go to 
   'Application Insights (preview)'
  - Remove dependency from local project to attach our project to Azure platform
  - Once delployed another resource insightapp204z/Application Insights is deployed
  - If you do some actions at App service level you will see live changes at insights level

- Application Insights - Performance data
  - At application insights level it's possible also to check de dependency to an sql database .
  - We can also see sql commands in application insights


- Application Insights - Usage Features
  - Users   : You can see how many users have used your applications
  - Session : Activity of your application . Pages mostly viewed
  - Funnels : How users are progressing through your app
  - Cohorts : Users, sessions or events that have something in common
  - Impact  : How load times and other aspects impact the conversion rate of your application
  - Retention : How many users return back to your application
  - User flows : What do users click on a page within your application etc ..*

- Application Insights - Availability Tests
  - You can create a Standard (preview) test

- Application Insights - Tracking Users
  - Use (TelemetryService : TelemetryInitializerBase) => 6_AppInsightsTrackingUsers
  - ```telemetry.Context.User.AuthenticatedUserId = platformContext.User?.Identity.Name ?? string.Empty;```