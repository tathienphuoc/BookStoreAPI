using BookStoreAPI.Interface;
namespace BookStoreAPI.Models
{
    public class BookCategory: IEntity
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public virtual Book Book { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
    public class BookCategoryCreateDto
    {
        public int CategoryId { get; set; }
        public int BookId { get; set; }
    }

    public class BookCategoryUpdateDto : BookCategoryCreateDto{
        public int Id { get; set; }
    }
}