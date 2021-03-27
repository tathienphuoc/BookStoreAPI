using BookStoreAPI.Repository;
using BookStoreAPI.Models;
using System.Collections.Generic;
using BookStoreAPI.Utils;
using System.Linq;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStoreAPI.Service
{
  public class CategoryService
  {
    private CategoryRepository repository;
    public CategoryService(CategoryRepository CategoryRepository)
    {
      this.repository = CategoryRepository;
    }

    public List<Category> GetAll()
    {
      return repository.FindAll();
    }

    public Category GetDetail(int id)
    {
      return repository.FindById(id);
    }

    public Category GetDetail(string name)
    {
      name = FormatString.Trim_MultiSpaces_Title(name,true);
      return repository.FindAll().Where(c => c.Name.Equals(name)).FirstOrDefault();
    }
  }
}