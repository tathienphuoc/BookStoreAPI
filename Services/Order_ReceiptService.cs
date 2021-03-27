using BookStoreAPI.Repository;
using BookStoreAPI.Models;
using System.Collections.Generic;
using BookStoreAPI.Utils;
using System.Linq;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStoreAPI.Service
{
  public class Order_ReceiptService
  {
    private Order_ReceiptRepository repository;
    public Order_ReceiptService(Order_ReceiptRepository Order_ReceiptRepository)
    {
      this.repository = Order_ReceiptRepository;
    }

    public List<Order_Receipt> GetAll()
    {
      return repository.FindAll();
    }

    public Order_Receipt GetDetail(int id)
    {
      return repository.FindById(id);
    }
  }
}