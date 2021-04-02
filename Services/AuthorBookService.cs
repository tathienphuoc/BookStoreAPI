using System;
using System.Collections.Generic;
using System.Linq;
using BookStoreAPI.Models;
using BookStoreAPI.Repository;
using BookStoreAPI.Utils;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStoreAPI.Service
{
  public class AuthorBookService
  {
    private AuthorBookRepository repository;
    public AuthorBookService(AuthorBookRepository AuthorBookRepository){
      this.repository = AuthorBookRepository;
    }

    public Book DeleteAllByBook(Book book){
      repository.DeleteAllByBook(book);
      return book;
    }

    public void Create(Book book,List<Author> authors){
            foreach(var author in authors){
        var entity = new AuthorBook{
          BookId=book.Id,
          AuthorId = author.Id
        };
        repository.Add(entity);
      }
    }
    public void Update(Book book, List<Author> authors){
      DeleteAllByBook(book);
      Create(book,authors);
    }
  }
}