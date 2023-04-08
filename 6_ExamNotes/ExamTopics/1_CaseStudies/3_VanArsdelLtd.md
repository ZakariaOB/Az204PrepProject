- Store delivery driver profile information in Azure Active Directory (Azure AD) by using an Azure Function called from the corporate website
  - *Code Library* : MSAL
  - *API*          : Microsoft Graph

- **A shared access signature (SAS)** provides secure delegated access to resources in your storage account. With a SAS, you have granular control over how a client can access your data. For example:
What resources the client may access.
What permissions they have to those resources.
How long the SAS is valid.
Note: Inventory services:
The company has contracted a third-party to develop an API for inventory processing that requires access to a specific blob within the retail store storage account for three months to include read-only access to the data.

- **JSON Web Tokens (JWTs)** have three main components: a header, a payload, and a signature. The header contains information about the type of token and the signing algorithm used. The payload contains the claims or data that are being conveyed by the token. The signature is used to verify that the token was not tampered with during transmission.

Based on the contents of the payload, there are two types of JWT tokens:
  - Access Tokens: These tokens are used to grant access to a resource or service. The payload of an access token typically contains information about the user, such as their ID or email address, and the permissions or roles they have been granted. Access tokens are usually short-lived and expire after a set period of time.
  - Refresh Tokens: These tokens are used to obtain a new access token when the current access token expires. The payload of a refresh token typically contains information about the user, but does not include any permissions or roles. Refresh tokens are usually long-lived and can be revoked by the server at any time.

- **ID Tokens** are a type of JWT that is used to represent the authentication of a user. ID Tokens are issued by an identity provider (IdP) such as an OAuth 2.0 or OpenID Connect (OIDC) provider after a user has successfully authenticated.
ID Tokens contain information about the user, such as their unique identifier, name, email address, and other user attributes, as well as metadata about the authentication event itself, such as the time of the authentication, the identity provider that issued the token, and the scope of the authentication.
ID Tokens are typically used by clients, such as web or mobile applications, to verify the identity of the user and obtain additional information about them. Unlike access tokens, ID tokens are not used for access control or authorization. Instead, they are used to provide information about the authenticated user to the client application.

- You need to reliably identify the delivery driver profile information.
  - JWT web token       : ID
  - Payload claim value : Oid

- All Azure Functions must centralize management and distribution of configuration data for different environments and geographies, encrypted by using a company-provided RSA-HSM key.
Microsoft Azure Key Vault is a cloud-hosted management service that allows users to encrypt keys and small secrets by using keys that are protected by hardware security modules (HSMs).

- You need to create a managed identity for your application.

- **Audit the retail store sales transactions**
  - Process the change feed logs of the Azure Blob storage account by using an Azure Function. Specify a time range for the change feed data.
  The change feed provides a way to log changes to blobs in a storage account. By using an Azure Function to process the change feed logs, it is possible to track and audit sales transaction information. The time range for the change feed data can be specified to capture the transactions within a specific time period.
  - Subscribe to blob storage events by using an Azure Function and Azure Event Grid. Filter the events by store location.
  Azure Event Grid allows subscribing to events raised by Azure services or third-party services. By using an Azure Function and Event Grid, it is possible to filter the events for a specific store location and track sales transactions. This approach can help to monitor sales transactions in real-time and provide an audit trail for reconciliation.

- Corporate website best option
    - Plan    : Standard
    - Service : App service Web App


- You must perform a point-in-time restoration of the retail store location data due to an unexpected and accidental deletion of data.
Before you enable and configure point-in-time restore, enable its prerequisites for the storage account: 
  - Soft delete
  - Change feed
  - Blob versioning

- **Point-in-time** restore is a feature available in Azure Blob Storage that allows you to restore your data to a specific point in time. This means you can recover your blob data as it existed at a certain moment in the past, which can be very useful in case of accidental deletion, overwrites, or other data loss scenarios.
To perform a point-in-time restore, you need to have a blob storage account with versioning enabled. Versioning allows the storage service to maintain multiple versions of a blob, so you can go back in time and restore a previous version. Once versioning is enabled, you can use the Azure portal, Azure CLI, or other tools to restore your blob data to a specific point in time.
The point-in-time restore feature is particularly useful when you need to recover from a ransomware attack or other malicious activity that alters your data. With point-in-time restore, you can restore your data to a point just before the attack occurred, and avoid paying the ransom or losing your data permanently.
It is important to note that there may be additional costs associated with point-in-time restore, as it requires additional storage to keep the version history of your blobs. Therefore, it is recommended that you carefully review the pricing details before enabling versioning and using point-in-time restore.