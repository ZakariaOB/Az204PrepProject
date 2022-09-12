- Application Object - Blob objects
   - The idea behind application is that we can assign an identity of an app to an azure object
   - We can do more with application object compared to access keys as you will be able to add specific role to your assignment .
   - For a specific tenant the application object is called servcice prinipal
   - For example for a storage account the storage key will give all permissions on a given Blob
   - If we assign permissions based on a given app the permissions could be more granular
   - TODO what is the difference between : Application object and Service principal
   - In in the examples we are basically using the application object , when to use the service principal
   - To add client secret just use : client_secrets
   - After changing the role assignement you will basically need some time before see the changes

- Microsoft Graph API
  - Allow us to get information about the users/groups
  - You should authorize your self to use information about the users and microsoft Graph
  - Let us use POSTMAN to access to Microsoft graph
  - We will need an access token to provide for POSTMAN to be able to access Microsoft Graph
  - We will need another Application object for example : POSTMAN 
  - But we will use the existing blobapplication to avoid creating apps on the principal tenant
  - You can use API/Delegated permissions
  - We will check later the difference between Application permissions and delegated persmissions
  - Why do we options azure storage at 'Add Permissions' section ? => Should be explained later
  - Add permissions > Microsoft Graph > Application Permissions
  - I cannot Grant admin consent at SQLI directory level
  - Application permissions > Run on behalf of an application
  - Delegated permissions > on behalf of the user
  - You will need the endpoint of the application object > Endpoints
  - After using the right access data you will be able to get an access token to use with microsoft graph api 
  - Authorization Bearer hapap ....
  - Make sure to always have the permission at 'Add permissions' level of the application object
  - You can also update a user with Microsoft Graph you will only need to use the right permissions : User.ReadWrite.All

- Azure Key Vault
  - Storing encryption keys, secrets or certificates
  - Encryption key 
    > Key vault > Generate import
  - To access the key vault we can use our application object : blobapplication
  - In order to give access to our app to use the key vault we should use Key vault > Access policies and not use Access control .
  - Key permissions > Get, Encrypt, Dycrept
  - Select principal and use 'blobapplication'

- Azure Key vault secrets
  - You can as well do the same for secrets
  - You can store them at Key vault level and access your secret using application object not by permissions but by 'Access policies'
  - You can also put access keys for a storage account for exampe as vault secrets 

- Managed identities
  - The idea is about assigning an identity to an object so the usage of application objects will ne be mandatory anymore .
  - Object : Could be a virtual machine for example .
  - This way the need to embed : Access keys, screts etc .. inside the application will not be necessary anymore .
  - Let us try to get a token to be able to access the storage account
  - For a given VM in order to create an Identity you need to go to VM > Identity > Status to ON 
  - It's possible to use the RDP file and give access to your local C drive !!! (Nice trick)
  - C:\Users\zboukhris\source\repos\SecureApps204
  - You will need also the .NET 6 runtime
  - After that if you run the application you will see that it has access to the blob storage


- Managed identities (Get access tokens)
  - We can get the token ourselves instead of using 
        'TokenCredential tokenCredential = new DefaultAzureCredential();'
  - What was applied to a VM could be also applied to a Web app
    - Just add role assignement for the wep app
    - You will have access to the blob as a result


- User assigned managed identity
  - User assigne identity has a different lifecycle
  - If you create a system assignd identity and link it to a VM it's linked to the VM and will be deleted once the VM is deleted .
  - User assigned identity is different , it's a standalone on it's self
  - If we have an azure function or a Web app for example we can assign the same user identity to both of them .
  - VM created : (Zakaria, ZakariaAz@20152015)
  - After defining your 'User assigned identity' you can use it to grant access to different resources : For example Blob storage
  - With user assigned identities you can grant different permissions to different Azure objects related to a specific managed user identity .
  - It's also possible to assign a 'user assigned identity' using Powershell
  - Check powershell scripts
