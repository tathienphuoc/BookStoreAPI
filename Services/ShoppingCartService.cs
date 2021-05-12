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
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            cart.AddItem(book.Id, book, unitPrice: book.Price);
            repository.context.ShoppingCarts.Update(cart);
            var result = await repository.context.SaveChangesAsync() > 0;
            return result;
        }

        // public async Task<bool> UpdateAsync(ShoppingCartUpdateDto dto)
        // {
        //     var book = repository.context.Books.Find(dto.BookId);
        //     var cart = await UpdateCart(dto.AccountId, book);
        //     cart.UpdateItem(book.Id, quantity: book.QuantityInStock);
        //     repository.context.ShoppingCarts.Update(cart);
        //     var result = await repository.context.SaveChangesAsync() > 0;
        //     return result;
        // }

        public ShoppingCart RemoveItem(int cartId,int cartItemId){
            var cart = repository.FindById(cartId);
            cart.RemoveItem(cartItemId);
            repository.context.SaveChanges();
            return cart;
        }

        public ShoppingCart ChangeQuantity(ShoppingCartUpdateDto dto){
            var cart = repository.context.ShoppingCarts
                        .Include(x=>x.Items)
                        .ThenInclude(y=>y.Book)
                        .FirstOrDefault(x=>x.Id == dto.cartId);
            cart.UpdateItem(dto.cartItemId, dto.quantity);
            repository.context.SaveChanges();
            return cart;

        }

        public async Task<ShoppingCart> RemoveItemsAsync(int cartItemId, int userId)
        {
            var cart = repository.context.ShoppingCarts
                        .Include(x=>x.Items).ThenInclude(y=>y.Book)
                        .Where(x => x.AccountId == userId)
                        .FirstOrDefault();
            cart.RemoveItemsWithId(cartItemId);
            await repository.context.SaveChangesAsync();
            return cart;
        }

        public async Task<ShoppingCart> GetExistingOrCreateNewCart(int accountId)
        {
            var user = await _userManager.FindByIdAsync(accountId.ToString());

            var cart = repository.context.ShoppingCarts
                        .Include(x=>x.Items).ThenInclude(y=>y.Book)
                        .Where(x => x.Account == user)
                        .FirstOrDefault();
            if (cart != null)
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


        private async Task<ShoppingCart> UpdateCart(int accountId, Book book)
        {
            var user = await _userManager.FindByIdAsync(accountId.ToString());

            var cart = repository.FindAll()
                    .Where(x => x.Account == user)
                    .FirstOrDefault();
            if (cart != null)
            {
                return cart;
            }
            var newCart = new ShoppingCart
            {
                Account = user
            };
            repository.Update(newCart);
            return newCart;
        }







        // private async Task<ShoppingCart> Update(ShoppingCartUpdateDto dto,  int quantity)
        // {

        // }

        // public async Task<ShoppingCart> Update( int accountId, Book book)
        // {
        //     // var cart = await Repository.GetByIdAsync<ShoppingCart>(id);
        //     var user = await _userManager.FindByIdAsync(accountId.ToString());


        //     var cart = repository.FindAll()
        //         .Where(x => x.Account == user)
        //         .FirstOrDefault();


        //     if (cart == null)
        //         return null;

        //     var newCart = new ShoppingCart
        //     {
        //         Account = user,
        //         Id = cartItem.Id,
        //         Quantity = cartItem.Quantity

        // };
        //     repository.Update(newCart);

        //     _iRepository.Update<BasketItem>(basketItem);
        //     await _iRepository.SaveAsync();
        //     return await GetBasketItemsAsync(basketItem.UserId);
        // }




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
        //       Books = books

        //     };
        //     return repository.Update(entity);
        // }
    }
}