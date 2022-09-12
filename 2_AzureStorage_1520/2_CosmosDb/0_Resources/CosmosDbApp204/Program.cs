// See https://aka.ms/new-console-template for more information
using CosmosDbApp204.Operations;

Console.WriteLine("Hello, World!");

string cosmosDBEndpointUri = "https://cosmosz204.documents.azure.com:443/";

string cosmosDBKey = "s7KTKDDHEf98UXwkCCNfgU4CzwqWTCRRzEBXZncqg6uZWCP1GUJVZUhgPWMJt16anATxnA6pPcRip7NjEGCxwA==";

ComosDbOps cosmosDbOps = new (cosmosDBEndpointUri, cosmosDBKey);

// Create DataBase and container

//await cosmosDbops.CreateDataBase("appdb204v2");
//await cosmosDbops.CreateContainer("appdb204v2", "Orders", "/category");


// Add Items
// await cosmosDbOps.AddSomeItems();

// Read Items
// await cosmosDbOps.ReadItems("appdb204v2", "Orders");


// Replace Items
// await cosmosDbOps.ReplaceItems("appdb204v2", "Orders");

// Delete Items
// await cosmosDbOps.DeleteItems("appdb204v2", "Orders");


// Call simple stored procedure
// await cosmosDbOps.CallStoredProcedure("appdb204v2", "Orders");

// Call Insertion stored procedure
// await cosmosDbOps.CallInsertionStoredProcedure("appdb204v2", "Orders");

// Insert an Item using Trigger
await cosmosDbOps.CreateItemUsingTrigger("appdb204v2", "Orders");


Console.ReadKey();