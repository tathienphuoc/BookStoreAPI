using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using BookStoreAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.Data
{
    public class AuthorSeed
    {
        public static async Task SeedAuthor(ApplicationDbContext context)
        {
            if (await context.Authors.CountAsync()>3) return;
            var authorData = await System.IO.File.ReadAllTextAsync("Data/AuthorData.json");
            var authors = JsonSerializer.Deserialize<List<Author>>(authorData);
            int i = 4;
            foreach (var author in authors)
            {
                author.Id = i++;
                author.FullName = author.FullName;
                author.Biography = author.Biography;
                await context.Authors.AddAsync(author);
            }
            await context.SaveChangesAsync();
        }
    }
}