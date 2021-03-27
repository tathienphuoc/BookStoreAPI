using BookStoreAPI.Repository;
using BookStoreAPI.Models;
using System.Collections.Generic;
using BookStoreAPI.Utils;
using System.Linq;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStoreAPI.Service
{
  public class PublisherService
  {
    private PublisherRepository repository;
    public PublisherService(PublisherRepository PublisherRepository)
    {
      this.repository = PublisherRepository;
    }

    public List<Publisher> GetAll()
    {
      return repository.FindAll();
    }

    public Publisher GetDetail(int id)
    {
      return repository.FindById(id);
    }

    public Publisher GetDetail(string name)
    {
      name = FormatString.Trim_MultiSpaces_Title(name);
      return repository.FindAll().Where(c => c.Name.Equals(name)).FirstOrDefault();
    }
  }
}