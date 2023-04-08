- ```Blob storage encryption sample
    var key = await Resolver.ResolveKeyAsyn(keyBundle,KeyIdentifier.CancellationToken.None);
    var x = new BlobEncryptionPolicy(key,resolver);
    Example:
    // We begin with cloudKey1, and a resolver capable of resolving and caching Key Vault secrets.
    // BlobEncryptionPolicy encryptionPolicy = new BlobEncryptionPolicy(cloudKey1, cachingResolver); 
    // client.DefaultRequestOptions.EncryptionPolicy = encryptionPolicy;
    cloudblobClient.DefaultRequestOptions.EncryptionPolicy = x;```

- All certificates and secrets used to secure data must be stored in Azure Key Vault.
You need to retrieve the keys so get permission is required. The wrapkey and unwrapkey will be used for symmetric encryption to encrypt the blobs.
Below link contains an example of same scenario.
https://docs.microsoft.com/en-us/powershell/module/az.storage/set-azstorageaccount?view=azps-8.0.0#example-5-set-encryption-keysource-to-keyvault


- Use blob leases to prevent concurrency problems :
To prevent concurrent processing of a receipt, we need to ensure that only one instance of the processor can access the receipt file at a given time. Blob leases can be used to implement this mechanism. A blob lease allows an application to acquire a lease on a blob for a specified period, during which no other application can modify the blob. When the lease expires or is released, another application can acquire the lease and modify the blob

- **Scenario, the log capacity issue** : Developers report that the number of log message in the trace output for the processor is too high, resulting in lost log messages.
**Sampling** is a feature in Azure Application Insights. It is the recommended way to reduce telemetry traffic and storage, while preserving a statistically correct analysis of application data. The filter selects items that are related, so that you can navigate between items when you are doing diagnostic investigations. When metric counts are presented to you in the portal, they are renormalized to take account of the sampling, to minimize any effect on the statistics.
Sampling reduces traffic and data costs, and helps you avoid throttling.