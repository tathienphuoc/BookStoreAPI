using BookStoreAPI.Models;
using BookStoreAPI.Data;

namespace BookStoreAPI.Repository {
  public class PublisherRepository : EfCoreRepository<Publisher, ApplicationDbContext> {
    public PublisherRepository(ApplicationDbContext context) : base(context) {

    }
  }
}