- The Application needs to log information onto Application Insights. You have to enable logging. You also have to ensure that log messages can be correlated to events tracked by Application Insights :
   - Configure(o =>  o.IncludeEventId = true)
   - logger.AddApplicationInsights( app.ApplicationServices, LogLevel.Critical);

- The team is complaining on Log capacity issues due the amount of trace messages provided by Application Insights. Which of the following could be used to resolve the issue
  => Implement Application Insights Sampling.

- In Application Insights, if you go to Usage and estimated costs, you have the option to set a Daily cap. This can allow you to control costs for the Application Insights resource.