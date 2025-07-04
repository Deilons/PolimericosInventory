using Microsoft.AspNetCore.Mvc;
using PolimericosInventoryAPI.DTOs;
using PolimericosInventoryAPI.Interfaces;

namespace PolimericosInventoryAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAll()
        {
            var products = await _productService.GetAllAsync();
            return Ok(products);
        }
        // GET: api/products/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        // POST: api/products
        [HttpPost]
        public async Task<ActionResult<ProductDTO>> Create([FromBody] ProductCreateDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var newProduct = await _productService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = newProduct.Id }, newProduct);
        }

        // PUT: api/products/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProductCreateDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var updated = await _productService.UpdateAsync(id, dto);
            if (!updated) return NotFound();

            return NoContent();
        }

        // DELETE: api/products/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _productService.DeleteAsync(id);
            if (!deleted) return NotFound();

            return NoContent();
        }
    }
}

