using BookStoreAPI.Repository;
using BookStoreAPI.Models;
using System.Collections.Generic;
using BookStoreAPI.Utils;
using System.Linq;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStoreAPI.Service
{
  public class AuthorService
  {
    private AuthorRepository repository;
    public AuthorService(AuthorRepository repository)
    {
      this.repository = repository;
    }

    public List<Author> GetAll()
    {
      return repository.FindAll();
    }

    public Author GetDetail(int id)
    {
      return repository.FindById(id);
    }

    public Author GetDetail(string fullName)
    {
      fullName = FormatString.Trim_MultiSpaces_Title(fullName,true);
      return repository.FindAll().Where(c => c.FullName.Equals(fullName)).FirstOrDefault();
    }

    public bool Exist(List<Author> authors){
      foreach (var author in authors){
        if(GetDetail(author.Id)==null){
            return false;
        }
      }
      return true;
    }
  }
}