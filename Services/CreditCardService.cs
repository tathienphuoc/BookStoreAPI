using System;
using System.Collections.Generic;
using System.Linq;
using BookStoreAPI.Models;
using BookStoreAPI.Repository;
using BookStoreAPI.Utils;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStoreAPI.Service
{
  public class CreditCardService
  {
    private CreditCardRepository repository;
    public CreditCardService(CreditCardRepository CreditCardRepository)
    {
      this.repository = CreditCardRepository;
    }

    public List<CreditCard> GetAll()
    {
      return repository.FindAll();
    }

    public CreditCard GetDetail(int id)
    {
      return repository.FindById(id);
    }

    public CreditCard GetDetail(string serialNumber)
    {
      serialNumber = FormatString.Trim_MultiSpaces_Title(serialNumber);
      return repository.FindAll().Where(c => c.SerialNumber.Equals(serialNumber)).FirstOrDefault();
    }
  }
}