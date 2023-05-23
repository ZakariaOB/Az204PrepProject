using AppServiceApp204.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.FeatureManagement;
using System.Collections.Generic;

namespace AppServiceApp204.Services
{
    public class LocalProductService : IProductService
    {

        private readonly IFeatureManager _featureManager;

        public async Task<bool> IsBeta()
        {
            return await _featureManager.IsEnabledAsync("beta");
        }

        public LocalProductService(
            IFeatureManager featureManager)
        {
            _featureManager = featureManager;
        }

        public List<ProductViewModel> GetProducts()
        {
            return new List<ProductViewModel>
            {
                new ProductViewModel { ProductID = 1, ProductName = "Local_Motix", Quantity = 15 },
                new ProductViewModel { ProductID = 2, ProductName = "Local_Batx", Quantity = 15 },
                new ProductViewModel { ProductID = 3, ProductName = "Local_Nolak", Quantity = 15 },
                new ProductViewModel { ProductID = 4, ProductName = "Local_Motix", Quantity = 15 },
                new ProductViewModel { ProductID = 5, ProductName = "Local_Batx", Quantity = 15 },
                new ProductViewModel { ProductID = 6, ProductName = "Local_Nolak", Quantity = 15 }
            };
        }
    }
}
