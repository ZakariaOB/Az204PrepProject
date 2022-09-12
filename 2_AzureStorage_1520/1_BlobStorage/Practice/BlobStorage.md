- Storage accounts types
  - *Standard general purpose V2* : Blobs, file shares, queues and tables
  - *Premium Page blobs*          : Page blobs , when you want fast access to your blobs with high transaction rates
  - *Premium Block blobs*         : For block and append blobs

- We have 2 types of storage accounts : Standard and Premium

- At data storae account level you can have
  - Containers (Blobs)
  - File shares
  - Queues 
  - Tables

- Blobs : Are optimized for storing large amounts of unstructrued data

- Blobs types 
    - *Block blobs*  : blocks of data that can be managed individually
    - *Append blobs* : Optimized for append operations > Good for logging
    - *Page blobs*   : Could be used for virtual hard drive files

- At container level you can create folders by using : *Upload to a folder* when uploding a Blob
  a file to a container .

- If you need to give access to blobs inside your container , you can simply change 'Access Level' and then your blobs will be accessible . But it's not secure .

- Different authorization techniques
  - Access keys
  - Shared access signatures
  - Azure active directory

- *Azure storage explorer* : Is a way to explore storage account content/blobs without using the azure portal .

- *Acces keys* 
  - The rotate key feature will make the key unavailable (in case it was leaked)
  - You can use Azure storage explorer in order to get access to a storage account container by using Acces keys
  - Acces keys used with Azure storage explorer provide a way to access a storage account without using the portal and require full access .

- *Shared access signatures (At resource level)*
  - Sas is powerfull way to handle accessing to resources in Azure
  - Go to the resouce / Generate SAS
  - A shared access signature (SAS) is a URI that grants restricted access to an Azure Storage blob. Use it when you want to grant access to storage account resources for a specific time range without sharing your storage account key. Learn more about creating an account SAS

- *Shared access signatures (At account level)*
  - A shared access signature (SAS) is a URI that grants restricted access rights to Azure Storage resources. You can provide a shared access signature to clients who should not be trusted with your storage account key but whom you wish to delegate access to certain storage account resources. By distributing a shared access signature URI to these clients, you grant them access to a resource for a specified period of time.
  An account-level SAS can delegate access to multiple storage services (i.e. blob, file, queue, table). Note that stored access policies are currently not supported for an account-level SAS.
  - You can use azure storage explorer with SAS at account level


- *Stored acces policy*
  - You can make a SAS invalid by using a stored access policy
  - You can in addition to the SAS add an *access policy* to add additional restrictions in case an issue occured and your SAS was leaked somehow .
  - TODO to check this in more details or using an example
 
- Different types of SAS : https://az204store.blob.core.windows.net/?sv=2021-06-08&ss=bf&srt=sco&sp=rwdlaciytfx&se=2022-08-22T18:54:54Z&st=2022-08-22T10:54:54Z&spr=https&sig=EFTLoGH3xENxjvuLSU1NVFv%2FTzyi4OZoDARomESGufM%3D

- *Authorization using Azure AD*
  - Lecture 119 : it's also possible to use azure AD with azure storage explorer
  - Azure storage explorer : Add a new user
  - At storage level you will need to add a role assignement
  - Role : Storage account contibutor

- *Access tier*
  - Hot, cool and Archive access tier
  - Hot     : Frequently accessed dat
  - Cool    : Infrequent access (At least 30 days)
  - Archive : Rarely accessed data and stored for at least 180 days
  - Acces tier is defined at storage account level
  - You can also change access at object level by using 'Change Tier'
  - *Archive* : Setting the access tier to "Archive" will make your blob inaccessible until it is rehydrated back to "Hot" or "Cool", which may take several hours. 

- *Acces tier life cycle management at account level*
  - Life cycle mangement > Add rule

- *Rehydrate time*
  - Setting the access tier to "Archive" will make your blob inaccessible until it is rehydrated back to "Hot" or "Cool", which may take several hours.

- *Blob versionning*
 - We can activate blob versionning and after every blob change a new version could be created
 - We can make the new version as the current one if needed .
 - TODO 126

- *Blob Snapshot*
  - A snapshot is an actual copy of the blob at a given time that could be created (Not in an automatic way)

- *Retention perido and soft delete*
  - Data protection > Enable soft delete
  - You can define a retention period that can be used to get back the objects deleted
  - By the default the retention period is 7 days


- *.NET blobs*
  - Upload and download a Blob are quite similar

- *Blob metadata*
  - Key value pair that could be defined at blob level

- *Blob Lease*
  - Locking the object in order to be sure that no other application will modify the blob at the same time .
  - https://docs.microsoft.com/en-us/rest/api/storageservices/lease-blob


- *AzCopy Tool*
  - Tool to manipulate Blobs
  - It's a command tool to manage blobs
  - Methods of authorization : AD or SAS
  - Check the BlobApp204 for the differen set of available commands
  - Make sure for the commands to append the container and blob names and then after to put the SAS .

- *Moving a storage account to another region*
  - There is no direct way
  - Steps : [Moving a storage account to another region](https://docs.microsoft.com/en-us/azure/storage/common/storage-account-move?tabs=azure-portal)

- *Azure Blob change feed*
  - It provides an ordered guaranteed, durable, immutable, read-only log of changes .
  - When activated a new container is creatd : $blobchangefeed


- *Azure table storage*
  - TODO to recheck Azure table storage