# Azure Functions

 You will always need a function APP to create inside it your functions

- You have to define an OS for the Functions, because behind it you have a VM with an OS
  using it .
- [First Azure Function App](./1_Apps/FunctionAz204)
- Get function will execute after a Get requests
- GET METHOD : You can receive the query parameters and use them
- POST METHOD : You can get the data from the Body of the request

# Azure function accessing a database

- You can create a database server using
  - [GO TO Terraform template to create Azure SQL database](./0_Scripts/0_Terraform/2_AzureSqlDb/main.tf)
  - Allow IP access to 
- The usage of the ```[assembly: FunctionsStartup(typeof(MyNamespace.Startup))]``` attribute is to specify the startup class for your Azure Functions host.
- Accessing the connection string seems to not be working properly . Instead use :
  ```
    "Values": {
    "AzureWebJobsStorage": "UseDevelopmentStorage=true",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet",
    "ProductConnectionString": "Your connection here"
  },
  ```
  - Add *ProductConnectionString* as an Application settings in the function app
  - Use ``` Environment.GetEnvironmentVariable("ProductConnectionString") ```
  - TODO think about injecting an IConfigurationProvider to get the connection string
  

- Isolated and InProc modes: https://learn.microsoft.com/en-us/azure/azure-functions/dotnet-isolated-process-guide

# Durable functions 

- Durable functions
   - Azure functions are stateless this is why we use Durable functions
   - We will need an orchatrator function
   - TODO (Not in the exam)

