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
        public async Task<ActionResult<ShoppingCart>> GetShoppingCart(int id)
        {
            var ShoppingCart = await service.GetCartByUserName(id);

            if (ShoppingCart== null)
            {
                return NotFound();
            }

            return ShoppingCart;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Create(ShoppingCartCreateDto ShoppingCartCreateDto)
        {
           
            try
            {
                return await service.CreateAsync(ShoppingCartCreateDto);
            }
            catch (Exception error)
            {
                return Conflict(error.Message);
            }
        }

        // [HttpPut]
        // public ActionResult<ShoppingCart> Update(ShoppingCartUpdateDto ShoppingCartUpdateDto)
        // {
        //     try
        //     {
        //         return service.Update(ShoppingCartUpdateDto);
        //     }
        //     catch (Exception error)
        //     {
        //         return Conflict(error.Message);
        //     }
        // }

        [HttpPut]
        public ActionResult<ShoppingCart> Update([FromBody]ShoppingCartUpdateDto ShoppingCartUpdateDto)
        {

            try
            {
                return service.ChangeQuantity(ShoppingCartUpdateDto);
            }
            catch (Exception error)
            {
                return Conflict(error.Message);
            }
        }


        [HttpDelete("{cartId}/{cartItemId}")]
        public ActionResult<ShoppingCart> DeleteShoppingCart(int cartId, int cartItemId)
        {
            try
            {
                return service.RemoveItem(cartId, cartItemId);
            }
            catch (Exception error)
            {
                return Conflict(error.Message);
            }
        }

        [HttpDelete("{cartItemId}")]
        public async Task<ActionResult<ShoppingCart>> DeleteItemsAsync(int cartItemId)
        {
            var userId = User.GetUserId();
            try
            {
                return await service.RemoveItemsAsync(cartItemId, userId);
            }
            catch (Exception error)
            {
                return Conflict(error.Message);
            }
        }

    }
}    