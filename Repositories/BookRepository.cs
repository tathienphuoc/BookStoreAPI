using BookStoreAPI.Models;
using BookStoreAPI.Data;

namespace BookStoreAPI.Repository {
  public class BookRepository : EfCoreRepository<Book, ApplicationDbContext> {
    public BookRepository(ApplicationDbContext context) : base(context) {

    }
  }
}