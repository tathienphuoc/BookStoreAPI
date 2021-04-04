using System;
using BookStoreAPI.Interface;
using System.Collections;
using System.Collections.Generic;
// using BookStoreAPI.Utils.DateTimeUtils;
namespace BookStoreAPI.Models
{
    public class ShoppingCart: IEntity
    {
        public int Id { get; set; }
        

        public int AccountId { get; set; }
        public virtual AppUser Account { get; set; }
        
        public string LastUpdated { get; set; }
        public virtual List<Book> Books { get; set; }
    }
    public class ShoppingCartCreateDto
    {
        public int AccountId { get; set; }
        
        public string LastUpdated { get; set; }
        public List<Book> Books { get; set; }
    }

    public class ShoppingCartUpdateDto : ShoppingCartCreateDto
    {
        public int Id { get; set; }
    }
}