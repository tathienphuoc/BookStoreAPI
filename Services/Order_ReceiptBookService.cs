using BookStoreAPI.Repository;
using BookStoreAPI.Models;
using System.Collections.Generic;
using BookStoreAPI.Utils;
using System.Linq;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace BookStoreAPI.Services
{
    public class Order_ReceiptBookService
    {
        private Order_ReceiptBookRepository repository;
        public Order_ReceiptBookService(Order_ReceiptBookRepository Order_ReceiptBookRepository)
        {
            this.repository = Order_ReceiptBookRepository;
        }

        public List<Order_ReceiptBook> GetAll()
        {
            return repository.FindAll();
        }

        public Order_ReceiptBook GetDetail(int id)
        {
            return repository.FindById(id);
        }

        public Order_ReceiptBook Create(Order_ReceiptBookCreateDto dto)
        {

            var entity = new Order_ReceiptBook
            {
               BookId= dto.BookId,
               Order_ReceiptId = dto.Order_ReceiptId

            };


            return repository.Add(entity);
        }

        public Order_ReceiptBook Update(Order_ReceiptBookUpdateDto dto)
        {
            // var isExist = GetDetail(dto.Name);
            // if (isExist != null && dto.Id != isExist.Id)
            // {
            //     throw new Exception(dto.Name + " existed");
            // }

            var entity = new Order_ReceiptBook
            {
               Id = dto.Id,
               BookId = dto.BookId,
               Order_ReceiptId = dto.Order_ReceiptId


            };
            return repository.Update(entity);
        }

        public Order_ReceiptBook Delete(int id)
        {
            var order_ReceiptBook = GetDetail(id);
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