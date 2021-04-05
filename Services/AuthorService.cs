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

        public Author Create(AuthorCreateDto dto)
        {
            dto.FullName = FormatString.Trim_MultiSpaces_Title(dto.FullName, true);
            var isExist = GetDetail(dto.FullName);
            if (isExist != null)
            {
                throw new Exception(dto.FullName + " existed");
            }
            var entity = new Author
            {
              FullName = dto.FullName,
              Image = dto.Image,
              Biography = dto.Biography

            };

            return repository.Add(entity);
        }

        public Author Update(AuthorUpdateDto dto)
        {
            var isExist = GetDetail(dto.FullName);
            if (isExist != null && dto.Id != isExist.Id)
            {
                throw new Exception(dto.FullName + " existed");
            }

            var entity = new Author
            {
                Id = dto.Id,
              FullName = FormatString.Trim_MultiSpaces_Title(dto.FullName, true),
               Biography= dto.Biography,
               Image = dto.Image
            };
            return repository.Update(entity);
          
        }

        public Author Delete(int id)
        {
            var author = GetDetail(id);
            return repository.Delete(id);
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