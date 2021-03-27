using BookStoreAPI.Models;
using BookStoreAPI.Data;

namespace BookStoreAPI.Repository {
  public class AuthorRepository : EfCoreRepository<Author, ApplicationDbContext> {
    public AuthorRepository(ApplicationDbContext context) : base(context) {

    }
  }
}