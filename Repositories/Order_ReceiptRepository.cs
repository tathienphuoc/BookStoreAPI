using BookStoreAPI.Models;
using BookStoreAPI.Data;

namespace BookStoreAPI.Repository {
  public class Order_ReceiptRepository : EfCoreRepository<Order_Receipt, ApplicationDbContext> {
    public Order_ReceiptRepository(ApplicationDbContext context) : base(context) {

    }
  }
}