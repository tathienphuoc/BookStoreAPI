using BookStoreAPI.Interface;
namespace BookStoreAPI.Models
{
    public class AuthorBook: IEntity
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }

        public int BookId { get; set; }
        public virtual Book Book { get; set; }
    }
}