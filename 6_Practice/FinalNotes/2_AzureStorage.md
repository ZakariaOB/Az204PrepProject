- Since we need to copy it to a container, we have to mention the full URI of the container
An example of this is given in the Microsoft documentation
  => azcopy cp "/path/to/file.txt" "https://[account].blob.core.windows.net/[container]/[path/to/blob]"
  - Docs : https://docs.microsoft.com/en-us/azure/storage/common/storage-use-azcopy-v10

- TODO ComosDb : For more information on synthetic partition keys, please visit the following URL
https://docs.microsoft.com/en-us/azure/cosmos-db/synthetic-partition-keys

- Since we are passing in a table parameter, and this would be a reference to our cloud table, we would need to use the CloudTable data type.
TODO https://docs.microsoft.com/en-us/azure/cosmos-db/table-storage-how-to-use-dotnet

- If we need to retrieve an entity based on the partition and row key , we will need to use the TableOperation method : TableOperation query = TableOperation.Retrieve(p_partitionkey,p_rowkey)
  TODO : Choosing the right api for our cosmos db database .