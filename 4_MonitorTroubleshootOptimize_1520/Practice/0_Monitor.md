- Azure monitor 
  - You can create alerts on azure monitor
  - Create alert rule
  - Define a scope : Metrics depends on a resource => CPU usage threshold
  - After creating the alert rule you can define an action to take place
  - For example : Sending en Email
  - You can link an alert rule to multiple actio groups

- Azure Monitor - Dynamic thresholds
  - This use Machine learning to check history
  - 70% is a static threshold
  - Sensitivity => small deviations will trigger the alert
  - Threshold sensitiviy => High, Medium or High

- Log Analytics workspace
  - You can check a resource => Azure Web app
  - For a virtual machine an extension will be installed : Microsoft Monitor Agent
  - After we need to decide the data to be collected
  - We can see tables at workspace : Event, Heartboeat, Syslog

- Azure Web App - Diagnostic
  - At every resource you can find Diagnostic settings where you can collect different data
  - Http logs
  - If you go to Diagnostic setting you can select different logs to use

- ARM Templates - Action Groups
  - We can use arm template to create action groups
  - Go to : Template deployment (deploy using custom templates)
  - Build my own template in the editor
  - You can go to monitor > Alerts > you will find alert group created after executing the 
    template template01.json
  - An action group is an email receiver for example

- ARM Templates - Azure Monitor Metrics
 - Check template02.json
 - PT5M => Over a period of 5 minutes
 - "actionGroupId": "[resourceId('Microsoft.Insights/ActionGroups', 'alertgroup')]"
 - This will use the action group previously created

 - ARM Templates - Dynamic Metric alerts
   - Make sure that : "odata.type": "Microsoft.Azure.Monitor.MultipleResourceMultipleMetricCriteria"
   - Dynamic metric alerts 
      ```
         - "alertSensitivity": "Medium",
                               "failingPeriods": {
                                   "numberOfEvaluationPeriods": "4",
                                   "minFailingPeriodsToAlert": "3"
                               }} 
      ```

- Log Analytics Query Alert - PowerShell
  - Script.ps1
