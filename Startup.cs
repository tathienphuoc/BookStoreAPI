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
            // services.AddControllers();
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
                // Thiết lập về Password
                options.Password.RequireDigit = false; // Không bắt phải có số
                options.Password.RequireLowercase = false; // Không bắt phải có chữ thường
                options.Password.RequireNonAlphanumeric = false; // Không bắt ký tự đặc biệt
                options.Password.RequireUppercase = false; // Không bắt buộc chữ in
                options.Password.RequiredLength = 3; // Số ký tự tối thiểu của password
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
