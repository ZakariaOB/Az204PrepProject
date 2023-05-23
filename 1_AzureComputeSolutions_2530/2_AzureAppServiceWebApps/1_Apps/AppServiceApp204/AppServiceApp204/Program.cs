using AppServiceApp204.Models;
using AppServiceApp204.Services;
using Microsoft.FeatureManagement;

var builder = WebApplication.CreateBuilder(args);
var globalSettings = new GlobalSettings();
builder.Configuration.GetSection(nameof(GlobalSettings)).Bind(globalSettings);

if (globalSettings.UseAppConfiguration)
{
    var connectionString = "Endpoint = https://az204appconfig230523.azconfig.io;Id=agzd;Secret=phLosNGGFsqM4zUm5CYEer+OLMbGPg8nlw+FCHX0xxc=";
    builder.Host.ConfigureAppConfiguration(builder =>
    {
        //Connect to your App Config Store using the connection string
        builder.AddAzureAppConfiguration(options =>
            options.Connect(connectionString).UseFeatureFlags(featureFlagOptions =>
            {
                // Flags are cached for 45 seconds
                featureFlagOptions.CacheExpirationInterval = new TimeSpan(0, 0, 45);
                
                // Flags with label = "Beta" are loaded
                featureFlagOptions.Label = "Beta";
            }));
    });
}
// 

builder.Services.AddSingleton(globalSettings);

if (globalSettings.UseDataBase)
{
    builder.Services.AddTransient<IProductService, ProductService>();
}
else
{
    builder.Services.AddTransient<IProductService, LocalProductService>();
}

builder.Services.AddRazorPages();
builder.Services.AddFeatureManagement();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
