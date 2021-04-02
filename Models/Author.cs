using BookStoreAPI.Interface;
using System.Collections.Generic;
namespace BookStoreAPI.Models
{
    public class Author: IEntity
    {//1 author >=0 book
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Biography { get; set; }
        public string Image { get; set; }
        
        public virtual List<AuthorBook> AuthorBooks { get; set; }

    }
    public class AuthorCreateDto
    {
        public string FullName { get; set; }
        public string Biography { get; set; }
        public string Image { get; set; }
        
        public virtual List<Book> Books { get; set; }
    }

    public class AuthorUpdateDto : AuthorCreateDto
    {
        public int Id { get; set; }
    }
}