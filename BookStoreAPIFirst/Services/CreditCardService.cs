using System;
using System.Collections.Generic;
using System.Linq;
using BookStoreAPI.Models;
using BookStoreAPI.Repository;
using BookStoreAPI.Utils;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStoreAPI.Service
{
    public class CreditCardService
    {
        private CreditCardRepository repository;
        public CreditCardService(CreditCardRepository CreditCardRepository)
        {
            this.repository = CreditCardRepository;
        }

        public List<CreditCard> GetAll()
        {
            return repository.FindAll();
        }

        public CreditCard GetDetail(int id)
        {
            return repository.FindById(id);
        }

        public CreditCard GetDetail(string serialNumber)
        {
            serialNumber = FormatString.Trim_MultiSpaces_Title(serialNumber);
            return repository.FindAll().Where(c => c.SerialNumber.Equals(serialNumber)).FirstOrDefault();
        }
        public CreditCard Create(CreditCardCreateDto dto)
        {

            var entity = new CreditCard
            {
                FullName = dto.FullName,

                SerialNumber = dto.SerialNumber,
                AccountId = dto.AccountId

            };


            return repository.Add(entity);
        }

        public CreditCard Update(CreditCardUpdateDto dto)
        {
            // var isExist = GetDetail(dto.Name);
            // if (isExist != null && dto.Id != isExist.Id)
            // {
            //     throw new Exception(dto.Name + " existed");
            // }

            var entity = new CreditCard
            {
                Id = dto.Id,
                FullName = dto.FullName,
               SerialNumber = dto.SerialNumber,
               AccountId = dto.AccountId

              
            };
            return repository.Update(entity);
        }

        public CreditCard Delete(int id)
        {
            var creditCard = GetDetail(id);

            if (creditCard.Account != null)
                throw new Exception("Credit card has been used!");

            return repository.Delete(id);
        }



    }
}