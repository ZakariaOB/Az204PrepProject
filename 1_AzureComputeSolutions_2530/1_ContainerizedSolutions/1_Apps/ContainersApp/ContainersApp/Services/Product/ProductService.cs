using ContainersApp.Models;
using ContainersApp.Options;
using Dapper;
using MySql.Data.MySqlClient;

namespace ContainersApp.Services.ProductService
{
    public class ProductService : IProductService
    {
        private GlobalSettings _globalSettings;

        public ProductService(GlobalSettings globalSettings)
        {
            _globalSettings = globalSettings;
        }

        /// <summary>
        /// To use Dapper later
        /// </summary>
        public List<ProductModel> GetProducts()
        {
            string statement = "SELECT ProductID,ProductName,Quantity from Products";
            string connectionString = GetConnection();
            using var connection = new MySqlConnection(connectionString);
            
            return connection.Query<ProductModel>(statement).ToList();
        }
        
        private string GetConnection()
        {
            string connectionString = "Server=tcp:severproduct.database.windows.net,1433;Initial Catalog=dbproducts;Persist Security Info=False;User ID=appuser;Password=ZakariaAz@20152015;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            if (_globalSettings.UseContainerDatabase)
            {
                connectionString = "server=localhost,3306;user=root;password=Azure123;database=appdb";
            }
            return connectionString;
        }
    }
}

