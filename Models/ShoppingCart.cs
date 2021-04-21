using System;
using BookStoreAPI.Interface;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
// using BookStoreAPI.Utils.DateTimeUtils;
namespace BookStoreAPI.Models
{
    public class ShoppingCart: IEntity
    {
        public int Id { get; set; }
        

        public int AccountId { get; set; }
        public virtual Account Account { get; set; }
        
        public string LastUpdated { get; set; }
        public virtual List<CartItem> Items { get; set; } = new List<CartItem>();

        public void AddItem(int bookId, int quantity = 1, string color = "Black", decimal unitPrice = 0)
        {
            var existingItem = Items.FirstOrDefault(i => i.BookId == bookId);

            if (existingItem != null)
            {
                existingItem.Quantity++;
                existingItem.TotalPrice = existingItem.Quantity * existingItem.UnitPrice;
            }
            else
            {
                Items.Add(
                    new CartItem()
                    {
                        BookId = bookId,
                        Quantity = quantity,
                        UnitPrice = unitPrice,
                        TotalPrice = quantity * unitPrice
                    });
            }
        }

    }
    public class ShoppingCartCreateDto
    {
        public int AccountId { get; set; }
        public string LastUpdated { get; set; }
        public int BookId { get; set; }
    }

    public class ShoppingCartUpdateDto : ShoppingCartCreateDto
    {
        public int Id { get; set; }
    }
}