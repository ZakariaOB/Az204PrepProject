using Microsoft.Extensions.Configuration;

namespace FunctionAz204.Services
{
    internal class ConfigProvider : IConfigProvider
    {
        private readonly IConfiguration _configuration;
        public ConfigProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetProductsConnectionString()
        {
            return _configuration.GetConnectionString("Products");
        }
    }
}
