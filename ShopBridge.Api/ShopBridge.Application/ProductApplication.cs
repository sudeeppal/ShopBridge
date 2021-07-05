using ShopBridge.Models;
using ShopBridge.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopBridge.Application
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductRepository productRepository;

        public ProductApplication(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public Task<Product> AddProductAsync(Product product)
        {
            product.ProductId = 0; // Id is identity column in table, Client cannot pass user define Id value
            return productRepository.AddProduct(product);
        }

        public Task<Product> DeleteProductAsync(int productid)
        {
            return productRepository.DeleteProduct(productid);
        }

        public Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return productRepository.GetProducts();
        }

        public Task<Product> GetProductByIdAsync(int productid)
        {
            if (productid == 0)   // Id cannot be 0  
            {
                return Task.FromResult<Product>(null);
            }

            return productRepository.GetProduct(productid);
        }

        public Task<Product> UpdateProductAsync(Product product)
        {
            return productRepository.UpdateProduct(product);
        }
    }
}
