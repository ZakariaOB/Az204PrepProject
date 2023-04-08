- ```
  "appRoles": [
    {
        "allowedMemberTypes": [
            "User"
        ],
        **"displayName"**: "Writer",
        "id": "d1c2ade8-98f8-45fd-aa4a-6d06b947c66f",
        "isEnabled": true,
        "description": "Writers Have the ability to create tasks.",
        "value": "Writer"
    }
]```

____________________

-  oauth2AllowImplicitFlow and oauth2AllowIdTokenImplicitFlow are configuration settings for OAuth 2.0 and OpenID Connect (OIDC) providers.
    **oauth2AllowImplicitFlow** is a boolean flag that indicates whether the OAuth 2.0 Implicit Flow is allowed for the provider. The Implicit Flow is a simplified OAuth 2.0 flow that is used by clients, such as single-page web applications, to obtain access tokens for APIs without a server-side component. When this flag is set to true, clients can use the Implicit Flow to obtain access tokens from the provider.

    **oauth2AllowIdTokenImplicitFlow** is a boolean flag that indicates whether the OpenID Connect Implicit Flow is allowed for the provider. The Implicit Flow in OpenID Connect is similar to the OAuth 2.0 Implicit Flow, but it also includes the issuance of an ID Token. The ID Token is a JWT that contains information about the authenticated user. When this flag is set to true, clients can use the OpenID Connect Implicit Flow to obtain both an access token and an ID Token from the provider.

    It is important to note that both the Implicit Flow and the OpenID Connect Implicit Flow have security implications and are generally considered less secure than other OAuth 2.0 and OIDC flows. Therefore, it is recommended to use alternative flows, such as the Authorization Code Flow or the Hybrid Flow, whenever possible. However, in some cases, such as for legacy applications, the Implicit Flow may still be necessary.

____________________

- **Valid root certificate**
All websites and services must use SSL from a valid root certificate authority.

- **Azure Application Gateway**
  - Any web service accessible over the Internet must be protected from cross site scripting attacks.
  - All Internal services must only be accessible from Internal Virtual Networks (VNets).

____________________

- ```yaml
 volumeMounts:
  - mountPath: /mnt/secrets
    name: secretvolume1
  volumes:
   - name: secretvolume1
  secret:
   mysecret1: TXkgZmlyc3Qgc2VjcmV0IEZPTwo=```


____________________

- **sid**
  - Sid: Session ID, used for per-session user sign-out. Personal and Azure AD accounts.
  Scenario:
  To review content, the user must authenticate to the website portion of the ContentAnalysisService using their Azure AD credentials. The website is built using React and all pages and API endpoints require authentication. In order to review content a user must be part of a ContentReviewer role.
- **email**
  - Scenario: All completed reviews must include the reviewer’s email address for auditing purposes.

____________________

- We are dealing with containers here not VM so "CPU usage" is a valid condition. 
  Had it been VM then it should have been "Percentage CPU usage". 800 is also correct since for containers its measured in millicores.
____________________

- You need to investigate the http server log output to resolve the issue with the ContentUploadService.
  - **az container attach**

- When a new version of the ContentAnalysisService is available the previous seven days of content must be processed with the new version to verify that the new version does not significantly deviate from the old version.
  - event.eventType === RepositoryUpdated
    event.data.target.service === 'contentanalysisservice'
    event.imageCollection.contains('constosoimages');

- Azure Event Hub is used for telemetry and distributed data streaming.
This service provides a single solution that enables rapid data retrieval for real-time processing as well as repeated replay of stored raw data. It can capture the streaming data into a file for processing and analysis.
It has the following characteristics:
 - low latency
 - capable of receiving and processing millions of events per second
 - at least once delivery

- You must create an Azure Function named CheckUserContent to perform the content checks.
  The company's data science group built ContentAnalysisService which accepts user generated content as a string and returns a probable value for inappropriate content. Any values over a specific threshold must be reviewed by an employee of Contoso, Ltd.
  [BlobTrigger(..)]
  [Blob(..)]


  - All Internal services must only be accessible from Internal Virtual Networks (VNets)
There are three Network Location types ג€" Private, Public and Domain