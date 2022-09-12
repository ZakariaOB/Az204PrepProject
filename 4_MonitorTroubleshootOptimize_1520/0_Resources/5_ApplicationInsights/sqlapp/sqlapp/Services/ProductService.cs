using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using sqlapp.Models;
using System.Data.SqlClient;

namespace sqlapp.Services
{

    // This service will interact with our Product data in the SQL database
    public class ProductService
    {
        

        private SqlConnection GetConnection()
        {
            string connectionString = "Server=tcp:appserver500045.database.windows.net,1433;Initial Catalog=appdb;Persist Security Info=False;User ID=sqladmin;Password=Azure@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            return new SqlConnection(connectionString);
        }
        public List<Product> GetProducts()
        {
            List<Product> _product_lst = new ()
            {
                new Product { ProductID = 1, ProductName = "Avion1", Quantity = 5},
                new Product { ProductID = 2, ProductName = "Car Zen", Quantity = 5},
                new Product { ProductID = 3, ProductName = "Moto bikes", Quantity = 5}
            };
            return _product_lst;
        }

    }
}

