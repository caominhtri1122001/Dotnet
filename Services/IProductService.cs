using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductManager.Models;

namespace ProductManager.Services
{
    public interface IProductService
    {
        List<Product> GetProduct();

        List<Category> GetCategories();

        Product? GetProductById(int id);

        void CreateProduct(Product product);

        void UpdateProduct(Product product);

        void DeleteProduct(int id);
    }
}