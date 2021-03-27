using BookStoreAPI.Models;
using BookStoreAPI.Data;

namespace BookStoreAPI.Repository {
  public class ShoppingCartRepository : EfCoreRepository<ShoppingCart, ApplicationDbContext> {
    public ShoppingCartRepository(ApplicationDbContext context) : base(context) {

    }
  }
}