using BookStoreAPI.Repository;
using BookStoreAPI.Models;
using System.Collections.Generic;
using BookStoreAPI.Utils;
using System.Linq;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStoreAPI.Service
{
  public class AccountService
  {
    private AccountRepository repository;
    public AccountService(AccountRepository AccountRepository)
    {
      this.repository = AccountRepository;
    }

    public List<AppUser> GetAll()
    {
      return repository.FindAll();
    }

    public AppUser GetDetail(int id)
    {
      return repository.FindById(id);
    }

    public AppUser GetDetail(string email)
    {
      email = FormatString.Trim_MultiSpaces_Title(email);
      return repository.FindAll().Where(c => c.Email.Equals(email)).FirstOrDefault();
    }
  }
}