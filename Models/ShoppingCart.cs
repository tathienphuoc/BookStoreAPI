using System;
using BookStoreAPI.Interface;
using System.Collections;
using System.Collections.Generic;

namespace BookStoreAPI.Models
{
    public class ShoppingCart: IEntity
    {
        public int Id { get; set; }
        

        public int AccountId { get; set; }
        public virtual Account Account { get; set; }
        
        // [DataType(DataType.DateTime)]
        public DateTime LastUpdated { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
    public class ShoppingCartCreateDto
    {
        public int AccountId { get; set; }
        public string Cart { get; set; }
    }

    public class ShoppingCartUpdateDto : ShoppingCartCreateDto
    {
        public int Id { get; set; }
    }
}