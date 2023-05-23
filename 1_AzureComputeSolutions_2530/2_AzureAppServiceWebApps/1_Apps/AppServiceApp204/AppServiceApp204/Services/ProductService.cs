using Microsoft.FeatureManagement;
using AppServiceApp204.Models;
using System.Data.SqlClient;

namespace AppServiceApp204.Services
{
    public class ProductService : IProductService
    {
        private readonly IConfiguration _configuration;

        private readonly IFeatureManager _featureManager;
        
        public ProductService(IConfiguration configuration, IFeatureManager featureManager)
        {
            _configuration = configuration;
            _featureManager = featureManager;
        }

        public async Task<bool> IsBeta() => await _featureManager.IsEnabledAsync("beta");

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("SQLConnection"));
        }

        public List<ProductViewModel> GetProducts()
        {
            List<ProductViewModel> productList = new();
            string _statement = "SELECT ProductID,ProductName,Quantity from Products";
            SqlConnection _connection = GetConnection();

            _connection.Open();

            SqlCommand _sqlcommand = new(_statement, _connection);

            using (SqlDataReader _reader = _sqlcommand.ExecuteReader())
            {
                while (_reader.Read())
                {
                    ProductViewModel _product = new ()
                    {
                        ProductID = _reader.GetInt32(0),
                        ProductName = _reader.GetString(1),
                        Quantity = _reader.GetInt32(2)
                    };
                    productList.Add(_product);
                }
            }
            _connection.Close();
            return productList;
        }

    }
}

