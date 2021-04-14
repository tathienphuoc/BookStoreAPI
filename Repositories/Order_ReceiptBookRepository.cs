using BookStoreAPI.Models;
using BookStoreAPI.Data;
namespace BookStoreAPI.Repository
{
  

    public class Order_ReceiptBookRepository : EfCoreRepository<Order_ReceiptBook, ApplicationDbContext>
    {
        public Order_ReceiptBookRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}