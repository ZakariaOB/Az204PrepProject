- For the Microsoft Graph API, we need to use the User.Read permission. This is also given in the Microsoft documentation

- oauth2Permissions can only accept collections value like an array not a boolean. It should be oauth2AllowImplicitFlow.
    Link: https://docs.microsoft.com/en-us/azure/active-directory/develop/v2-oauth2-implicit-grant-flow

- To get all the groups the user is a part of, you need to set the “groupMembershipClaims”

- Which of the following action would be applicable to allow a team to contact Microsoft support
    “Microsoft.Support/*”

-  TLS mutual authentication has been configured and you need to validate the client certificate in the Web App.
Which of the following would be the encoding type for the certificate : Base64
  https://docs.microsoft.com/en-us/azure/app-service/app-service-web-configure-tls-mutual-auth

- The way to grant access for the Azure Web App service to the Key Vault service is given
   https://docs.microsoft.com/en-us/azure/app-service/app-service-key-vault-references

- TODO Azure B2B, one can go to the below link
https://docs.microsoft.com/en-us/azure/active-directory/b2b/what-is-b2b

- TODO Recheck usage of Integrated Security=SSPI

- You have to ensure you use the right technique to get valid links for the processing reports. Which of the following would you implement for this?
  => Create a SharedAccessBlobPolicy and set the expiry time to two weeks from today. Call GetSharedAccessSignature on the blob and use the resulting link

- TODO To ensure that Azure Sql connection is encrypted you should 
  - Set Encrypt=True
  - Set TrustServerCertificate=False

- A development team needs to setup an API Management instance in Azure. Then authentication needs to be done via the use of client certificates.
Which of the following needs to be done first to ensure client certificates can be used for authentication with the API Management instance
   => Enable SSL on the API Management instance

- What are security scopes ?

- You would perform the key creation process of an azure keyvault using the service principal.
  - TODO To recheck
  - Using the POST method

- Azure keyvault Key creation process : https://skillcertlabvault.vault.azure.net/keys/demokey/create?api-version=7.0

- TODO recheck az storage account update > --assign-identity

- Use CloudBlob not CloudBlobContainer

- You can create an Account level shared access signature to restrict access to Azure Table storage
  For more information on shared access signatures, please visit the below URL
  https://docs.microsoft.com/en-us/azure/storage/common/storage-dotnet-shared-access-signature-part-1

- TODO : Check azure access signature possibilities

- Origin http://test.montana.com/ is therefore not allowed access’
  - Here we have to add the URL that is not being granted access.

- The best way to connect to the ACR is by using a Service principal
  -  https://docs.microsoft.com/en-us/azure/container-registry/container-registry-authentication