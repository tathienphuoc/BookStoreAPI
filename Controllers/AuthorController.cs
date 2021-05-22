using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreAPI.Models;
using BookStoreAPI.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Authorization;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly AuthorService service;

        public AuthorController(AuthorService service)
        {
            this.service = service;
        }

        public IEnumerable<Author> Get()
        {
            return service.GetAll();
        }
        [HttpGet("{id}")]
        public ActionResult<Author> GetAuthor(int id)
        {
            var Author = service.GetDetail(id);

            if (Author == null)
            {
                return NotFound();
            }

            return Author;
        }

        [HttpGet("by-book/{bookId}")]
        public IEnumerable<Author> GetAuthorByBook(int bookId)
        {
            var Author = service.GetAuthorByBook(bookId);

            return Author;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult<Author> Create(AuthorCreateDto AuthorCreateDto)
        {
            try
            {
                return service.Create(AuthorCreateDto);
            }
            catch (Exception error)
            {
                return Conflict(error.Message);
            }
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public ActionResult<Author> Update(AuthorUpdateDto AuthorUpdateDto)
        {
            try
            {
                return service.Update(AuthorUpdateDto);
            }
            catch (ArgumentException error)
            {
                return NotFound(error.Message);
            }
            catch (Exception error)
            {
                return Conflict(error.Message);
            }
        }



        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult<Author> DeleteAuthor(int id)
        {
            try
            {
                return service.Delete(id);
            }
            catch (Exception error)
            {
                return Conflict(error.Message);
            }
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