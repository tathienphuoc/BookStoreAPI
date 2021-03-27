using BookStoreAPI.Repository;
using BookStoreAPI.Models;
using System.Collections.Generic;
using BookStoreAPI.Utils;
using System.Linq;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStoreAPI.Service
{
  public class ShoppingCartService
  {
    private ShoppingCartRepository repository;
    public ShoppingCartService(ShoppingCartRepository ShoppingCartRepository)
    {
      this.repository = ShoppingCartRepository;
    }

    public List<ShoppingCart> GetAll()
    {
      return repository.FindAll();
    }

    public ShoppingCart GetDetail(int id)
    {
      return repository.FindById(id);
    }
  }
}