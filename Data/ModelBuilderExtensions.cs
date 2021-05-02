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
                    FullName = "William Shakespeare",
                    Biography = "William Shakespeare was an English poet, playwright, and actor. He was born on 26 April 1564 in Stratford-upon-Avon. His father was a successful local businessman and his mother was the daughter of a landowner. Shakespeare is widely regarded as the greatest writer in the English language and the world's pre-eminent dramatist. He is often called England's national poet and nicknamed the Bard of Avon. He wrote about 38 plays, 154 sonnets, two long narrative poems, and a few other verses, of which the authorship of some is uncertain. His plays have been translated into every major living language and are performed more often than those of any other playwright.",
                    Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/a2/Shakespeare.jpg/220px-Shakespeare.jpg"
                },
                new Author
                {
                    Id = 2,
                    FullName = "Emily Elizabeth Dickinson",
                    Biography = "Emily Dickinson was born on December 10, 1830, in Amherst, Massachusetts. ... While Dickinson was extremely prolific as a poet and regularly enclosed poems in letters to friends, she was not publicly recognized during her lifetime. The first volume of her work was published posthumously in 1890 and the last in 1955.",
                    Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/0e/Emily_Dickinson_daguerreotype_%28Restored%29.jpg/220px-Emily_Dickinson_daguerreotype_%28Restored%29.jpg"
                },
                new Author
                {
                    Id = 3,
                    FullName = "Howard Phillips Lovecraft",
                    Biography = "Howard Phillips Lovecraft was born on December 10, 1830, in Amherst, Massachusetts. ... While Dickinson was extremely prolific as a poet and regularly enclosed poems in letters to friends, she was not publicly recognized during her lifetime. The first volume of her work was published posthumously in 1890 and the last in 1955.",
                    Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/1/10/H._P._Lovecraft%2C_June_1934.jpg/220px-H._P._Lovecraft%2C_June_1934.jpg"
                }
            );

            modelBuilder.Entity<Publisher>().HasData(
                new Publisher
                {
                    Id = 1,
                    Name = "Nhà xuất bản Kim Đồng",
                    Image = "https://upload.wikimedia.org/wikipedia/vi/3/3b/Logo_nxb_Kim_Đồng.png"
                },
                new Publisher
                {
                    Id = 2,
                    Name = "Nhà xuất bản Trẻ",
                    Image = "https://upload.wikimedia.org/wikipedia/vi/thumb/a/ac/NXBTrelogo.jpeg/220px-NXBTrelogo.jpeg"
                },
                new Publisher
                {
                    Id = 3,
                    Name = "Nhà xuất bản Tổng hợp thành phố Hồ Chí Minh",
                    Image = "https://upload.wikimedia.org/wikipedia/vi/thumb/a/ac/NXBTrelogo.jpeg/220px-NXBTrelogo.jpeg"
                },
                new Publisher
                {
                    Id = 4,
                    Name = "Nhà xuất bản chính trị quốc gia sự thật",
                    Image = "https://upload.wikimedia.org/wikipedia/vi/thumb/a/ac/NXBTrelogo.jpeg/220px-NXBTrelogo.jpeg"
                },
                new Publisher
                {
                    Id = 5,
                    Name = "Nhà xuất bản giáo dục",
                    Image = "https://upload.wikimedia.org/wikipedia/vi/thumb/a/ac/NXBTrelogo.jpeg/220px-NXBTrelogo.jpeg"
                },
                new Publisher
                {
                    Id = 6,
                    Name = "Nhà xuất bản Hội Nhà văn",
                    Image = "https://upload.wikimedia.org/wikipedia/vi/thumb/a/ac/NXBTrelogo.jpeg/220px-NXBTrelogo.jpeg"
                },
                new Publisher
                {
                    Id = 7,
                    Name = "Nhà xuất bản Tư pháp",
                    Image = "https://upload.wikimedia.org/wikipedia/vi/thumb/a/ac/NXBTrelogo.jpeg/220px-NXBTrelogo.jpeg"
                },
                new Publisher
                {
                    Id = 8,
                    Name = "Nhà xuất bản thông tin và truyền thông",
                    Image = "https://upload.wikimedia.org/wikipedia/vi/thumb/a/ac/NXBTrelogo.jpeg/220px-NXBTrelogo.jpeg"
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