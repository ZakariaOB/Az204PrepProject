- Introduction
    - It's always better to use Azure for security to benefit from : MFA for example, password  hashed etc ..
    - Authentication : Azure active directory which is the identity provider here
    - Authorization : Using tokens
    - Othe identity providers : Linkedin, Facebook, Google etc ..
    - Authorization is Azure is compliant with OAuth2

- OAuth2 standard
  - This the process has authorization to access an object
  - Steps (Authorization code flow)
     - Log in as user to our Web application
     - The application will authenticate the user via AD
     - When it comes to authorization if the user want to access an image 
     - The application will use User permissions to access the storage account

- OAuth2 Authorization Code Grant
  - Microsoft identity platform is the identity server => Will grant access tokens
  - Access token will be based on the user permissions
  - Steps 
    - From the app : First handshak with identity server to share a redirect URI
    - The identity server will send an authorization code
    - The application then needs to use the authorization code to get an access token
    - The process of getting the token will be done by the app in the backend

- Recap
  - Intially to communicate with the Blob storage we have used an account key on our application
  - But this is not a good idea as we can do whatever we want with this account key
  - Better approach is to use the application object with ClientCredentials class using (clientId, tenantId, clientSecret)
  - Better approach is to have a get an access token and use it then to make requests
  - The Client Credentials grant type is used by clients to obtain an access token outside of the context of a user
  - Each azure service should have an associated API for authorization

- Microsoft Identity framework
  - > TODO : Review this very important chapter

- ASP.NET - Adding Authentication
  - Enabling identity Authentication in Program.cs 
   builder.Services.AddMicrosoftIdentityWebAppAuthentication(builder.Configuration, "AzureAd");
  - This will help to connect our program to Azure AD
  - app.UseAuthentication();
  - app.UseAuthorization();
  - You need to go to your app and Add a Platform configuration
  - To be able to access the Index page we need to be authorized : [Authorize]
  - Enable ID tokens at application object level
  - By default for an application object it will have a delegated type : user_impersonation | Delegated
  - The application has the ability to ready the attributes (Configured at API permissions | Delegated) . Delegated means the app is able to read 
    the user permissions .
  - If using Postman there will be no user and the app permissions will not be of type Delegated
  - Delegated permissions means that the app will read the user permissions to access user AD and will use them
  - The prompt consent screen is here because of : Grant admin consent for Default Directory
  - signin-oidc / signout-oidc are used by Open Id connect for Authentication
  - OAuth is used for authorization


- Adding sign-in sign-outside
  - Using Microsoft.Identity.Web.UI
  - 
    ```
    builder.Services.AddRazorPages().AddMvcOptions(options =>
      { 
          var policy = new AuthorizationPolicyBuilder()
          .RequireAuthenticatedUser()
          .Build();
          options.Filters.Add(new AuthorizeFilter(policy));
      }).AddMicrosoftIdentityUI();
    ```
  - We can scaffold our project and add the required to add identity to our project
  - We can see login.cshtml and logout.cshtml


- Getting Group claims
 - You can create groups in AD and give a group access instead of one by one


- Getting an access token (Authorization)
  - We need to ensure that our code can automatically use access tokens
  - We first need to define a scope
  - We try to acheive : if a user connect to our app can access to our storage account
  - Difference between ID and Access tokens
  - Create a storage account and give access : Reader and Blob storage data reader to a user
  - You then define a scope : 
         ``` 
        string[] scope = new string[] { "https://storage.azure.com/user_impersonation" };
        builder.Services.AddMicrosoftIdentityWebAppAuthentication(builder.Configuration, "AzureAd")
       .EnableTokenAcquisitionToCallDownstreamApi(scope)
       .AddInMemoryTokenCaches(); 
       ```
  - The application will not have access to the storage token . But the user will have the rights 
    and the application will use his rights
  - At application level => Azure storage => user_impersonation
  - Enable => Access tokens (used for implicit flows)
  - You will also need ClientSecret to ensure tokens generation safty . This should come from client 
    secret at client app level .
  - If the application will be deployed just make sure to change : open id connect 
    signin and signout urls .


- Accessing the blob storage from Postman
 - We can generate an access token from graph api using a different scope 


- Creating a WebApi and protecting a WebApi
  - We can also protect our WebApi by associating it to an application object
  - The idea here is to protect the Web API
  - We will also need to register an application just for our API
  - At ProductAPI go to accessTokenAcceptedVersion > null => default version should be 2
  - Add this line : builder.Services.AddMicrosoftIdentityWebAppAuthentication(builder.Configuration, "AzureAd"); 
  - We don't need a client secret in case we want to secure our WEB API unlike if our application will access a resource .
  - So the application object could be used both ways : To secure the app or to let the app access secured resources
  - app.UseAuthentication(); app.UseAuthorization(); are also necessary
  - We will need to add an APP role :
   App roles are custom roles to assign permissions to users or apps. The application defines 
   and publishes the app roles and interprets them as permissions during authorization.
  - Exposes an API : Set > api://f5ac8984-c651-4a1b-abdf-d09e9b8857a8/.default
  - To access our api from POSTMAN , POSTMAN should be associated with a application object that can access our ProductAPI
  - Adding a scope create only delegated permissions
  - to give access to the blobapplication for POSTMAN app we need to go APP permissions > Add permission > MY APIs


- Invoking the Web API from a Console application
  - We can as well call the api from a console application
  - Using ConfidentialClientApplicationBuilder
  - Probably the issue was on : Grant admin permissions => My requets were not authorized


- Invoking the Web API from a Web App
   - In this case we use delegated permissions on bhalf of the user
   - And as the same you need to go to blobapplication and in API permissions add delegated permission Product.Read .
   - After that your application object will have access to the ProductAPI


- Token validation
   - https://docs.microsoft.com/en-us/azure/active-directory/develop/scenario-protected-web-api-app-configuration