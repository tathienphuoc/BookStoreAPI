using BookStoreAPI.Interface;
using System.Collections.Generic;
namespace BookStoreAPI.Models
{
    public class Author: IEntity
    {//1 author >=0 book
        public int Id { get; set; }
        public string FullName { get; set; }
        public string? Biography { get; set; }
        public string? Image { get; set; } = "https://www.pngitem.com/pimgs/m/421-4213053_default-avatar-icon-hd-png-download.png";
        
        public virtual ICollection<AuthorBook> AuthorBooks { get; set; }

    }
    public class AuthorCreateDto
    {
        public string FullName { get; set; }
        public string Biography { get; set; }
        public string Image { get; set; }
    }

    public class AuthorUpdateDto : AuthorCreateDto
    {
        public int Id { get; set; }
    }
}