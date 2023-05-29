using FunctionAz204.Services;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

[assembly: FunctionsStartup(typeof(FunctionAz204.Startup))]
namespace FunctionAz204
{
    // The usage of the
    // attribute is to specify the startup class for your Azure Functions host.
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            /*
            var serviceProvider = builder.Services.BuildServiceProvider();
            var configuration = serviceProvider.GetRequiredService<IConfiguration>();

            // Register the ConnectionStringProvider as a singleton service
            builder.Services.AddSingleton<IConfigProvider>(new ConfigProvider(configuration));*/

            // Register your dependencies
            builder.Services.AddSingleton<IProductService, ProductService>();
        }
    }
}
