using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;

namespace BlobApp204.BlobOperations
{
    internal static class BlobOps
    {
        public static async Task CreateContainer(string connectionString, string containerName)
        {
            BlobServiceClient blobServiceClient = new(connectionString);

            Console.WriteLine("Creating the container");

            await blobServiceClient.CreateBlobContainerAsync(containerName);

            /*
            If you want to specify properties for the container

            await blobServiceClient.CreateBlobContainerAsync(containerName,Azure.Storage.Blobs.Models.PublicAccessType.Blob);
            */
            Console.WriteLine("Container creation complete");
        }

        public static async Task UploadBlob(
            string connectionString, 
            string containerName, 
            string blobName, 
            string filePath)
        {
            BlobContainerClient blobServiceClient = new (connectionString, containerName);

            BlobClient blobClient = blobServiceClient.GetBlobClient(blobName);
            
            await blobClient.UploadAsync(filePath, true);

            Console.WriteLine("Uploaded the blob");
        }

        public static async Task ListBlobs(string connectionString, string containerName)
        {
            BlobContainerClient blobContainerClient = new(connectionString, containerName);

            await foreach (BlobItem blobItem in blobContainerClient.GetBlobsAsync())
            {
                Console.WriteLine("The Blob Name is {0}", blobItem.Name);
                Console.WriteLine("The Blob Size is {0}", blobItem.Properties.ContentLength);
            }
        }

        public static async Task DownloadBlob(
            string connectionString,
            string containerName,
            string blobName,
            string filePath)
        {
            BlobContainerClient blobServiceClient = new(connectionString, containerName);

            BlobClient blobClient = blobServiceClient.GetBlobClient(blobName);

            await blobClient.DownloadToAsync(filePath);

            Console.WriteLine("Uploaded the blob");
        }

        public static async Task SetBlobMetaData(
            string connectionString,
            string containerName,
            string blobName)
        {

            BlobClient blobClient = new (connectionString, containerName, blobName);

            IDictionary<string, string> metaData = new Dictionary<string, string>
            {
                { "Department", "Logistics" },
                { "Application", "AppA" }
            };

            await blobClient.SetMetadataAsync(metaData);

            Console.WriteLine("Metadata added");
        }

        public static async Task GetMetaData(
            string connectionString,
            string containerName,
            string blobName)
        {
            BlobClient blobClient = new (connectionString, containerName, blobName);
            
            BlobProperties blobProperties = await blobClient.GetPropertiesAsync();

            foreach (var metaData in blobProperties.Metadata)
            {
                Console.WriteLine("The key is {0}", metaData.Key);
                Console.WriteLine("The value is {0}", metaData.Value);
            }
        }

        public static async Task AcquireLease(
            string connectionString,
            string containerName,
            string blobName)
        {

            BlobClient blobClient = new (connectionString, containerName, blobName);

            BlobLeaseClient blobLeaseClient = blobClient.GetBlobLeaseClient();
            
            TimeSpan leaseTime = new (days: 0, hours: 0, minutes: 1, seconds: 00);

            Response<BlobLease> response = await blobLeaseClient.AcquireAsync(leaseTime);

            Console.WriteLine("Lease id is {0}", response.Value.LeaseId);
        }
    }
}
