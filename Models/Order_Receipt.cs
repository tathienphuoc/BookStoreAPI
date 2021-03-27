using System.Collections.Generic;
using BookStoreAPI.Utils;
using BookStoreAPI.Interface;
using System;
namespace BookStoreAPI.Models
{
    public class Order_Receipt: IEntity
    {//1 order >=0 book
        public int Id { get; set; }
        // [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }
        public float TotalPrice { get; set; }

        public int AccountId { get; set; }
        public virtual Account Account { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
    public class Order_ReceiptCreateDto
    {
        public int AccountId { get; set; }
        public string Cart { get; set; }//isnb : quantity,
        public float TotalPrice { get; set; }
    }

    public class Order_ReceiptUpdateDto : Order_ReceiptCreateDto
    {
        public int Id { get; set; }
    }
}