using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreAPI.Helpers;
using BookStoreAPI.Models;
using BookStoreAPI.Repository;
using BookStoreAPI.Utils;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.Service
{
    public class BookService
    {
        private BookRepository repository;
        private PublisherService publisherService;
        private readonly IWebHostEnvironment _webHost;
        private CategoryService categoryService;
        private AuthorService authorService;
        private BookCategoryService bookCategoryService;
        private AuthorBookService authorBookService;
        public BookService(BookRepository BookRepository, CategoryService CategoryService,
        AuthorService AuthorService, BookCategoryService BookCategoryService,
        AuthorBookService AuthorBookService, PublisherService PublisherService,
        IWebHostEnvironment webHost)
        {
            this.repository = BookRepository;
            this.categoryService = CategoryService;
            this.authorService = AuthorService;
            this.bookCategoryService = BookCategoryService;
            this.authorBookService = AuthorBookService;
            this.publisherService = PublisherService;
            _webHost = webHost;
        }

        public List<Book> GetAll()
        {
            return repository.FindAll();
        }

        public async Task<PagedList<Book>> GetBooksAsync(BookParams bookParams)
        {
            var query = repository.context.Books
                        .Include(x => x.AuthorBooks).ThenInclude(y => y.Author)
                        .Include(x => x.BookCategories).ThenInclude(y => y.Category)
                        .Include(x => x.Order_Receipts)
                        .Include(x => x.Reviews)
                        .AsQueryable();
            if (bookParams.CategoryId != null)
            {
                query = query.Where(b => b.BookCategories
                    .Any(bc => bc.CategoryId == bookParams.CategoryId)).AsQueryable();
            }
            if (bookParams.AuthorId != null)
            {
                query = query.Where(b => b.AuthorBooks
                    .Any(bc => bc.BookId == bookParams.AuthorId)).AsQueryable();
            }
            if (!String.IsNullOrEmpty(bookParams.TitleSearch))
            {
                query = query.Where(b => b.Title.ToLower().Contains(bookParams.TitleSearch.ToLower()))
                        .AsQueryable();
            }
            return await PagedList<Book>.CreateAsync(query,
                    bookParams.pageNumber, bookParams.pageSize);

        }

        public Book GetDetail(int id)
        {
            return repository.context.Books
                    .Include(x => x.Publisher)
                    .Include(x => x.AuthorBooks).ThenInclude(y => y.Author)
                    .Include(x => x.BookCategories).ThenInclude(y => y.Category)
                    .Include(x => x.Order_Receipts).ThenInclude(y => y.OrderItems)
                    .Include(x => x.Reviews).ThenInclude(y=>y.Account)
                    .FirstOrDefault(x => x.Id == id);
        }

        public Book GetDetail(string isbn)
        {
            isbn = FormatString.Trim_MultiSpaces_Title(isbn);
            return repository.FindAll().Where(c => c.ISBN.Equals(isbn)).FirstOrDefault();
        }

        public Book Create(BookCreateDto dto, ImageUploadResult url)
        {
            if (!categoryService.Exist(dto.CategoryId))
            {
                throw new ArgumentException("One/Some of categories not existed");
            }
            if (!authorService.Exist(dto.AuthorId))
            {

                throw new ArgumentException("One/Some of authors not existed");
            }
            dto.Title = FormatString.Trim_MultiSpaces_Title(dto.Title, true);
            var isExist = GetDetail(dto.Title);
            if (isExist != null)
            {
                throw new Exception(dto.Title + " existed");
            }
            if (publisherService.GetDetail(dto.PublisherId) == null)
            {
                throw new ArgumentException("Publisher not existed");
            }

            var entity = new Book
            {
                ISBN = FormatString.Trim_MultiSpaces_Title(dto.ISBN),
                Title = dto.Title,
                Image = url.SecureUrl.AbsoluteUri,
                // Image = FormatString.Trim_MultiSpaces_Title(dto.Image),
                Summary = dto.Summary,
                PublicationDate = dto.PublicationDate,
                QuantityInStock = dto.QuantityInStock,
                Price = dto.Price,
                Sold = dto.Sold,
                Discount = dto.Discount,
                PublisherId = dto.PublisherId
            };

            var book = repository.Add(entity);
            bookCategoryService.Create(book, dto.CategoryId);
            authorBookService.Create(book, dto.AuthorId);
            return book;
        }

        public Book Update(BookUpdateDto dto, ImageUploadResult url)
        {
            var isExist = GetDetail(dto.Id);
            if (!categoryService.Exist(dto.CategoryId))
            {
                throw new ArgumentException("One/Some of categories not existed");
            }
            if (!authorService.Exist(dto.AuthorId))
            {
                throw new ArgumentException("One/Some of authors not existed");
            }
            dto.Title = FormatString.Trim_MultiSpaces_Title(dto.Title, true);
            if (publisherService.GetDetail(dto.PublisherId) == null)
            {
                throw new ArgumentException("Publisher not existed");
            }
            var entity = new Book();
            if (url != null)
            {
                entity.Id = dto.Id;
                entity.ISBN = FormatString.Trim_MultiSpaces_Title(dto.ISBN);
                entity.Title = dto.Title;
                entity.Summary = dto.Summary;
                entity.Image = url.SecureUrl.AbsoluteUri;
                entity.PublicationDate = dto.PublicationDate;
                entity.QuantityInStock = dto.QuantityInStock;
                entity.Price = dto.Price;
                entity.Sold = dto.Sold;
                entity.Discount = dto.Discount;
                entity.PublisherId = dto.PublisherId;
            }
            else
            {
                entity.Id = dto.Id;
                entity.ISBN = FormatString.Trim_MultiSpaces_Title(dto.ISBN);
                entity.Title = dto.Title;
                entity.Image = isExist.Image;
                entity.Summary = dto.Summary;
                entity.PublicationDate = dto.PublicationDate;
                entity.QuantityInStock = dto.QuantityInStock;
                entity.Price = dto.Price;
                entity.Sold = dto.Sold;
                entity.Discount = dto.Discount;
                entity.PublisherId = dto.PublisherId;
            }

            var book = repository.Update(entity);
            bookCategoryService.Update(book, dto.CategoryId);
            authorBookService.Update(book, dto.AuthorId);
            return book;
        }

        public Book Delete(int id)
        {
            var book = GetDetail(id);
            if (book == null)
                throw new Exception("Book has been used!");
            return repository.Delete(id);
        }
    }
}