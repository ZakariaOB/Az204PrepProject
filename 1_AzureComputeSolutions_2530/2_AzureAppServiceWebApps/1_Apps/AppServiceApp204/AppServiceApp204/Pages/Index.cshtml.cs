using AppServiceApp204.Models;
using AppServiceApp204.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AppServiceApp204.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly GlobalSettings _globalSettings;
        private readonly IConfiguration _conSettings;
        public List<ProductViewModel> Products;
        public bool IsBeta;
        public bool UseDataBase;
        public bool UnifyPriceTo100;
        public string UnifiedPrice { get; set; }

        public IndexModel(IProductService productService, GlobalSettings globalSettings, IConfiguration conSettings)
        {
            _productService = productService;
            _globalSettings = globalSettings;
            _conSettings = conSettings;
        }

        public void OnGet()
        {
            _ = bool.TryParse(_conSettings[nameof(UnifyPriceTo100)], out bool unifyPrice);
            UnifyPriceTo100 = unifyPrice;

            UnifiedPrice = _conSettings[nameof(UnifiedPrice)];

            IsBeta = _productService.IsBeta().Result;
            
            UseDataBase = _globalSettings.UseDataBase;
            
            Products = _productService.GetProducts();
        }
    }
}