using BookStoreAPI.Models;
using BookStoreAPI.Data;

namespace BookStoreAPI.Repository {
  public class ReviewRepository : EfCoreRepository<Review, ApplicationDbContext> {
    public ReviewRepository(ApplicationDbContext context) : base(context) {

    }
  }
}