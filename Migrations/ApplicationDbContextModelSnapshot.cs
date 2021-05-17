﻿// <auto-generated />
using System;
using BookStoreAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookStoreApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.4");

            modelBuilder.Entity("BookStoreAPI.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FullName")
                        .HasColumnType("TEXT");

                    b.Property<string>("HomeAddress")
                        .HasColumnType("TEXT");

                    b.Property<string>("Image")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsBlocked")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BookStoreAPI.Models.AppRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("BookStoreAPI.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Biography")
                        .HasColumnType("TEXT");

                    b.Property<string>("FullName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Image")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Biography = "William Shakespeare was an English poet, playwright, and actor. He was born on 26 April 1564 in Stratford-upon-Avon. His father was a successful local businessman and his mother was the daughter of a landowner. Shakespeare is widely regarded as the greatest writer in the English language and the world's pre-eminent dramatist. He is often called England's national poet and nicknamed the Bard of Avon. He wrote about 38 plays, 154 sonnets, two long narrative poems, and a few other verses, of which the authorship of some is uncertain. His plays have been translated into every major living language and are performed more often than those of any other playwright.",
                            FullName = "William Shakespeare",
                            Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/a2/Shakespeare.jpg/220px-Shakespeare.jpg"
                        },
                        new
                        {
                            Id = 2,
                            Biography = "Emily Dickinson was born on December 10, 1830, in Amherst, Massachusetts. ... While Dickinson was extremely prolific as a poet and regularly enclosed poems in letters to friends, she was not publicly recognized during her lifetime. The first volume of her work was published posthumously in 1890 and the last in 1955.",
                            FullName = "Emily Elizabeth Dickinson",
                            Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/0e/Emily_Dickinson_daguerreotype_%28Restored%29.jpg/220px-Emily_Dickinson_daguerreotype_%28Restored%29.jpg"
                        },
                        new
                        {
                            Id = 3,
                            Biography = "Howard Phillips Lovecraft was born on December 10, 1830, in Amherst, Massachusetts. ... While Dickinson was extremely prolific as a poet and regularly enclosed poems in letters to friends, she was not publicly recognized during her lifetime. The first volume of her work was published posthumously in 1890 and the last in 1955.",
                            FullName = "Howard Phillips Lovecraft",
                            Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/1/10/H._P._Lovecraft%2C_June_1934.jpg/220px-H._P._Lovecraft%2C_June_1934.jpg"
                        });
                });

            modelBuilder.Entity("BookStoreAPI.Models.AuthorBook", b =>
                {
                    b.Property<int>("AuthorId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("BookId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.HasKey("AuthorId", "BookId");

                    b.HasIndex("BookId");

                    b.ToTable("AuthorBooks");

                    b.HasData(
                        new
                        {
                            AuthorId = 1,
                            BookId = 1,
                            Id = 1
                        },
                        new
                        {
                            AuthorId = 2,
                            BookId = 2,
                            Id = 2
                        },
                        new
                        {
                            AuthorId = 3,
                            BookId = 2,
                            Id = 3
                        });
                });

            modelBuilder.Entity("BookStoreAPI.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<float>("Discount")
                        .HasColumnType("REAL");

                    b.Property<string>("ISBN")
                        .HasColumnType("TEXT");

                    b.Property<string>("Image")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("PublicationDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("PublisherId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("QuantityInStock")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ShoppingCartId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Sold")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Summary")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PublisherId");

                    b.HasIndex("ShoppingCartId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Discount = 0f,
                            ISBN = "Book ISBN 1",
                            Image = "https://www.ormondbeachmartialarts.com/wp-content/uploads/2017/04/default-image.jpg",
                            Price = 0m,
                            PublicationDate = new DateTime(2021, 5, 17, 18, 26, 20, 647, DateTimeKind.Local).AddTicks(2210),
                            PublisherId = 1,
                            QuantityInStock = 0,
                            Sold = 0,
                            Summary = "Summary title 1",
                            Title = "Book title 1"
                        },
                        new
                        {
                            Id = 2,
                            Discount = 0f,
                            ISBN = "Book ISBN 2",
                            Image = "https://www.ormondbeachmartialarts.com/wp-content/uploads/2017/04/default-image.jpg",
                            Price = 0m,
                            PublicationDate = new DateTime(2021, 5, 17, 18, 26, 20, 668, DateTimeKind.Local).AddTicks(3260),
                            PublisherId = 1,
                            QuantityInStock = 0,
                            Sold = 0,
                            Summary = "Summary title 2",
                            Title = "Book title 2"
                        });
                });

            modelBuilder.Entity("BookStoreAPI.Models.BookCategory", b =>
                {
                    b.Property<int>("BookId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.HasKey("BookId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("BookCategories");

                    b.HasData(
                        new
                        {
                            BookId = 1,
                            CategoryId = 1,
                            Id = 1
                        },
                        new
                        {
                            BookId = 2,
                            CategoryId = 2,
                            Id = 2
                        },
                        new
                        {
                            BookId = 2,
                            CategoryId = 3,
                            Id = 3
                        });
                });

            modelBuilder.Entity("BookStoreAPI.Models.CartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BookId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ShoppingCartId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("ShoppingCartId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("BookStoreAPI.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Action and Adventure"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Classics"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Comic"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Fantasy"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Historical Fiction"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Horror"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Literary Fiction"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Romance"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Science Fiction"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Short Stories"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Suspense and Thrillers"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Cookbooks"
                        });
                });

            modelBuilder.Entity("BookStoreAPI.Models.CreditCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccountId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FullName")
                        .HasColumnType("TEXT");

                    b.Property<string>("SerialNumber")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AccountId")
                        .IsUnique();

                    b.ToTable("CreditCards");
                });

            modelBuilder.Entity("BookStoreAPI.Models.DeliveryMethod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("DeliveryMethods");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Price = 3.5m,
                            Type = "Giao hàng tiết kiệm"
                        },
                        new
                        {
                            Id = 2,
                            Price = 3.0m,
                            Type = "Giao hàng nhanh"
                        },
                        new
                        {
                            Id = 3,
                            Price = 3.2m,
                            Type = "Viettel Post"
                        },
                        new
                        {
                            Id = 4,
                            Price = 3.4m,
                            Type = "Việt Nam Post"
                        });
                });

            modelBuilder.Entity("BookStoreAPI.Models.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BookId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Order_ReceiptId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("Order_ReceiptId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("BookStoreAPI.Models.Order_Receipt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccountId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("BookId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int?>("DeliveryMethodId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("FullName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("BookId");

                    b.HasIndex("DeliveryMethodId");

                    b.ToTable("Order_Receipts");
                });

            modelBuilder.Entity("BookStoreAPI.Models.Order_ReceiptBook", b =>
                {
                    b.Property<int>("BookId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Order_ReceiptId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.HasKey("BookId", "Order_ReceiptId");

                    b.HasIndex("Order_ReceiptId");

                    b.ToTable("Order_ReceiptBooks");
                });

            modelBuilder.Entity("BookStoreAPI.Models.Publisher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Image")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Publishers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Image = "https://upload.wikimedia.org/wikipedia/vi/3/3b/Logo_nxb_Kim_Đồng.png",
                            Name = "Nhà xuất bản Kim Đồng"
                        },
                        new
                        {
                            Id = 2,
                            Image = "https://upload.wikimedia.org/wikipedia/vi/thumb/a/ac/NXBTrelogo.jpeg/220px-NXBTrelogo.jpeg",
                            Name = "Nhà xuất bản Trẻ"
                        },
                        new
                        {
                            Id = 3,
                            Image = "https://upload.wikimedia.org/wikipedia/vi/thumb/a/ac/NXBTrelogo.jpeg/220px-NXBTrelogo.jpeg",
                            Name = "Nhà xuất bản Tổng hợp thành phố Hồ Chí Minh"
                        },
                        new
                        {
                            Id = 4,
                            Image = "https://upload.wikimedia.org/wikipedia/vi/thumb/a/ac/NXBTrelogo.jpeg/220px-NXBTrelogo.jpeg",
                            Name = "Nhà xuất bản chính trị quốc gia sự thật"
                        },
                        new
                        {
                            Id = 5,
                            Image = "https://upload.wikimedia.org/wikipedia/vi/thumb/a/ac/NXBTrelogo.jpeg/220px-NXBTrelogo.jpeg",
                            Name = "Nhà xuất bản giáo dục"
                        },
                        new
                        {
                            Id = 6,
                            Image = "https://upload.wikimedia.org/wikipedia/vi/thumb/a/ac/NXBTrelogo.jpeg/220px-NXBTrelogo.jpeg",
                            Name = "Nhà xuất bản Hội Nhà văn"
                        },
                        new
                        {
                            Id = 7,
                            Image = "https://upload.wikimedia.org/wikipedia/vi/thumb/a/ac/NXBTrelogo.jpeg/220px-NXBTrelogo.jpeg",
                            Name = "Nhà xuất bản Tư pháp"
                        },
                        new
                        {
                            Id = 8,
                            Image = "https://upload.wikimedia.org/wikipedia/vi/thumb/a/ac/NXBTrelogo.jpeg/220px-NXBTrelogo.jpeg",
                            Name = "Nhà xuất bản thông tin và truyền thông"
                        });
                });

            modelBuilder.Entity("BookStoreAPI.Models.Review", b =>
                {
                    b.Property<int>("AccountId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("BookId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Liked")
                        .HasColumnType("INTEGER");

                    b.HasKey("AccountId", "BookId");

                    b.HasIndex("BookId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("BookStoreAPI.Models.ShoppingCart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccountId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastUpdated")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AccountId")
                        .IsUnique();

                    b.ToTable("ShoppingCarts");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<int>("RoleId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.ToTable("UserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RoleId")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.ToTable("UserTokens");
                });

            modelBuilder.Entity("BookStoreAPI.Models.AuthorBook", b =>
                {
                    b.HasOne("BookStoreAPI.Models.Author", "Author")
                        .WithMany("AuthorBooks")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookStoreAPI.Models.Book", "Book")
                        .WithMany("AuthorBooks")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("BookStoreAPI.Models.Book", b =>
                {
                    b.HasOne("BookStoreAPI.Models.Publisher", "Publisher")
                        .WithMany("Books")
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookStoreAPI.Models.ShoppingCart", "ShoppingCart")
                        .WithMany()
                        .HasForeignKey("ShoppingCartId");

                    b.Navigation("Publisher");

                    b.Navigation("ShoppingCart");
                });

            modelBuilder.Entity("BookStoreAPI.Models.BookCategory", b =>
                {
                    b.HasOne("BookStoreAPI.Models.Book", "Book")
                        .WithMany("BookCategories")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookStoreAPI.Models.Category", "Category")
                        .WithMany("BookCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("BookStoreAPI.Models.CartItem", b =>
                {
                    b.HasOne("BookStoreAPI.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookStoreAPI.Models.ShoppingCart", null)
                        .WithMany("Items")
                        .HasForeignKey("ShoppingCartId");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("BookStoreAPI.Models.CreditCard", b =>
                {
                    b.HasOne("BookStoreAPI.Models.Account", "Account")
                        .WithOne("CreditCard")
                        .HasForeignKey("BookStoreAPI.Models.CreditCard", "AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("BookStoreAPI.Models.OrderItem", b =>
                {
                    b.HasOne("BookStoreAPI.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookStoreAPI.Models.Order_Receipt", null)
                        .WithMany("OrderItems")
                        .HasForeignKey("Order_ReceiptId");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("BookStoreAPI.Models.Order_Receipt", b =>
                {
                    b.HasOne("BookStoreAPI.Models.Account", "Account")
                        .WithMany("Order_Receipts")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookStoreAPI.Models.Book", null)
                        .WithMany("Order_Receipts")
                        .HasForeignKey("BookId");

                    b.HasOne("BookStoreAPI.Models.DeliveryMethod", "DeliveryMethod")
                        .WithMany()
                        .HasForeignKey("DeliveryMethodId");

                    b.OwnsOne("BookStoreAPI.Models.OrderAggregate.OrderPaymentIntent", "PaymentIntent", b1 =>
                        {
                            b1.Property<int>("Order_ReceiptId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("ClientSecret")
                                .HasColumnType("TEXT");

                            b1.Property<string>("PaymentIndentId")
                                .HasColumnType("TEXT");

                            b1.HasKey("Order_ReceiptId");

                            b1.ToTable("Order_Receipts");

                            b1.WithOwner()
                                .HasForeignKey("Order_ReceiptId");
                        });

                    b.Navigation("Account");

                    b.Navigation("DeliveryMethod");

                    b.Navigation("PaymentIntent");
                });

            modelBuilder.Entity("BookStoreAPI.Models.Order_ReceiptBook", b =>
                {
                    b.HasOne("BookStoreAPI.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookStoreAPI.Models.Order_Receipt", "Order_Receipt")
                        .WithMany()
                        .HasForeignKey("Order_ReceiptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Order_Receipt");
                });

            modelBuilder.Entity("BookStoreAPI.Models.Review", b =>
                {
                    b.HasOne("BookStoreAPI.Models.Account", "Account")
                        .WithMany("Reviews")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookStoreAPI.Models.Book", "Book")
                        .WithMany("Reviews")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("BookStoreAPI.Models.ShoppingCart", b =>
                {
                    b.HasOne("BookStoreAPI.Models.Account", "Account")
                        .WithOne("ShoppingCart")
                        .HasForeignKey("BookStoreAPI.Models.ShoppingCart", "AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("BookStoreAPI.Models.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("BookStoreAPI.Models.Account", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("BookStoreAPI.Models.Account", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("BookStoreAPI.Models.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookStoreAPI.Models.Account", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("BookStoreAPI.Models.Account", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookStoreAPI.Models.Account", b =>
                {
                    b.Navigation("CreditCard");

                    b.Navigation("Order_Receipts");

                    b.Navigation("Reviews");

                    b.Navigation("ShoppingCart");
                });

            modelBuilder.Entity("BookStoreAPI.Models.Author", b =>
                {
                    b.Navigation("AuthorBooks");
                });

            modelBuilder.Entity("BookStoreAPI.Models.Book", b =>
                {
                    b.Navigation("AuthorBooks");

                    b.Navigation("BookCategories");

                    b.Navigation("Order_Receipts");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("BookStoreAPI.Models.Category", b =>
                {
                    b.Navigation("BookCategories");
                });

            modelBuilder.Entity("BookStoreAPI.Models.Order_Receipt", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("BookStoreAPI.Models.Publisher", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("BookStoreAPI.Models.ShoppingCart", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
