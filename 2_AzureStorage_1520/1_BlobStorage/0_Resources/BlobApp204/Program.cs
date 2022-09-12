// See https://aka.ms/new-console-template for more information

using BlobApp204.BlobOperations;

string connectionString
    = "DefaultEndpointsProtocol=https;AccountName=az204store;AccountKey=x/39mWYpvFPVV01Ts6KyVUsCFj2v+okMmPrsrJ/XftQeh6SzUnMS7kAJZscmNLhyZTa4WcgEHcTG+AStBjmrFA==;EndpointSuffix=core.windows.net";

string containerName = "scripts";

string fileName = "ScriptOne.sql";

// Create a container
// await BlobOps.CreateContainer(connectionString, containerName);

// Upload a Blob
// string filePath = @"C:\Users\zboukhris\Downloads\looplab_final\ScriptOne.sql";
// string fileName = "ScriptOne.sql";
// await BlobOps.UploadBlob(connectionString, containerName, fileName, filePath);

// Listing Blobs
// await BlobOps.ListBlobs(connectionString, containerName);


// Download a Blob
// string filePath = @"C:\Users\zboukhris\Downloads\looplab_final\ScriptOne.sql";
// await BlobOps.DownloadBlob(connectionString, containerName, fileName, filePath);


// Set MetaData
// await BlobOps.SetBlobMetaData(connectionString, containerName, fileName);


// Get Metadata
// await BlobOps.GetMetaData(connectionString, containerName, fileName);


// Acquire a Lease
await BlobOps.AcquireLease(connectionString, containerName, fileName);

Console.WriteLine("End processing ... !");
