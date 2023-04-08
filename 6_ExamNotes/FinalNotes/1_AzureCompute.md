- Service Plan D1 : Shared infrastructure 1 GB in Memory . 240 minutes/day compute

- the App service plan must support the “Always On” feature. And this is supported with the Basic App Service Plan

- To get a live tail of the logs, we need to use the “az webapp log tail” command

- To connect to ACR it's not allowed to assign role-based access control or even allowed to use headless authentication . 
    - You need to do as follow : az acr login --name <acrName>
    - TODO https://docs.microsoft.com/en-us/azure/container-registry/container-registry-authentication

- Deploy code from a public GitHub repository using --repo-url :  
   az webapp deployment source config --name $webapp --resource-group $resourceGroup \
   --repo-url $gitrepo --branch master --manual-integration

- This is how we define an entry point in a Dockerfile : We use 'dotnet'
  ENTRYPOINT ["dotnet", " MySingleContainerWebApp.dll "]

- ArcPush RBAC => Can Push or Pull the image

- ArcPull RBAC => Can only Pull image

- Ability for a WebJob to run based on a schedule should be Triggered

- Retry polices 
  ```
  var policy = Policy
      .Handle<Execption>()
      .WaitAndRetryAsync(3,a=>TimeSpan.FromMilliseconds(200 * Math.Pow(2, attempt - 1));
  ```

- TODO recheck  host.json (Azure Functions) / function.json

- Azure registry
  - az acr create

- config cors
  - az webapp cors add --allowed-origins ...

- You can use a concatenation of multiple property values and also use a suffix.

