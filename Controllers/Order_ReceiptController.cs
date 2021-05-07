using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreAPI.Models;
using BookStoreAPI.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderReceiptController : ControllerBase
    {
        private readonly Order_ReceiptService service;

        public OrderReceiptController(Order_ReceiptService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IEnumerable<Order_Receipt> GetOrder_Receipts()
        {
            return service.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Order_Receipt> GetOrder_Receipt(int id)
        {
            var Order_Receipt = service.GetDetail(id);

            if (Order_Receipt == null)
            {
                return NotFound();
            }

            return Order_Receipt;
        }

        [HttpPost]
        public async Task<ActionResult<Order_Receipt>> CreateAsync([FromForm]Order_ReceiptCreateDto Order_ReceiptCreateDto)
        {
            try
            {
                return await service.Create(Order_ReceiptCreateDto);
            }
            catch (Exception error)
            {
                return Conflict(error.Message);
            }
        }

        [HttpPut]
        public ActionResult<Order_Receipt> Update(Order_ReceiptUpdateDto Order_ReceiptUpdateDto)
        {
            try
            {
                return service.Update(Order_ReceiptUpdateDto);
            }
            catch (Exception error)
            {
                return Conflict(error.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Order_Receipt> DeleteOrder_Receipt(int id)
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