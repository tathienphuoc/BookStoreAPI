using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreAPI.Models;
using BookStoreAPI.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Authorization;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly PublisherService service;

        public PublisherController(PublisherService service)
        {
            this.service = service;
        }

        public IEnumerable<Publisher> Get()
        {
            return service.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Publisher> GetPublisher(int id)
        {
            var Publisher = service.GetDetail(id);

            if (Publisher == null)
            {
                return NotFound();
            }

            return Publisher;
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult<Publisher> Create(PublisherCreateDto PublisherCreateDto)
        {
            try
            {
                return service.Create(PublisherCreateDto);
            }
            catch (Exception error)
            {
                return Conflict(error.Message);
            }
        }


        [HttpPut]
        [Authorize(Roles = "Admin")]
        public ActionResult<Publisher> Update(PublisherUpdateDto PublisherUpdateDto)
        {
            try
            {
                return service.Update(PublisherUpdateDto);
            }
            catch (ArgumentException error)
            {
                return NotFound(error.Message);
            }
            catch (Exception error)
            {
                return Conflict(error.Message);
            }
        }


        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult<Publisher> DeletePublisher(int id)
        {
            try
            {
                return service.Delete(id);
            }
            catch (Exception error)
            {
                return Conflict(error.Message);
            }
        }





    }
}