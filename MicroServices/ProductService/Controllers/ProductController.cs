using ProductService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductDbContext _dbContext;
        public ProductController(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            var products = await _dbContext.Products.ToListAsync();
            return Ok(products);
        }

        // GET: api/product/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var product = await _dbContext.Products.FindAsync(id);
            if (product == null)
                return NotFound($"Product with id {id} not found");

            return Ok(product);
        }

        // POST: api/product
        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct([FromBody] Product product)
        {
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
        }

        // PUT: api/product/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] Product product)
        {
            if (id != product.Id)
                return BadRequest("Id mismatch");

            var existingProduct = await _dbContext.Products.FindAsync(id);
            if (existingProduct == null)
                return NotFound($"Product with id {id} not found");

            existingProduct.Name = product.Name;
            existingProduct.Code = product.Code;
            existingProduct.Price = product.Price;

            _dbContext.Products.Update(existingProduct);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/product/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _dbContext.Products.FindAsync(id);
            if (product == null)
                return NotFound($"Product with id {id} not found");

            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
