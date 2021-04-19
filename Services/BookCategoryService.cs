using System;
using System.Collections.Generic;
using System.Linq;
using BookStoreAPI.Models;
using BookStoreAPI.Repository;
using BookStoreAPI.Utils;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using BookStoreAPI.Data;
namespace BookStoreAPI.Service
{
  public class BookCategoryService
  {
    private BookCategoryRepository repository;
    public BookCategoryService(BookCategoryRepository BookCategoryRepository){
      this.repository = BookCategoryRepository;
    }

    public Book DeleteAllByBook(Book book){
      repository.DeleteAllByBook(book);
      return book;
    }
    
    public void Create(Book book, List<int> categories){
      foreach(var category in categories){
        var entity = new BookCategory{
          BookId=book.Id,
          CategoryId = category
        };
        repository.Add(entity);
      }
    }

    public void Update(Book book, List<int> categories){
      DeleteAllByBook(book);
      Create(book,categories);
    }

  }
}