using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using BookStoreAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.Data
{
    public class BookSeed
    {
        public static async Task SeedBooks(ApplicationDbContext context)
        {
            Random rnd = new Random();
            if (await context.Books.CountAsync()>2) return;
            var bookData = await System.IO.File.ReadAllTextAsync("Data/BookData.json");
            var books = JsonSerializer.Deserialize<List<Book>>(bookData);
            int i = 3;
            int k = 1;
            int h = 1;
            foreach (var book in books)
            {
                book.Id = i++;
                book.ISBN = book.ISBN;
                book.Title = book.Title;
                book.Image = book.Image;
                book.Price = book.Price;
                book.Summary = book.Summary;
                book.PublicationDate = DateTime.Now;
                book.QuantityInStock = 100;
                book.Sold = 0;
                book.Discount = 0;
                int temp = rnd.Next(1,9);
                book.PublisherId = temp;
                var publisher = context.Publishers.FirstOrDefault(x=>x.Id == temp);
                book.Publisher = publisher;
                await context.Books.AddAsync(book);
                await context.SaveChangesAsync();
                for (int j = 0; j < rnd.Next(1,3); j++)
                {
                    var bookCategory = new BookCategory(){
                        Id = k++,
                        BookId = book.Id,
                        CategoryId = rnd.Next(1, 13)
                    };
                    var check = context.BookCategories
                        .Any(x=>x.BookId == bookCategory.BookId && 
                                    x.CategoryId == bookCategory.CategoryId);
                    if (!check)
                    {
                        await context.BookCategories.AddAsync(bookCategory);
                        await context.SaveChangesAsync();
                    }
                }
                for (int j = 0; j < rnd.Next(1,5); j++)
                {
                    var authorBook = new AuthorBook(){
                        Id = h++,
                        BookId = book.Id,
                        AuthorId = rnd.Next(1, 24)
                    };
                    var check = context.AuthorBooks
                        .Any(x=>x.BookId == authorBook.BookId && 
                                    x.AuthorId == authorBook.AuthorId);
                    if (!check)
                    {
                        await context.AuthorBooks.AddAsync(authorBook);
                        await context.SaveChangesAsync();
                    }
                }
            }
            await context.SaveChangesAsync();
        }
    }
}