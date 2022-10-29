// See https://aka.ms/new-console-template for more information

using ServiceBusAz204.Entities;
using ServiceBusAz204.Operations;

string connectionString =
    "Endpoint=sb://servicebusaz204z.servicebus.windows.net/;SharedAccessKeyName=buspolicy;SharedAccessKey=ZLO1Awf7dJgPwIe/Ee+ktS/1mENmLzVn3cg0eQS7g5o=;EntityPath=queue204";

string topicConnectionString =
    "Endpoint=sb://servicebusaz204z.servicebus.windows.net/;SharedAccessKeyName=policyone;SharedAccessKey=sO1L1ZbxEPGLxV6lQJigL4WgXoNmUlKrYrIWgtsSzTo=;EntityPath=apptopic204";

string queueName = "queue204";

string topicName = "apptopic204";

string subscriptionA = "SubscriptionA";

string subscriptionB = "SubscriptionA";

List<Order> orders = new ()
{
    new Order(){OrderId ="1987",Quantity=100,UnitPrice=9.99F},
    new Order(){OrderId ="1988",Quantity=200,UnitPrice=10.99F},
    new Order(){OrderId ="1989",Quantity=300,UnitPrice=8.99F}
};

Ops ops = new (connectionString, queueName, topicConnectionString);

// await ops.SendMessage(orders);

// await ops.PeekMessages();

// await ops.GetMessagesProperties();

// await ops.SendMessagesWithAdditionProperties(orders);

// await ops.GetMessagesWithAdditionalProperties();

// await ops.GetMessagesUsingProcessor();

// await ops.SendTopicMessages(orders, topicName);

await ops.ReceiveTopicsMessages(topicName, subscriptionA);

await ops.ReceiveTopicsMessages(topicName, subscriptionB);

Console.WriteLine("Hello, World!");
