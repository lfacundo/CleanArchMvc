using CleanArchMvc.Application.DTO_s;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GelAllAsync()
        {
            var products = await _productService.GetAllAsync();

            if (products is null)
                return NotFound("Products not found");

            return Ok(products);
        }

        [HttpGet("id:int", Name = "GetProducts")]
        public async Task<ActionResult<ProductDTO>> GetByIdAsync(int? id)
        {
            if (id == null)
                return NotFound("Id not found");

            var product = await _productService.GetByIdAsync(id);

            if (product == null)
                return NotFound("Product not found");

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductDTO product)
        {
            if (product == null)
                return BadRequest("Data Invalid");

            await _productService.CreateAsync(product);

            return new CreatedAtRouteResult("GetProducts", new { id = product.Id }, product);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id,[FromBody] ProductDTO product)
        {
            if (id != product.Id)
                return BadRequest("Data Invalid");

            if (product == null)
                return BadRequest("Data Invalid");

            await _productService.UpdateAsync(product);

            return Ok(product);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ProductDTO>> Delete(int id)
        {
            var product = _productService.GetByIdAsync(id);

            if (product == null)
                return NotFound("Product not found");

            await _productService.RemoveAsync(id);

            return Ok(product);
        }
    }
}
