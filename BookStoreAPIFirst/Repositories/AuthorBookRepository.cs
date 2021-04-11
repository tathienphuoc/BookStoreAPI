using BookStoreAPI.Models;
using BookStoreAPI.Data;
using System.Linq;
namespace BookStoreAPI.Repository {
  public class AuthorBookRepository : EfCoreRepository<AuthorBook, ApplicationDbContext> {
    public AuthorBookRepository(ApplicationDbContext context) : base(context) {

    }
    public Book DeleteAllByBook(Book book){
      context.AuthorBooks.RemoveRange(context.AuthorBooks.Where(b => b.BookId == book.Id));
      return book;
    }
  }
}