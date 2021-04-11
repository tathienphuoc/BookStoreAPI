using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreAPI.Models;
using BookStoreAPI.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AccountService service;

        public AccountController(AccountService service)
        {
            this.service = service;
        }

        public IEnumerable<Account> Get()
        {
            return service.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Account> GetAccount(int id)
        {
            var Account = service.GetDetail(id);

            if (Account == null)
            {
                return NotFound();
            }

            return Account;
        }

        [HttpPost]
        public ActionResult<Account> Create(AccountCreateDto AccountCreateDto)
        {
            try
            {
                return service.Create(AccountCreateDto);
            }
            catch (Exception error)
            {
                return Conflict(error.Message);
            }
        }

        [HttpPut]
        public ActionResult<Account> Update(AccountUpdateDto AccountUpdateDto)
        {
            try
            {
                return service.Update(AccountUpdateDto);
            }
            catch (Exception error)
            {
                return Conflict(error.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Account> DeleteAccount(int id)
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