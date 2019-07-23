using dooyar.dapper.Model;
using dooyar.dapper.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dooyar.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductController()
        {
            _productRepository = new ProductRepository("Server=localhost;User Id=root;Password=123456;Database=shop_demo");
        }

        // GET: api/Product
        [HttpGet]
        public async Task<IEnumerable<Product>> GetList()
        {
            return await _productRepository.GetListAsync();
        }

        // GET: api/Product/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _productRepository.GetAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // POST: api/Product
        [HttpPost]
        public async Task<ActionResult<Product>> PostProcuct(Product product)
        {
            await _productRepository.InsertAsync(product);

            // return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
            return NoContent();
        }

        // PUT: api/Todo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            await _productRepository.UpdateAsync(product);

            return NoContent();
        }
        // DELETE: api/Todo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _productRepository.GetAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            await _productRepository.DeleteAsync(id);

            return NoContent();
        }
    }
}
