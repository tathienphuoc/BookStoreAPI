using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;
using BookStoreAPI.Models;
using BookStoreAPI.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookStoreAPI.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookService service;

        public BookController(BookService service)
        {
            this.service = service;
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> Get([FromQuery] BookParams bookParams)
        {
            var result = await service.GetBooksAsync(bookParams);
            Response.AddPaginationHeader(result.CurrentPage, result.PageSize,
                result.TotalCount, result.TotalPages);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<Book> GetBook(int id)
        {
            var Book = service.GetDetail(id);

            if (Book == null)
            {
                return NotFound();
            }

            return Book;
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult<Book> Create(BookCreateDto BookCreateDto)
        {
            try
            {
                return service.Create(BookCreateDto);
            }
            catch (ArgumentException error){
                return NotFound(error.Message); 
            }
            catch (Exception error)
            {
                return Conflict(error.Message); 
            }
        }

        [HttpPut]
        public ActionResult<Book> Update(BookUpdateDto BookUpdateDto)
        {
            try
            {
                return service.Update(BookUpdateDto);
            }
            catch (ArgumentException error){
                return NotFound(error.Message); 
            }
            catch (Exception error)
            {
                return Conflict(error.Message); 
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Book> DeleteBook(int id){
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