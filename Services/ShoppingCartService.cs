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

        public async Task<bool> CreateAsync(ShoppingCartCreateDto dto)
        {            
            var book = repository.context.Books.Find(dto.BookId);
            var cart = await GetExistingOrCreateNewCart(dto.AccountId, book);
            cart.AddItem(book.Id, unitPrice:book.Price);
            repository.context.ShoppingCarts.Update(cart);
            var result = await repository.context.SaveChangesAsync() > 0;
            return result;
        }

        private async Task<ShoppingCart> GetExistingOrCreateNewCart(int accountId, Book book)
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

        public ShoppingCart Delete(int id)
        {
            var shoppingCart = GetDetail(id);

            // if (publisher.Books != null)
            //     throw new Exception("Publisher has been used!");

            return repository.Delete(id);
        }











    }
}