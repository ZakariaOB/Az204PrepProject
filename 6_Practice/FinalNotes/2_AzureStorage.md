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

- A Table Scan does not include the PartitionKey and is very inefficient because it searches all of the partitions that make up your table in turn for any matching entities. It will perform a table scan regardless of whether or not your filter uses the RowKey. For example: $filter=LastName eq 'Jones'
  https://learn.microsoft.com/en-us/azure/storage/tables/table-storage-design-for-query

- --enable-automatic-failover true
  Since we have to ensure that the data needs to be available even in the case of network outages or any unforeseen failures

- Since here the requirement is that the user must never see out-of-order writes, the most cost-effective option is to use the “Consistent prefix” consistency level.
  https://docs.microsoft.com/en-us/azure/cosmos-db/consistency-levels

- Here since the query is performed on a property that is not related to the Partition Key, all the rows from the table will be fetched. The Microsoft documentation mentions the following :
  https://docs.microsoft.com/en-us/azure/storage/tables/table-storage-design-for-query