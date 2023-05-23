using ContainersApp.Models;

namespace ContainersApp.Services.ProductService
{
    public class LocalProductService : IProductService
    {
        public List<ProductModel> GetProducts()
        {
            return new List<ProductModel>
            {
                new ProductModel { ProductID = 1, ProductName = "Motix", Quantity = 15 },
                new ProductModel { ProductID = 2, ProductName = "Batx", Quantity = 15 },
                new ProductModel { ProductID = 3, ProductName = "Nolak", Quantity = 15 }
            };
        }
    }
}
