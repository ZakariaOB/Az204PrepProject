using ProductAPI.Models;
using System.Data.SqlClient;

namespace ProductAPI.Services
{
    public class ProductService
    {
        public List<Product> GetProducts()
        {
            return new List<Product>
           { 
            new Product
            {
                ProductID = 1,
                ProductName = "Avito car",
                Quantity = 50,
            },
            new Product
            {
                ProductID = 2,
                ProductName = "Bus ocuz",
                Quantity = 55
            }
           };
        }


        public Product GetProduct(string _productId)
        {
            return new Product
            {
                ProductID = 1,
                ProductName = "Avito car",
                Quantity = 50,
            };
        }

        public int AddProduct(Product product)
        {
            return 1;
        }
    }

 }
