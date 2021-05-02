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
using Microsoft.AspNetCore.Http;
using BookStoreAPI.Services;
using BookStoreAPI.Interfaces;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookService service;
        private readonly IPhotoService _photoService;

        public BookController(BookService service, IPhotoService photoService)
        {
            this.service = service;
            _photoService = photoService;
        }
        // [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> Get([FromQuery] BookParams bookParams)
        {
            var result = await service.GetBooksAsync(bookParams);
            Response.AddPaginationHeader(result.CurrentPage, result.PageSize,
                result.TotalCount, result.TotalPages);

            return Ok(result);
        }

        [HttpGet("all")]
        public ActionResult<IEnumerable<Book>> GetAll()
        {
            var result = service.GetAll();

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
        [HttpPost]
        public async Task<ActionResult<Book>> CreateAsync([FromForm]BookCreateDto BookCreateDto)
        {
            try
            {
                var url = await _photoService.AddPhotoAsync(BookCreateDto.Image);
                return service.Create(BookCreateDto,url);
            }
            catch (ArgumentException error){
                return NotFound(error.Message); 
            }
            catch (Exception error)
            {
                return Conflict(error.Message); 
            }
        }
        
        [Authorize(Roles = "Admin")]
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