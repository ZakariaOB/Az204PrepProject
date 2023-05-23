using ContainersApp.Models;

namespace ContainersApp.Services.ProductService
{
    public interface IProductService
    {
        List<ProductModel> GetProducts();
    }
}