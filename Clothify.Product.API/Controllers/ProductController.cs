using Clothify.Product.Application.DTOs;
using Clothify.Product.Application.Interfaces;
using Clothify.Product.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clothify.Product.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        //Get: api/product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll()
        {
            var products = await _service.GetAllAsync();
            return Ok(products);
        }

        //Get: api/product/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetById(Guid id)
        {
            var product = await _service.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        //Post: api/product
        [HttpPost]
        public async Task<ActionResult<ProductDto>> Add([FromBody] CreateProductDto dto)
        {
            var created = await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
            //CreatedAtAction is used to return a 201 response after successfully creating a resource.
            //It also includes a location header pointing to the route where the client can fetch the created resource by ID.
        }

        //Put: api/product/{id}
        public async Task<ActionResult> Update(Guid id, [FromBody] CreateProductDto dto)
        {
            var updated = await _service.UpdateAsync(id, dto);
            if (!updated)
            {
                return NotFound();
            }
            return NoContent();

            //This code attempts to update a product. If the product doesn’t exist, it returns 404 Not Found.
            //If it exists and is updated, it returns 204 No Content, indicating a successful update without returning any body.
        }

        // DELETE: api/product/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();

            //This Delete endpoint receives a product ID from the route. It uses the service layer to attempt deletion.
            //If the product is not found, it returns 404 Not Found.
            //If deletion is successful, it returns 204 No Content,
            //which is a standard RESTful response indicating the operation succeeded with no return body.
        }
    }
}
