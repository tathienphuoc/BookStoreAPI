using BookStoreAPI.Repository;
using BookStoreAPI.Models;
using System.Collections.Generic;
using BookStoreAPI.Utils;
using System.Linq;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace BookStoreAPI.Service
{
    public class ShoppingCartService
    {
        private ShoppingCartRepository repository;

        public ShoppingCartService(ShoppingCartRepository ShoppingCartRepository)
        {
            this.repository = ShoppingCartRepository;

        }

        public List<ShoppingCart> GetAll()
        {
            return repository.FindAll();
        }

        public ShoppingCart GetDetail(int id)
        {
            return repository.FindById(id);
        }

        public ShoppingCart Create(ShoppingCartCreateDto dto)
        {
            // dto.FullName = FormatString.Trim_MultiSpaces_Title(dto.FullName, true);
            // var isExist = GetDetail(dto.FullName);
            // if (isExist != null)
            // {
            //     throw new Exception(dto.FullName + " existed");
            // }

            // var AccountId = User.GetUserId();
            var entity = new ShoppingCart
            {
                AccountId = dto.AccountId,
                LastUpdated = dto.LastUpdated,
                Books = dto.Books

            };

            return repository.Add(entity);
        }

        public ShoppingCart Update(ShoppingCartUpdateDto dto)
        {
            // var isExist = GetDetail(dto.Name);
            // if (isExist != null && dto.Id != isExist.Id)
            // {
            //     throw new Exception(dto.Name + " existed");
            // }

            var entity = new ShoppingCart
            {
                Id = dto.Id,
                AccountId = dto.AccountId,
                LastUpdated = dto.LastUpdated,
                Books = dto.Books

            };
            return repository.Update(entity);
        }

        public ShoppingCart Delete(int id)
        {
            var shoppingCart = GetDetail(id);

            // if (publisher.Books != null)
            //     throw new Exception("Publisher has been used!");

            return repository.Delete(id);
        }











    }
}