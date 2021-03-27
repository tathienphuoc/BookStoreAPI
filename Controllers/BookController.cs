using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreAPI.Models;
using BookStoreAPI.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookService service;

        public BookController(BookService service)
        {
            this.service = service;
        }

        // [HttpGet]
        public IEnumerable<Book> Get()
        {
            return service.GetAll();
        }

        // [HttpGet("{id}")]
        // public async Task<ActionResult<ProductDto>> GetProduct(int id)
        // {
        //     var product = await _context.Products.FindAsync(id);

        //     if (product == null)
        //     {
        //         return NotFound();
        //     }

        //     return product.ToDto();
        // }

        // [HttpPost]
        // public async Task<ActionResult<ProductDto>> CreateProduct(ProductDto productDto)
        // {
        //     var product = productDto.ToModel();
        //     _context.Products.Add(product);
        //     await _context.SaveChangesAsync();

        //     return CreatedAtAction(nameof(GetProduct), new { Id = product.Id }, product);
        // }

        // [HttpPut]
        // public async Task<IActionResult> UpdateProduct(ProductDto productDto)
        // {
        //     var product = await _context.Products.FindAsync(productDto.Id);

        //     if (product == null) return NotFound();

        //     product.MapTo(productDto);

        //     _context.Products.Update(product);

        //     try
        //     {
        //         await _context.SaveChangesAsync();
        //     }
        //     catch (DbUpdateConcurrencyException) when (!ProductExists(product.Id))
        //     {
        //         return NotFound();
        //     }

        //     return NoContent();
        // }

        // [HttpDelete("{id}")]
        // public async Task<IActionResult> DeleteProduct(int id)
        // {
        //     var product = await _context.Products.FindAsync(id);
        //     if (product == null) return NotFound();

        //     _context.Products.Remove(product);
        //     await _context.SaveChangesAsync();

        //     return NoContent();
        // }

        // private bool ProductExists(int id)
        // {
        //     return _context.Products.Any(p => p.Id == id);
        // }
    }
}