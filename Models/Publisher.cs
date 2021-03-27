using System.Collections.Generic;
using BookStoreAPI.Interface;
namespace BookStoreAPI.Models
{
    public class Publisher: IEntity
    {//publisher >=0 book
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; } = "https://www.chanchao.com.tw/VietnamWood/images/default.jpg";
        public virtual ICollection<Book> Books { get; set; }
    }
    public class PublisherCreateDto
    {
        public string Name { get; set; }
    }

    public class PublisherUpdateDto : PublisherCreateDto
    {
        public int Id { get; set; }
    }
}