using BookStoreAPI.Models;
using Microsoft.EntityFrameworkCore;
using BookStoreAPI.Utils;
using System.Text.Json;
using System.Collections.Generic;
using System;

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
                    Name = "Nh?? xu???t b???n Kim ?????ng",
                    Image = "https://upload.wikimedia.org/wikipedia/vi/3/3b/Logo_nxb_Kim_?????ng.png"
                },
                new Publisher
                {
                    Id = 2,
                    Name = "Nh?? xu???t b???n Tr???",
                    Image = "https://upload.wikimedia.org/wikipedia/vi/thumb/a/ac/NXBTrelogo.jpeg/220px-NXBTrelogo.jpeg"
                },
                new Publisher
                {
                    Id = 3,
                    Name = "Nh?? xu???t b???n T???ng h???p th??nh ph??? H??? Ch?? Minh",
                    Image = "https://upload.wikimedia.org/wikipedia/vi/thumb/a/ac/NXBTrelogo.jpeg/220px-NXBTrelogo.jpeg"
                },
                new Publisher
                {
                    Id = 4,
                    Name = "Nh?? xu???t b???n ch??nh tr??? qu???c gia s??? th???t",
                    Image = "https://upload.wikimedia.org/wikipedia/vi/thumb/a/ac/NXBTrelogo.jpeg/220px-NXBTrelogo.jpeg"
                },
                new Publisher
                {
                    Id = 5,
                    Name = "Nh?? xu???t b???n gi??o d???c",
                    Image = "https://upload.wikimedia.org/wikipedia/vi/thumb/a/ac/NXBTrelogo.jpeg/220px-NXBTrelogo.jpeg"
                },
                new Publisher
                {
                    Id = 6,
                    Name = "Nh?? xu???t b???n H???i Nh?? v??n",
                    Image = "https://upload.wikimedia.org/wikipedia/vi/thumb/a/ac/NXBTrelogo.jpeg/220px-NXBTrelogo.jpeg"
                },
                new Publisher
                {
                    Id = 7,
                    Name = "Nh?? xu???t b???n T?? ph??p",
                    Image = "https://upload.wikimedia.org/wikipedia/vi/thumb/a/ac/NXBTrelogo.jpeg/220px-NXBTrelogo.jpeg"
                },
                new Publisher
                {
                    Id = 8,
                    Name = "Nh?? xu???t b???n th??ng tin v?? truy???n th??ng",
                    Image = "https://upload.wikimedia.org/wikipedia/vi/thumb/a/ac/NXBTrelogo.jpeg/220px-NXBTrelogo.jpeg"
                }
            );
            
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    ISBN = "748546",
                    Title = "Nh?? Gi??? Kim",
                    Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQf-fXKxb5Tk4pFFVzZwpX538I_4QCDfxzvGQ&usqp=CAU",
                    Summary = "T???t c??? nh???ng tr???i nghi???m trong chuy???n phi??u du theo ??u???i v???n m???nh c???a m??nh ???? gi??p Santiago th???u hi???u ???????c ?? ngh??a s??u xa nh???t c???a h???nh ph??c, h??a h???p v???i v?? tr??? v?? con ng?????i. Ti???u thuy???t Nh?? gi??? kim c???a Paulo Coelho nh?? m???t c??u chuy???n c??? t??ch gi???n d???, nh??n ??i, gi??u ch???t th??, th???m ?????m nh???ng minh tri???t huy???n b?? c???a ph????ng ????ng. Trong l???n xu???t b???n ?????u ti??n t???i Brazil v??o n??m 1988, s??ch ch??? b??n ???????c 900 b???n. Nh??ng, v???i s??? ph???n ?????c bi???t c???a cu???n s??ch d??nh cho to??n nh??n lo???i, v?????t ra ngo??i bi??n gi???i qu???c gia, Nh?? gi??? kim ???? l??m rung ?????ng h??ng tri???u t??m h???n, tr??? th??nh m???t trong nh???ng cu???n s??ch b??n ch???y nh???t m???i th???i ?????i, v?? c?? th??? l??m thay ?????i cu???c ?????i ng?????i ?????c.",
                    PublicationDate = DateTime.Now,
                    QuantityInStock = 100,
                    Price = 0,
                    Sold = 0,
                    Discount = 0,
                    PublisherId = 1
                },
                new Book
                {
                    Id = 2,
                    ISBN = "215487",
                    Title = "Slam Dunk - Deluxe Edition",
                    Image = "https://cdn0.fahasa.com/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/s/l/slam_dunk_deluxe_edition_tap_3.jpg",
                    Summary = "Tr???n ?????u giao h???u v???i ?????i b??ng c???c m???nh - tr?????ng Ryonan - ???? khai m??n. ?????i ?????u v???i c???u th??? si??u h???ng Sendoh, ?????n c??? Akagi v?? Rukawa c??ng ph???i ch???u thua. T??nh c???nh ???y khi???n cho Sakuragi-???V?? kh?? b?? m???t??? ??ang ???????c ???b???o h?????? tr??n gh??? d??? b??? - c??ng l??c c??ng b???c b???i...!?",
                    PublicationDate = DateTime.Now,
                    QuantityInStock = 100,
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
            modelBuilder.Entity<DeliveryMethod>().HasData(
                new DeliveryMethod(){
                    Id = 1,
                    Price = 3.5M,
                    Type = "Giao h??ng ti???t ki???m"
                },
                new DeliveryMethod() {
                    Id = 2,
                    Price = 3.0M,
                    Type = "Giao h??ng nhanh",
                },
                new DeliveryMethod(){
                    Id = 3,
                    Price = 3.2M,
                    Type = "Viettel Post"
                },
                new DeliveryMethod(){
                    Id = 4,
                    Price = 3.4M,
                    Type = "Vi???t Nam Post"
                }
            );
            return modelBuilder;
        }
    }
}