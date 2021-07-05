using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopBridge.Models;
using ShopBridge.Application;

namespace ShopBridge.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductApplication productApplication;

        public ProductsController(IProductApplication productApplication)
        {
            this.productApplication = productApplication;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllProducts()
        {
            return Ok(await productApplication.GetAllProductsAsync());
        }

        [HttpGet("{productid:int}")]
        public async Task<ActionResult<Product>> GetProduct(int productid)
        {
            var result = await productApplication.GetProductByIdAsync(productid);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> AddProduct(Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }
            
            var createdProduct = await productApplication.AddProductAsync(product);
            return CreatedAtAction(nameof(GetProduct), new { productid = createdProduct.ProductId }, createdProduct);
        }

        [HttpDelete("{productid:int}")]
        public async Task<ActionResult<Product>> DeleteProduct(int productid)
        {
            var result = await productApplication.GetProductByIdAsync(productid);

            if (result == null)
            {
                return NotFound();
            }

            var deletedResult = await productApplication.DeleteProductAsync(productid);
            return Ok(deletedResult);
        }
              
        [HttpPut("{productid:int}")]
        public async Task<ActionResult<Product>> UpdateProduct(int productid, Product product)
        {
            if (productid != product.ProductId)
            {
                return BadRequest();
            }

            var result = await productApplication.GetProductByIdAsync(productid);

            if (result == null)
            {
                return NotFound($"Produc with Id {productid} not found");
            }

            var updatedResult = await productApplication.UpdateProductAsync(product);

            return Ok(updatedResult);
        }
    }
}
