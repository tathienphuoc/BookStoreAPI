using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreAPI.Models;
using BookStoreAPI.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using BookStoreAPI.Services;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Order_ReceiptBookController : ControllerBase
    {
        private readonly Order_ReceiptBookService service;

        public Order_ReceiptBookController(Order_ReceiptBookService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IEnumerable<Order_ReceiptBook> GetOrder_ReceiptBooks()
        {
            return service.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Order_ReceiptBook> GetOrder_ReceiptBook(int id)
        {
            var Order_ReceiptBook = service.GetDetail(id);

            if (Order_ReceiptBook == null)
            {
                return NotFound();
            }

            return Order_ReceiptBook;
        }

        [HttpPost]
        public ActionResult<Order_ReceiptBook> Create(Order_ReceiptBookCreateDto Order_ReceiptBookCreateDto)
        {
            try
            {
                return service.Create(Order_ReceiptBookCreateDto);
            }
            catch (Exception error)
            {
                return Conflict(error.Message);
            }
        }

        [HttpPut]
        public ActionResult<Order_ReceiptBook> Update(Order_ReceiptBookUpdateDto Order_ReceiptBookUpdateDto)
        {
            try
            {
                return service.Update(Order_ReceiptBookUpdateDto);
            }
            catch (Exception error)
            {
                return Conflict(error.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Order_ReceiptBook> DeleteOrder_ReceiptBook(int id)
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