using EventHub204.Entities;
using EventHub204.Operations;

string connectionString = "Endpoint=sb://az204eventhubs.servicebus.windows.net/;SharedAccessKeyName=connectionstring;SharedAccessKey=bWABZgLsG/MDO3ayCsjBkGFJyNpaVZXYo6KNkmgUMBs=;EntityPath=az204eventhub";

string eventHubName = "az204eventhub";

List<Device> deviceList = new()
{
    new Device() { DeviceId = "D1",Temperature=40.0f},
    new Device() { DeviceId = "D1",Temperature=39.9f},
    new Device() { DeviceId = "D2",Temperature=36.4f},
    new Device() { DeviceId = "D2",Temperature=37.4f},
    new Device() { DeviceId = "D3",Temperature=38.9f},
    new Device() { DeviceId = "D4",Temperature=35.4f},
};

Ops operations = new(connectionString, eventHubName);

// await operations.SendData(deviceList);

// await operations.GetPartitionIds();

// await operations.ReadEvents();


await operations.SendDataUsingPartitions(deviceList.Where(e => e.DeviceId == "D1"), "D1");

await operations.SendDataUsingPartitions(deviceList.Where(e => e.DeviceId == "D2"), "D2");

await operations.SendDataUsingPartitions(deviceList.Where(e => e.DeviceId == "D3"), "D3");

await operations.SendDataUsingPartitions(deviceList.Where(e => e.DeviceId == "D4"), "D4");

await operations.ReadEventsFromDifferentPartitions();

Console.WriteLine("Hello, World!");
