using BookStoreAPI.Models;
using BookStoreAPI.Data;

namespace BookStoreAPI.Repository {
  public class CategoryRepository : EfCoreRepository<Category, ApplicationDbContext> {
    public CategoryRepository(ApplicationDbContext context) : base(context) {

    }
  }
}