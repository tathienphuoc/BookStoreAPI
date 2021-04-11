using System.Collections.Generic;
using BookStoreAPI.Interface;
namespace BookStoreAPI.Models
{
    public class Publisher: IEntity
    {//publisher >=0 book
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public virtual List<Book> Books { get; set; }
    }
    public class PublisherCreateDto
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public List<Book> Books { get; set; }
    }

    public class PublisherUpdateDto : PublisherCreateDto
    {
        public int Id { get; set; }
    }
}