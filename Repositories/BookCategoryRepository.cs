using BookStoreAPI.Models;
using BookStoreAPI.Data;
using System.Linq;
namespace BookStoreAPI.Repository {
  public class BookCategoryRepository : EfCoreRepository<BookCategory, ApplicationDbContext> {
    public BookCategoryRepository(ApplicationDbContext context) : base(context) {

    }
    public Book DeleteAllByBook(Book book){
      context.BookCategories.RemoveRange(context.BookCategories.Where(b => b.BookId == book.Id));
      return book;
    }
  }
}