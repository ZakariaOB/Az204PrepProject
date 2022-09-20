using Az204StorageQueue.Operations;

string connectionString = "DefaultEndpointsProtocol=https;AccountName=az204storez;AccountKey=aXWbZ9EcfuWMkKpF00xjrhbJgY5M0r70I0FHR2w+6VpC1tAn5EXGTL9FRNC0e6VGKzTusb8+d5Jz+ASt3TgEGg==;EndpointSuffix=core.windows.net";

string queueName = "az204storagequeuez";


Ops operations = new (connectionString, queueName);

// Send messages
// operations.SendMessage("Random message of a 204 prep !!!");


// Peek Messages
// operations.PeekMessages();


// Receive Messages
// operations.ReceiveMessage();


// Send Base64 messages
await operations.SendMessageInBase64("TheOr14Zakaria", 55);

// Peek the base 64 Messages
//await operations.PeekMessagesInBase64();

// See https://aka.ms/new-console-template for more information
Console.WriteLine("End of Execution !!!");

Console.ReadKey();
