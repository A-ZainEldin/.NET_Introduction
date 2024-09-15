using ASP.Net.DBO;
using ASP.Net.Models;
using ASP.Net.repo;
using Microsoft.AspNetCore.Mvc;

namespace ASP.Net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        
        private readonly IProductRepo ProductRepo;
        public ProductController (IProductRepo R)
        {
            ProductRepo = R;
        }
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            return Ok(ProductRepo.GetProducts());
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (ProductRepo.GetProductById(id) != null)
            {
                ProductRepo.DeleteProduct(id);
            }
            return NoContent();
        }
        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            if(ProductRepo.GetProductById(id) is not null) return Ok(ProductRepo.GetProductById(id));
            return NotFound();
        }
        [HttpPost]
        public IActionResult CreateProduct(ProductDBO p)
        {
            Product product = new Product { Name = p.Name, Price = p.Price, stock = p.stock };
            if (ProductRepo.GetProductById(product.Id) == null)
                ProductRepo.AddProduct(product);
            return Ok(product);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, ProductDBO p)
        {
            Product product = new Product { Id = id, Name = p.Name, Price = p.Price, stock = p.stock };
            if (id != product.Id)
            {
                return BadRequest();
            }
            ProductRepo.UpdateProduct(product);
            return Ok();
        }
    }
}
