using System;
using System.Collections.Generic;
using System.Linq;
using BookStoreAPI.Models;
using BookStoreAPI.Repository;
using BookStoreAPI.Utils;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStoreAPI.Service
{
    public class BookService
    {
        private BookRepository repository;
        public BookService(BookRepository BookRepository)
        {
            this.repository = BookRepository;
        }

        public List<Book> GetAll()
        {
            return repository.FindAll();
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
    }
}