using BookStoreAPI.Models;
using BookStoreAPI.Data;

namespace BookStoreAPI.Repository {
  public class CreditCardRepository : EfCoreRepository<CreditCard, ApplicationDbContext> {
    public CreditCardRepository(ApplicationDbContext context) : base(context) {

    }
  }
}