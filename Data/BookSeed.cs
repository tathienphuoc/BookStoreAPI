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
            foreach (var book in books)
            {
                book.Id = i++;
                book.ISBN = book.ISBN;
                book.Title = book.Title;
                book.Image = book.Image;
                book.Price = book.Price;
                book.Summary = book.Summary;
                book.PublicationDate = "11:11 - 11/01/2021";
                book.QuantityInStock = 0;
                book.Sold = 0;
                book.Discount = 0;
                book.PublisherId = 1;
                await context.Books.AddAsync(book);
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
            }
            await context.SaveChangesAsync();
        }
    }
}