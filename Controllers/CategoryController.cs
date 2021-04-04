using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreAPI.Models;
using BookStoreAPI.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService service;

        public CategoryController(CategoryService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IEnumerable<Category> GetCategories()
        {
            return service.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Category> GetCategory(int id)
        {
            var Category = service.GetDetail(id);

            if (Category == null)
            {
                return NotFound();
            }

            return Category;
        }
        [HttpPost]
        public ActionResult<Category> Create(CategoryCreateDto CategoryCreateDto)
        {
            try
            {
                return service.Create(CategoryCreateDto);
            }
            catch (Exception error)
            {
                return Conflict(error.Message); 
            }
        }

        [HttpPut]
        public ActionResult<Category> Update(CategoryUpdateDto CategoryUpdateDto){
            try{
                return service.Update(CategoryUpdateDto);
            } catch(Exception error){
                return Conflict(error.Message); 
            }
        }
        [HttpDelete("{id}")]
        public ActionResult<Category> DeleteCategory(int id){
            try{
                return service.Delete(id);
            }
            catch (Exception error)
            {
                return Conflict(error.Message);
            }
        }
    }
}