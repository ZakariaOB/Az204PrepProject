- For the Microsoft Graph API, we need to use the User.Read permission. This is also given in the Microsoft documentation

- oauth2Permissions can only accept collections value like an array not a boolean. It should be oauth2AllowImplicitFlow.
    Link: https://docs.microsoft.com/en-us/azure/active-directory/develop/v2-oauth2-implicit-grant-flow

- To get all the groups the user is a part of, you need to set the “groupMembershipClaims”

- Which of the following action would be applicable to allow a team to contact Microsoft support
    “Microsoft.Support/*”

-  TLS mutual authentication has been configured and you need to validate the client certificate in the Web App.
Which of the following would be the encoding type for the certificate : Base64
  https://docs.microsoft.com/en-us/azure/app-service/app-service-web-configure-tls-mutual-auth

- "A find-and-replace" policy to update the response body with the user profile information” => Inbound !!!
  This seems like an Outbound .
  TODO https://docs.microsoft.com/en-us/azure/api-management/api-management-sample-send-request

- The way to grant access for the Azure Web App service to the Key Vault service is given
   https://docs.microsoft.com/en-us/azure/app-service/app-service-key-vault-references

- TODO Azure B2B, one can go to the below link
https://docs.microsoft.com/en-us/azure/active-directory/b2b/what-is-b2b

- TODO Recheck usage of Integrated Security=SSPI

- You have to ensure you use the right technique to get valid links for the processing reports. Which of the following would you implement for this?
  => Create a SharedAccessBlobPolicy and set the expiry time to two weeks from today. Call GetSharedAccessSignature on the blob and use the resulting link
