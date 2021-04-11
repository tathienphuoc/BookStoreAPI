using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreAPI.Models;
using BookStoreAPI.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

        [HttpGet]
        public IEnumerable<Publisher> GetPublishers()
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
        public ActionResult<Publisher> Update(PublisherUpdateDto PublisherUpdateDto)
        {
            try
            {
                return service.Update(PublisherUpdateDto);
            }
            catch (Exception error)
            {
                return Conflict(error.Message);
            }
        }

        [HttpDelete("{id}")]
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