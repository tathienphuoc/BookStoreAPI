using BookStoreAPI.Repository;
using BookStoreAPI.Models;
using System.Collections.Generic;
using BookStoreAPI.Utils;
using System.Linq;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStoreAPI.Service
{
  public class ReviewService
  {
    private ReviewRepository repository;
    public ReviewService(ReviewRepository ReviewRepository)
    {
      this.repository = ReviewRepository;
    }

    public List<Review> GetAll()
    {
      return repository.FindAll();
    }

    public Review GetDetail(int id)
    {
      return repository.FindById(id);
    }
  }
}