using System;
using System.Collections.Generic;
using System.Text;
using BookStoreAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace BookStoreAPI.Data
{
  public class ApplicationDbContext : IdentityDbContext<Account, AppRole, int>
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<CreditCard> CreditCards { get; set; }
    public DbSet<Order_Receipt> Order_Receipts { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    public DbSet<AuthorBook> AuthorBooks { get; set; }
    public DbSet<BookCategory> BookCategories { get; set; }
    public DbSet<Order_ReceiptBook> Order_ReceiptBooks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
      modelBuilder.Entity<IdentityUserClaim<int>>().ToTable("UserClaims");
      modelBuilder.Entity<IdentityUserRole<int>>().ToTable("UserRoles").HasKey(x=> new {x.UserId, x.RoleId});
      modelBuilder.Entity<IdentityUserLogin<int>>().ToTable("UserLogins").HasKey(x=>x.UserId);
      modelBuilder.Entity<IdentityRoleClaim<int>>().ToTable("RoleClaims");
      modelBuilder.Entity<IdentityUserToken<int>>().ToTable("UserTokens").HasKey(x=>x.UserId);
      modelBuilder.Seed();
      modelBuilder.Entity<AuthorBook>().HasKey(ab => new { ab.AuthorId, ab.BookId });
      modelBuilder.Entity<BookCategory>().HasKey(bc => new { bc.BookId, bc.CategoryId });
      modelBuilder.Entity<Review>().HasKey(rv => new { rv.AccountId, rv.BookId });
      modelBuilder.Entity<Order_ReceiptBook>().HasKey(ob => new { ob.BookId, ob.Order_ReceiptId });
      foreach (var entityType in modelBuilder.Model.GetEntityTypes ()) {
                var tableName = entityType.GetTableName ();
                if (tableName.StartsWith ("AspNet")) {
                    entityType.SetTableName (tableName.Substring (6));
                }
            }
    }
  }
}
