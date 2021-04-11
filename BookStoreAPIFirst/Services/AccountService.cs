using BookStoreAPI.Repository;
using BookStoreAPI.Models;
using System.Collections.Generic;
using BookStoreAPI.Utils;
using System.Linq;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStoreAPI.Service
{
    public class AccountService
    {
        private AccountRepository repository;
        public AccountService(AccountRepository AccountRepository)
        {
            this.repository = AccountRepository;
        }

        public List<Account> GetAll()
        {
            return repository.FindAll();
        }

        public Account GetDetail(int id)
        {
            return repository.FindById(id);
        }

        public Account GetDetail(string email)
        {
            email = FormatString.Trim_MultiSpaces_Title(email);
            return repository.FindAll().Where(c => c.Email.Equals(email)).FirstOrDefault();
        }


        public Account Create(AccountCreateDto dto)
        {

            var entity = new Account
            {
                FullName = dto.FullName,
                Email = dto.Email,
                Password = dto.Password,
                Phone = dto.Phone,
                HomeAddress = dto.HomeAddress,
                Image = dto.Image,
                IsBlocked = true,
                Role = (Account.AccountRole)dto.Role,

                Reviews = dto.Reviews,

                Order_Receipts = dto.Order_Receipts
            };

            return repository.Add(entity);
        }
        public Account Update(AccountUpdateDto dto)
        {
            // var isExist = GetDetail(dto.Name);
            // if (isExist != null && dto.Id != isExist.Id)
            // {
            //     throw new Exception(dto.Name + " existed");
            // }

            var entity = new Account
            {
                Id = dto.Id,
                FullName = dto.FullName,
                Email = dto.Email,
                Password = dto.Password,
                Phone = dto.Phone,
                HomeAddress = dto.HomeAddress,
                Image = dto.Image,
                IsBlocked = dto.IsBlocked,
                Role = (Account.AccountRole)dto.Role,

                Reviews = dto.Reviews,

                Order_Receipts = dto.Order_Receipts
            };
            return repository.Update(entity);
        }


        public Account Delete(int id)
        {
            var account = GetDetail(id);

            // if (account != null)
            //     throw new Exception("Account has been used!");

            return repository.Delete(id);
        }

    }
}