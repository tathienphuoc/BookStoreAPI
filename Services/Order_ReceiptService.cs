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
using BookStoreAPI.Models.OrderAggregate;
using Stripe;
using Microsoft.Extensions.Configuration;
using OrderItem = BookStoreAPI.Models.OrderItem;

namespace BookStoreAPI.Service
{
    public class Order_ReceiptService
    {
        private Order_ReceiptRepository repository;
        private readonly ShoppingCartService shoppingCartService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        public Order_ReceiptService(Order_ReceiptRepository Order_ReceiptRepository,
                ShoppingCartService shoppingCartService,
                IMapper mapper, IConfiguration config)
        {
            this._config = config;
            this.shoppingCartService = shoppingCartService;
            _mapper = mapper;
            this.repository = Order_ReceiptRepository;
        }

        public List<Order_Receipt> GetAll()
        {
            return repository.context.Order_Receipts
                    .Include(x => x.OrderItems)
                    .ThenInclude(y => y.Book)
                    .Include(x=>x.DeliveryMethod)
                    .Include(x=>x.PaymentIntent)
                    .ToList();
        }

        public List<Order_Receipt> GetOrdersByUser(int userId)
        {
            var orders = repository.context.Order_Receipts
                        .Include(x=>x.Account)
                        .Include(x=>x.OrderItems).ThenInclude(y=>y.Book)
                        .ThenInclude(b => b.BookCategories).ThenInclude(c => c.Category)
                        .Include(x=>x.DeliveryMethod)
                        .OrderByDescending(x=>x.CreatedAt)
                        .Where(x=>x.AccountId == userId).ToList();
            return orders;
        }

        public Order_Receipt GetDetail(int id)
        {
            return repository.FindById(id);
        }

        public async Task<Order_Receipt> Create(Order_ReceiptCreateDto dto)
        {
            var delivery = await repository.context.DeliveryMethods.FirstOrDefaultAsync(x=>x.Id == dto.DeliveryId);
            var cart = await shoppingCartService.GetCartByUserName(dto.AccountId);
            var items = cart.Items;
            foreach (var item in items)
            {
                var book = await repository.context.Books.FirstOrDefaultAsync(x=>x.Id == item.BookId);
                book.QuantityInStock = book.QuantityInStock - item.Quantity;
                await repository.context.SaveChangesAsync();
            }
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
                Email = dto.Email,
                AccountId = dto.AccountId,
                CreatedAt = dto.CreatedAt,
                OrderItems = OrderItems,
                DeliveryMethod = delivery,
                Status = OrderStatus.Paid,
                TotalPrice = total + delivery.Price,
            };
            cart.ClearItems();
            repository.Add(entity);
            repository.context.SaveChanges();
            return entity;
        }

        public async Task<OrderPaymentIntent> CreatePaymentIntentAsync(Order_Receipt order)
        {
            StripeConfiguration.ApiKey = _config["StripeSettings:SecretKey"];

            var service = new PaymentIntentService();

            var options = new PaymentIntentCreateOptions
            {
                Amount = Convert.ToInt64(order.TotalPrice) * 100,
                Currency = "usd",
                PaymentMethodTypes = new List<string> { "card" }
            };

            var confirmOptions = new PaymentIntentConfirmOptions
            {
                PaymentMethod = "pm_card_visa"
            };

            var intent = await service.CreateAsync(options);

            order.PaymentIntent = new OrderPaymentIntent
            {
                PaymentIndentId = intent.Id,
                ClientSecret = intent.ClientSecret
            };
            service.Confirm(
                intent.Id,
                confirmOptions
            );

            repository.Update(order);

            return order.PaymentIntent;
        }

        public async Task<bool> UpdateOrderPaymentSucceeded(string paymentIntentId)
        {
            Console.WriteLine("Succeeded, PaymentIntentId: " + paymentIntentId);

            var order = await repository.context.Order_Receipts
                    .FirstOrDefaultAsync(x => x.PaymentIntent.PaymentIndentId == paymentIntentId);

            if (order == null) return false;

            order.Status = OrderStatus.Paid;

            repository.Update(order);

            return true;
        }

        public void UpdateOrderPaymentFailed(string paymentIntentId)
        {
            Console.WriteLine("Failed, PaymentIntentId: " + paymentIntentId);
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

        public List<DeliveryMethod> GetDeliveryMethods()
        {
            var deliveryMethods = repository.context.DeliveryMethods.ToList();
            return deliveryMethods;
        }




    }
}