- You will always need a function APP to create inside it your functions

- You have to define an OS for the Functions, because behind it you have a VM with an OS
  using it .

- Get function will execute after a Get requests

- GET METHOD : You can receive the query parameters and use them

- POST METHOD : You can get the data from the Body of the request

LET US USE VISUAL studio
- You can create your Azure Function on visual studio and 
then publish it to your Azure Function APP

- Demo using Azure Sql database
   - adminzak
   - AdminZ@K1987

- You can create your function and connect it directlty to Sql server

- You also create a POST method : Check source code demos of Alan Rodrigues

- You can store the connection string directlty on Azure
    > string _connection_string = Environment.GetEnvironmentVariable("SQLAZURECONSTR_SQLConnectionString");

- Check issue with : 52:16 - Azure Functions – Using connection strings
  > Connection strings naming
     https://stackoverflow.com/questions/55303414/azure-functions-v2-connectionstring-from-application-settings

- Durable functions
   - Azure functions are stateless this is why we use Durable functions
   - We will need an orchatrator function
   - TODO To recheck a proper Demo 