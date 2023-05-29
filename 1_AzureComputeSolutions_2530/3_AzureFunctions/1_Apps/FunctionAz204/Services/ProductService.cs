using Dapper;
using FunctionAz204.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FunctionAz204.Services
{
    internal class ProductService : IProductService
    {

        public List<ProductModel> GetProducts()
        {
            string connectionString = Environment.GetEnvironmentVariable("ProductConnectionString");
            string statement = "SELECT ProductID,ProductName,Quantity from Products";
            using var connection = new SqlConnection(connectionString);

            return connection.Query<ProductModel>(statement).ToList();
        }
    }
}
