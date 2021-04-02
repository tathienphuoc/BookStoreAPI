using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using BookStoreAPI.Data;
using BookStoreAPI.Service;
using BookStoreAPI.Repository;

namespace BookStoreApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            // services.AddControllers();
            services.AddControllers()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
            services.AddDbContext<ApplicationDbContext>((options) => options.UseSqlite(
            Configuration.GetConnectionString("DefaultConnection")));

            services

            .AddScoped<AccountRepository>()
            .AddScoped<AccountService>()

            .AddScoped<AuthorRepository>()
            .AddScoped<AuthorService>()

            .AddScoped<BookRepository>()
            .AddScoped<BookService>()

            .AddScoped<CategoryRepository>()
            .AddScoped<CategoryService>()

            .AddScoped<CreditCardRepository>()
            .AddScoped<CreditCardService>()

            .AddScoped<Order_ReceiptRepository>()
            .AddScoped<Order_ReceiptService>()

            .AddScoped<PublisherRepository>()
            .AddScoped<PublisherService>()

            .AddScoped<ReviewRepository>()
            .AddScoped<ReviewService>()

            .AddScoped<ShoppingCartRepository>()
            .AddScoped<ShoppingCartService>()
            
            .AddScoped<BookCategoryRepository>()
            .AddScoped<BookCategoryService>()
            
            .AddScoped<AuthorBookRepository>()
            .AddScoped<AuthorBookService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                    var context = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                    context.Database.Migrate();
            }
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
