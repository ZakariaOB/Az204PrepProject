using ProductAPI.Models;

namespace ProductAPI.Services
{
    public class ProductService
    {
        public List<Product> GetProducts()
        {
            List<Product> productList = new List<Product>
            { 
                  new Product { ProductID = 1, ProductName = "Audit Q5", Quantity = 77 },
                  new Product { ProductID = 1, ProductName = "Audit Q7", Quantity = 177 }
            };
            return productList;
        }
    }

 }
