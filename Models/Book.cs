using System;
using BookStoreAPI.Interface;
using System.Collections.Generic;
namespace BookStoreAPI.Models
{
    public class Book: IEntity
    {//book >= 0 author,  1 publisher, 1 order >=0 review
        public int Id { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Image { get; set; } = "http://serc.cl/wp-content/uploads/2018/02/book-cover-placeholder.jpg";
        public string? Summary { get; set; }
        // [DataType(DataType.DateTime)]
        public DateTime PublicationDate { get; set; }
        public int QuantityInStock { get; set; } = 50;
        public float Price { get; set; }
        public static int Sold { get; set; } = 0;
        public int Discount { get; set; } = 0;


        public virtual ICollection<AuthorBook> AuthorBooks { get; set; }

        public int? PublisherId { get; set; }
        public virtual Publisher Publisher { get; set; }

        public int? Order_ReceiptId { get; set; }
        public virtual Order_Receipt Order_Receipt { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
        
        public virtual ICollection<BookCategory> BookCategories { get; set; }
    }
    public class BookCreateDto
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public int QuantityInStock { get; set; }
        public float Price { get; set; }
        public string Authors { get; set; }
        public int PublisherId { get; set; }
        public int Sold { get; set; }
        public string Categories { get; set; }
        public int Discount { get; set; }
    }

    public class BookUpdateDto : BookCreateDto
    {
        public int Id { get; set; }
    }
}