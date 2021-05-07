using BookStoreAPI.Repository;
using BookStoreAPI.Models;
using System.Collections.Generic;
using BookStoreAPI.Utils;
using System.Linq;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace BookStoreAPI.Service
{
    public class Order_ReceiptService
    {
        private Order_ReceiptRepository repository;
        private readonly ShoppingCartService shoppingCartService;
        private readonly IMapper _mapper;

        public Order_ReceiptService(Order_ReceiptRepository Order_ReceiptRepository, 
                ShoppingCartService shoppingCartService,
                IMapper mapper)
        {
            this.shoppingCartService = shoppingCartService;
            _mapper = mapper;
            this.repository = Order_ReceiptRepository;
        }

        public List<Order_Receipt> GetAll()
        {
            return repository.context.Order_Receipts
                    .Include(x=>x.OrderItems)
                    .ThenInclude(y=>y.Book)
                    .ToList();
        }

        public Order_Receipt GetDetail(int id)
        {
            return repository.FindById(id);
        }

        public async Task<Order_Receipt> Create(Order_ReceiptCreateDto dto)
        {
            var cart = await shoppingCartService.GetCartByUserName(dto.AccountId);
            var items = cart.Items;
            var OrderItems = _mapper.Map<List<OrderItem>>(items);
            decimal total = 0;
            foreach (var item in items)
            {
                total = total + item.TotalPrice;
            }
            var entity = new Order_Receipt
            {
                FullName = dto.FullName,
                Phone = dto.Phone,
                AccountId = dto.AccountId,
                CreatedAt = dto.CreatedAt,
                OrderItems = OrderItems,
                TotalPrice = total,
            };
            cart.ClearItems();
            repository.Add(entity);
            repository.context.SaveChanges();
            return entity;
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
                // Id = dto.Id,
                // CreatedAt = dto.CreatedAt,
                // TotalPrice = dto.TotalPrice,

                // AccountId = dto.AccountId,

                // Books = dto.Books

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