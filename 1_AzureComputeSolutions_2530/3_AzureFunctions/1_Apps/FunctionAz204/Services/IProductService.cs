using FunctionAz204.Models;
using System.Collections.Generic;

namespace FunctionAz204.Services
{
    public interface IProductService
    {
        List<ProductModel> GetProducts();
    }
}
