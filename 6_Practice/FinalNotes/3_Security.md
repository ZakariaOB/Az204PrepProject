- For the Microsoft Graph API, we need to use the User.Read permission. This is also given in the Microsoft documentation

- oauth2Permissions can only accept collections value like an array not a boolean. It should be oauth2AllowImplicitFlow.
    Link: https://docs.microsoft.com/en-us/azure/active-directory/develop/v2-oauth2-implicit-grant-flow

- To get all the groups the user is a part of, you need to set the “groupMembershipClaims”