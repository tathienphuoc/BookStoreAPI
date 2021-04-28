using BookStoreAPI.Repository;
using BookStoreAPI.Models;
using System.Collections.Generic;
using BookStoreAPI.Utils;
using System.Linq;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using BookStoreAPI.Helpers;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.Service
{
    public class ShoppingCartService
    {
        private ShoppingCartRepository repository;
        private readonly UserManager<Account> _userManager;

        public ShoppingCartService(ShoppingCartRepository ShoppingCartRepository, UserManager<Account> userManager)
        {
            this.repository = ShoppingCartRepository;
            _userManager = userManager;
        }

        public List<ShoppingCart> GetAll()
        {
            return repository.FindAll();
        }

        public ShoppingCart GetDetail(int id)
        {
            return repository.FindById(id);
        }

        public async Task<ShoppingCart> GetCartByUserName(int accountId)
        {
            var cart = await GetExistingOrCreateNewCart(accountId);
            return cart;
        }

        public async Task<bool> CreateAsync(ShoppingCartCreateDto dto)
        {            
            var book = repository.context.Books.Find(dto.BookId);
            var cart = await GetExistingOrCreateNewCart(dto.AccountId);
            cart.AddItem(book.Id, unitPrice:book.Price);
            repository.context.ShoppingCarts.Update(cart);
            var result = await repository.context.SaveChangesAsync() > 0;
            return result;
        }

        private async Task<ShoppingCart> GetExistingOrCreateNewCart(int accountId)
        {
            var user = await _userManager.FindByIdAsync(accountId.ToString());

            var cart = repository.FindAll()
                    .Where(x=>x.Account == user)
                    .FirstOrDefault();
            if (cart!= null)
            {
                return cart;
            }
            var newCart = new ShoppingCart
            {
                Account = user
            };
            repository.Add(newCart);
            return newCart;
        }

        // public ShoppingCart Update(ShoppingCartUpdateDto dto)
        // {
        //     // var isExist = GetDetail(dto.Name);
        //     // if (isExist != null && dto.Id != isExist.Id)
        //     // {
        //     //     throw new Exception(dto.Name + " existed");
        //     // }

        //     var entity = new ShoppingCart
        //     {
        //         Id = dto.Id,
        //         AccountId = dto.AccountId,
        //         LastUpdated = dto.LastUpdated,
        //         Books = dto.Books

        //     };
        //     return repository.Update(entity);
        // }

        public ShoppingCart RemoveItem(int cartId, int cartItemId)
        {
            var cart = (repository.FindById(cartId));
            cart.RemoveItem(cartItemId);
            repository.context.SaveChanges();
            return cart;
        }











    }
}