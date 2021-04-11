using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreAPI.Models;
using BookStoreAPI.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using BookStoreAPI.Helpers;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ShoppingCartController : ControllerBase
    {
        private readonly ShoppingCartService service;

        public ShoppingCartController(ShoppingCartService service)
        {
            this.service = service;
        }

        public IEnumerable<ShoppingCart> GetShoppingCarts()
        {
            return service.GetAll();
        }
        [HttpGet("{id}")]
        public ActionResult<ShoppingCart> GetShoppingCart(int id)
        {
            var ShoppingCart = service.GetDetail(id);

            if (ShoppingCart== null)
            {
                return NotFound();
            }

            return ShoppingCart;
        }

        [HttpPost]
        public ActionResult<ShoppingCart> Create(ShoppingCartCreateDto ShoppingCartCreateDto)
        {
           
            try
            {
                return service.Create(ShoppingCartCreateDto);
            }
            catch (Exception error)
            {
                return Conflict(error.Message);
            }
        }

        [HttpPut]
        public ActionResult<ShoppingCart> Update(ShoppingCartUpdateDto ShoppingCartUpdateDto)
        {
            try
            {
                return service.Update(ShoppingCartUpdateDto);
            }
            catch (Exception error)
            {
                return Conflict(error.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<ShoppingCart> DeleteShoppingCart(int id)
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

    }
}   