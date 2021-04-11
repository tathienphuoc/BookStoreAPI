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
    public CategoryService(CategoryRepository CategoryRepository){
      this.repository = CategoryRepository;
    }

    public List<Category> GetAll(){
      return repository.FindAll();
    }

    public Category GetDetail(int id){
      return repository.FindById(id);
    }

    public Category GetDetail(string name){
      name = FormatString.Trim_MultiSpaces_Title(name,true);
      return repository.FindAll().Where(c => c.Name.Equals(name)).FirstOrDefault();
    }

    public Category Delete(int id){
      var category = GetDetail(id);

      if (category.BookCategories!=null)
        throw new Exception("Category has been used!");
        
      return repository.Delete(id);
    }

    public Category Create(CategoryCreateDto dto){
      dto.Name = FormatString.Trim_MultiSpaces_Title(dto.Name,true);
      var isExist = GetDetail(dto.Name);
      if (isExist != null){
        throw new Exception(dto.Name + " existed");
      }
      var entity = new Category{
        Name = dto.Name
      };

      return repository.Add(entity);
    }

    public Category Update(CategoryUpdateDto dto){
      var isExist = GetDetail(dto.Name);
      if (isExist != null && dto.Id != isExist.Id)
      {
        throw new Exception(dto.Name + " existed");
      }

      var entity = new Category
      {
        Id = dto.Id,
        Name = FormatString.Trim_MultiSpaces_Title(dto.Name,true)
      };
      return repository.Update(entity);
    }
    public bool Exist(List<Category> categories){
      foreach (var category in categories){
        if(GetDetail(category.Id)==null){
            return false;
        }
      }
      return true;
    }
  }
}