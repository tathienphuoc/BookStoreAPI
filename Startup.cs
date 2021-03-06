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
using BookStoreAPI.Models;
using Microsoft.AspNetCore.Identity;
using BookStoreAPI.Interfaces;
using BookStoreAPI.Services;
using BookStoreAPI.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
            services.Configure<CloudinarySettings>(Configuration.GetSection("CloudinarySettings"));
            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));
            services.AddTransient<IMailService, MailService>();
            services.AddControllers()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
            services.AddScoped<ITokenService, TokenService>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            });
            services.AddDbContext<ApplicationDbContext>((options) => options.UseSqlite(
                Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentityCore<Account>(opt => {
                opt.Password.RequireNonAlphanumeric = false;
            })
                .AddRoles<AppRole>()
                .AddRoleManager<RoleManager<AppRole>>()
                .AddSignInManager<SignInManager<Account>>()
                .AddRoleValidator<RoleValidator<AppRole>>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddCors();

            services.Configure<IdentityOptions>(options =>
            {
                // Thi???t l???p v??? Password
                options.Password.RequireDigit = false; // Kh??ng b???t ph???i c?? s???
                options.Password.RequireLowercase = false; // Kh??ng b???t ph???i c?? ch??? th?????ng
                options.Password.RequireNonAlphanumeric = false; // Kh??ng b???t k?? t??? ?????c bi???t
                options.Password.RequireUppercase = false; // Kh??ng b???t bu???c ch??? in
                options.Password.RequiredLength = 3; // S??? k?? t??? t???i thi???u c???a password
            });

            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(option =>
                {
                    option.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["TokenKey"])),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
            services.AddScoped<IPhotoService, PhotoService>();
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

            .AddScoped<Order_ReceiptBookRepository>()
            .AddScoped<Order_ReceiptBookService>()

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
            // using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            // {
            //     var context = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            //     context.Database.Migrate();
            // }
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors(x => x.AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials()
                .WithOrigins("http://localhost:4200"));
            
            app.UseAuthentication();
            
            app.UseAuthorization();

            app.UseDefaultFiles();

            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapFallbackToController("Index", "Fallback");
            });
        }
    }
}
