using System;
using BookStoreAPI.Interface;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace BookStoreAPI.Models
{
    public class Book: IEntity
    {//book >= 0 author,  1 publisher, 1 order >=0 review
        public int Id { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Summary { get; set; }
        public string PublicationDate { get; set; }
        public int QuantityInStock { get; set; }
        public decimal Price { get; set; }
        public int Sold { get; set; }
        public int Discount { get; set; }

        public virtual ShoppingCart ShoppingCart { get; set; }
        public virtual List<AuthorBook> AuthorBooks { get; set; }

        public int PublisherId { get; set; }
        public virtual Publisher Publisher { get; set; }

        public virtual List<Order_Receipt> Order_Receipts { get; set; }

        public virtual List<Review> Reviews { get; set; }
        
        public virtual List<BookCategory> BookCategories { get; set; }
    }
    public class BookCreateDto
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public IFormFile Image { get; set; }
        public string Summary { get; set; }
        public string PublicationDate { get; set; }
        public int QuantityInStock { get; set; }
        public decimal Price { get; set; }
        public int Sold { get; set; }
        public int Discount { get; set; }
        public List<int> AuthorId { get; set; }
        public int PublisherId { get; set; }
        public List<int> Order_ReceiptId { get; set; }
        public List<int> CategoryId { get; set; }
    }

    public class BookUpdateDto : BookCreateDto
    {
        public int Id { get; set; }
    }
}