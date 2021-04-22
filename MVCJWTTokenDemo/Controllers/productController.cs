using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCJWTTokenDemo.Model;
using MVCJWTTokenDemo.Services;

namespace MVCJWTTokenDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class productController : ControllerBase
    {
        private ILogger _logger;
        private IProductsService _service;

        public productController(ILogger<productController> logger, IProductsService service)
        {
            _logger = logger;
            _service = service;

        }
        /// <summary>
        /// Get list of Product     
        /// </summary>
        /// <returns>this list of Product</returns>
        [HttpGet("/api/products")]       
        public ActionResult<List<Product>> GetProducts()
        {
            _logger.LogInformation("Log message in the GetProducts() method");
            return _service.GetProducts();
        }
        ///<summary>Add List of Products</summary>
        /// <remarks>
        ///   Simple request: 
        ///   POST api/products{
        ///      "id": "001",
        ///      "name": "Sony VPCCB Laptop",
        ///      "brand": "Sony"  
        /// }
        /// </remarks>
        /// <param name="Product"></param>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response> 
        [HttpPost("/api/products")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public ActionResult<Product> AddProduct(Product product)
        {
            _logger.LogInformation("Log message in the AddProduct() method"+ product) ;
            _service.AddProduct(product);
            _logger.LogInformation("products", product);
            return product;
        }
        [HttpPut("/api/products/{id}")]
        public ActionResult<Product> UpdateProduct(string id, Product productItem)
        {
            return _service.UpdateProduct(id, productItem);
        }
        [HttpDelete("/api/products/{id}")]
        public ActionResult<string> DeleteProduct(string id)
        {            
            _service.DeleteProduct(id);
            return id;
        }
    }
}