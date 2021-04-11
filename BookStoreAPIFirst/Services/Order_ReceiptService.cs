using BookStoreAPI.Repository;
using BookStoreAPI.Models;
using System.Collections.Generic;
using BookStoreAPI.Utils;
using System.Linq;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStoreAPI.Service
{
    public class Order_ReceiptService
    {
        private Order_ReceiptRepository repository;
        public Order_ReceiptService(Order_ReceiptRepository Order_ReceiptRepository)
        {
            this.repository = Order_ReceiptRepository;
        }

        public List<Order_Receipt> GetAll()
        {
            return repository.FindAll();
        }

        public Order_Receipt GetDetail(int id)
        {
            return repository.FindById(id);
        }

        public Order_Receipt Create(Order_ReceiptCreateDto dto)
        {

            var entity = new Order_Receipt
            {
                CreatedAt = dto.CreatedAt,
                TotalPrice = dto.TotalPrice,

                AccountId = dto.AccountId,

                Books = dto.Books

            };


            return repository.Add(entity);
        }

        public Order_Receipt Update(Order_ReceiptUpdateDto dto)
        {
            // var isExist = GetDetail(dto.Name);
            // if (isExist != null && dto.Id != isExist.Id)
            // {
            //     throw new Exception(dto.Name + " existed");
            // }

            var entity = new Order_Receipt
            {
                Id = dto.Id,
                CreatedAt = dto.CreatedAt,
                TotalPrice = dto.TotalPrice,

                AccountId = dto.AccountId,

                Books = dto.Books

            };
            return repository.Update(entity);
        }

        public Order_Receipt Delete(int id)
        {
            var order_Receipt = GetDetail(id);
            // if (book.AuthorBooks != null ||
            //     book.Order_Receipts != null ||
            //     book.Reviews != null ||
            //     book.BookCategories != null
            // )
            //     throw new Exception("Book has been used!");

            return repository.Delete(id);
        }




    }
}