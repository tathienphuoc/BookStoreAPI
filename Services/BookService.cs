using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreAPI.Helpers;
using BookStoreAPI.Models;
using BookStoreAPI.Repository;
using BookStoreAPI.Utils;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.Service
{
    public class BookService
    {
        private BookRepository repository;
        private PublisherService publisherService;
        private CategoryService categoryService;
        private AuthorService authorService;
        private BookCategoryService bookCategoryService;
        private AuthorBookService authorBookService;
        public BookService(BookRepository BookRepository,CategoryService CategoryService,AuthorService AuthorService,BookCategoryService BookCategoryService, AuthorBookService AuthorBookService,PublisherService PublisherService)
        {
            this.repository = BookRepository;
            this.categoryService = CategoryService;
            this.authorService = AuthorService;
            this.bookCategoryService= BookCategoryService;
            this.authorBookService= AuthorBookService;
            this.publisherService=PublisherService;
        }

        public List<Book> GetAll()
        {
            return repository.FindAll();
        }

        public async Task<PagedList<Book>> GetBooksAsync(BookParams bookParams)
        { 
            var query = repository.context.Books.AsQueryable();
            if (bookParams.CategoryId != null)
            {
                query = query.Where(b=>b.BookCategories
                    .Any(bc=>bc.CategoryId == bookParams.CategoryId)).AsQueryable();
            }
            if (bookParams.AuthorId != null)
            {
                query = query.Where(b=>b.AuthorBooks
                    .Any(bc=>bc.BookId == bookParams.AuthorId)).AsQueryable();
            }
            if (!String.IsNullOrEmpty(bookParams.TitleSearch))
            {
                query = query.Where(b=>b.Title.Contains(bookParams.TitleSearch))
                        .AsQueryable();
            }
            return await PagedList<Book>.CreateAsync(query,
                    bookParams.pageNumber,bookParams.pageSize);
            
        } 

        public Book GetDetail(int id)
        {
            return repository.FindById(id);
        }

        public Book GetDetail(string isbn)
        {
            isbn = FormatString.Trim_MultiSpaces_Title(isbn);
            return repository.FindAll().Where(c => c.ISBN.Equals(isbn)).FirstOrDefault();
        }

        public Book Create(BookCreateDto dto){
            if(!categoryService.Exist(dto.Categories)){
                throw new ArgumentException("One/Some of categories not existed");
            }
            if(!authorService.Exist(dto.Authors)){
                throw new ArgumentException("One/Some of authors not existed");
            }
            dto.Title = FormatString.Trim_MultiSpaces_Title(dto.Title,true);
            var isExist = GetDetail(dto.Title);
            if (isExist != null){
                throw new Exception(dto.Title + " existed");
            }
            if (publisherService.GetDetail(dto.PublisherId) == null){
                throw new ArgumentException("Publisher not existed");
            }

            var entity = new Book{
                ISBN = FormatString.Trim_MultiSpaces_Title(dto.ISBN),
                Title = dto.Title,
                Image = FormatString.Trim_MultiSpaces_Title(dto.Image),
                Summary = dto.Summary,
                PublicationDate = dto.PublicationDate,
                QuantityInStock = dto.QuantityInStock,
                Price = dto.Price,
                Sold = dto.Sold,
                Discount = dto.Discount,
                PublisherId = dto.PublisherId
            };

            var book=repository.Add(entity);
            bookCategoryService.Create(book,dto.Categories);
            authorBookService.Create(book,dto.Authors);
            return book;
        }

        public Book Update(BookUpdateDto dto){
            var isExist = GetDetail(dto.ISBN);
            if (isExist != null && dto.Id != isExist.Id)
            {
                throw new Exception(dto.ISBN + " existed");
            }
            if(!categoryService.Exist(dto.Categories)){
                throw new ArgumentException("One/Some of categories not existed");
            }
            if(!authorService.Exist(dto.Authors)){
                throw new ArgumentException("One/Some of authors not existed");
            }
            dto.Title = FormatString.Trim_MultiSpaces_Title(dto.Title,true);
            isExist = GetDetail(dto.Title);
            if (isExist != null){
                throw new Exception(dto.Title + " existed");
            }
            if (publisherService.GetDetail(dto.PublisherId) == null){
                throw new ArgumentException("Publisher not existed");
            }

            var entity = new Book{
                Id = dto.Id,
                ISBN = FormatString.Trim_MultiSpaces_Title(dto.ISBN),
                Title = dto.Title,
                Image = FormatString.Trim_MultiSpaces_Title(dto.Image),
                Summary = dto.Summary,
                PublicationDate = dto.PublicationDate,
                QuantityInStock = dto.QuantityInStock,
                Price = dto.Price,
                Sold = dto.Sold,
                Discount = dto.Discount,
                PublisherId = dto.PublisherId
            };

            var book=repository.Update(entity);
            bookCategoryService.Update(book,dto.Categories);
            authorBookService.Update(book,dto.Authors);
            return book;
        }

        public Book Delete(int id){
            var book = GetDetail(id);
            if (book.AuthorBooks!=null||
                book.Order_Receipts!=null||
                book.Reviews!=null||
                book.BookCategories!=null
            )
                throw new Exception("Book has been used!");
                
            return repository.Delete(id);
        }
    }
}