using System.Collections.Generic;
using BookStoreAPI.Interface;
namespace BookStoreAPI.Models
{
    public class Category: IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public virtual ICollection<BookCategory> BookCategories { get; set; }

    }
    public class CategoryCreateDto
    {
        public string Name { get; set; }
    }

    public class CategoryUpdateDto : CategoryCreateDto
    {
        public int Id { get; set; }
    }
}