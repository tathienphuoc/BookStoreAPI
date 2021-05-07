using System.Collections.Generic;
using BookStoreAPI.Utils;
using BookStoreAPI.Interface;
using System;
namespace BookStoreAPI.Models
{
    public class Order_Receipt: IEntity
    {//1 order >=0 book
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public decimal TotalPrice { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public int AccountId { get; set; }
        public virtual Account Account { get; set; }

        public virtual List<OrderItem> OrderItems { get; set; }
    }
    public class Order_ReceiptCreateDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public decimal TotalPrice { get; set; }
        public string Phone { get; set; }
        public int AccountId { get; set; }

        public List<int> Items { get; set; }
    }

    public class Order_ReceiptUpdateDto : Order_ReceiptCreateDto
    {
        public int Id { get; set; }
    }
}