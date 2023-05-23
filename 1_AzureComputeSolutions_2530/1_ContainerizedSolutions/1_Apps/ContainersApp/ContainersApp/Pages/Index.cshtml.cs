using ContainersApp.Models;
using ContainersApp.Services.ProductService;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContainersApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IProductService _productService;
        public List<ProductModel> Products;

        public IndexModel(IProductService productService)
        {
            _productService = productService;
        }

        public void OnGet()
        {
            FillProducts();
        }

        private void FillProducts()
        {
            Products = _productService.GetProducts();
        }
    }
}