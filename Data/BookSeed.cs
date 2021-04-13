using System.Collections.Generic;
using System.IO;
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
            if (await context.Books.CountAsync()>2) return;
            var bookData = await System.IO.File.ReadAllTextAsync("Data/BookData.json");
            var books = JsonSerializer.Deserialize<List<Book>>(bookData);
            int i = 3;
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

                context.Books.Add(book);
            }
            await context.SaveChangesAsync();
        }
    }
}