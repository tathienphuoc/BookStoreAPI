using BookStoreAPI.Models;
using BookStoreAPI.Data;

namespace BookStoreAPI.Repository {
  public class AccountRepository : EfCoreRepository<AppUser, ApplicationDbContext> {
    public AccountRepository(ApplicationDbContext context) : base(context) {

    }
  }
}