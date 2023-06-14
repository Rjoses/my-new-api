using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewAPITest.Date;
using NewAPITest.Models;

namespace NewAPITest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCntroller : ControllerBase
    {
        private readonly ApplicationDbContext _contex;

        public ProductCntroller(ApplicationDbContext contex)
        {
            _contex = contex;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _contex.Products.ToList();
            return Ok(products);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetProduct([FromRoute] int id)
        {
            var products = _contex.Products.Find(id);
            return Ok(products);
        }

        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            var newproduct = new Product()
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                Description = product.Description,
                Amount = product.Amount,
            };
            _contex.Products.Add(newproduct);
            _contex.SaveChanges();
            return Ok(newproduct);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult EditProduct(int id, Product product)
        {
            var existingproduct = _contex.Products.Find(id);
            if (existingproduct != null)
            {
                existingproduct.ProductName = product.ProductName;
                existingproduct.Description = product.Description;
                existingproduct.Amount = product.Amount;

                _contex.SaveChanges();

                return Ok(existingproduct);
            }
           return NotFound();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteProduct([FromRoute]int id)
        {
            var product = _contex.Products.Find(id);
            if (product != null)
            {
                _contex.Remove(product);
                _contex.SaveChanges();
                return Ok("Sucessfully deleted product");
            }

            return NotFound();
        }
    }
}
