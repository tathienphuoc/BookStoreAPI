using BookStoreAPI.Models;
using Microsoft.EntityFrameworkCore;
using BookStoreAPI.Utils;
using System.Text.Json;
using System.Collections.Generic;

namespace BookStoreAPI.Data
{
    public static class ModelBuilderExtensions
    {
        public static ModelBuilder Seed(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Author>().HasData(
                new Author
                {
                    Id = 1,
                    FullName = "Author FullName 1",
                    Biography = "Author Biography 1",
                    Image = "https://www.ormondbeachmartialarts.com/wp-content/uploads/2017/04/default-image.jpg"
                },
                new Author
                {
                    Id = 2,
                    FullName = "Author FullName 2",
                    Biography = "Author Biography 2",
                    Image = "https://www.ormondbeachmartialarts.com/wp-content/uploads/2017/04/default-image.jpg"
                },
                new Author
                {
                    Id = 3,
                    FullName = "Author FullName 3",
                    Biography = "Author Biography 3",
                    Image = "https://www.ormondbeachmartialarts.com/wp-content/uploads/2017/04/default-image.jpg"
                }
            );

            modelBuilder.Entity<Publisher>().HasData(
                new Publisher
                {
                    Id = 1,
                    Name = "Publisher 1",
                    Image = "https://www.ormondbeachmartialarts.com/wp-content/uploads/2017/04/default-image.jpg"
                },
                new Publisher
                {
                    Id = 2,
                    Name = "Publisher 2",
                    Image = "https://www.ormondbeachmartialarts.com/wp-content/uploads/2017/04/default-image.jpg"
                }
            );
            
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    ISBN = "Book ISBN 1",
                    Title = "Book title 1",
                    Image = "https://www.ormondbeachmartialarts.com/wp-content/uploads/2017/04/default-image.jpg",
                    Summary = "Summary title 1",
                    PublicationDate = "11:11 - 11/01/2021",
                    QuantityInStock = 0,
                    Price = 0,
                    Sold = 0,
                    Discount = 0,
                    PublisherId = 1
                },
                new Book
                {
                    Id = 2,
                    ISBN = "Book ISBN 2",
                    Title = "Book title 2",
                    Image = "https://www.ormondbeachmartialarts.com/wp-content/uploads/2017/04/default-image.jpg",
                    Summary = "Summary title 2",
                    PublicationDate = "22:22 - 22/01/2021",
                    QuantityInStock = 0,
                    Price = 0,
                    Sold = 0,
                    Discount = 0,
                    PublisherId = 1
                }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Action and Adventure"
                },
                new Category
                {
                    Id = 2,
                    Name = "Classics"
                },
                new Category
                {
                    Id = 3,
                    Name = "Comic"
                }
                ,
                new Category
                {
                    Id = 4,
                    Name = "Fantasy"
                },
                new Category
                {
                    Id = 5,
                    Name = "Historical Fiction"
                },
                new Category
                {
                    Id = 6,
                    Name = "Horror"
                },
                new Category
                {
                    Id = 7,
                    Name = "Literary Fiction"
                },
                new Category
                {
                    Id = 8,
                    Name = "Romance"
                },
                new Category
                {
                    Id = 9,
                    Name = "Science Fiction"
                },
                new Category
                {
                    Id = 10,
                    Name = "Short Stories"
                },
                new Category
                {
                    Id = 11,
                    Name = "Suspense and Thrillers"
                },
                new Category
                {
                    Id = 12,
                    Name = "Cookbooks"
                }
            );
            modelBuilder.Entity<AuthorBook>().HasData(
                new AuthorBook
                {
                    Id = 1,
                    BookId = 1,
                    AuthorId = 1
                },
                new AuthorBook
                {
                    Id = 2,
                    BookId = 2,
                    AuthorId = 2
                },
                new AuthorBook
                {
                    Id = 3,
                    BookId = 2,
                    AuthorId = 3
                }
            );
            modelBuilder.Entity<BookCategory>().HasData(
                new BookCategory
                {
                    Id = 1,
                    BookId = 1,
                    CategoryId = 1
                },
                new BookCategory
                {
                    Id = 2,
                    BookId = 2,
                    CategoryId = 2
                },
                new BookCategory
                {
                    Id = 3,
                    BookId = 2,
                    CategoryId = 3
                }
            );
            return modelBuilder;
        }
    }
}