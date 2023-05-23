using AppServiceApp204.Models;

namespace AppServiceApp204.Services
{
    public interface IProductService
    {
        List<ProductViewModel> GetProducts();
        Task<bool> IsBeta();
    }
}