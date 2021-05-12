using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreAPI.Models;
using BookStoreAPI.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using BookStoreAPI.Models.OrderAggregate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using System.IO;
using Stripe;
using BookStoreAPI.DTOs;
using BookStoreAPI.Helpers;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderReceiptController : ControllerBase
    {
        private readonly Order_ReceiptService service;
        private readonly IConfiguration _config;

        public OrderReceiptController(Order_ReceiptService service, IConfiguration config)
        {
            this.service = service;
            this._config = config;
        }

        [HttpGet]
        public IEnumerable<Order_Receipt> GetOrder_Receipts()
        {
            return service.GetAll();
        }

        [HttpGet("{idUser}")]
        public ActionResult<List<Order_Receipt>> GetOrdersOfUser(int idUser)
        {
            var userId = User.GetUserId();
            var Order_Receipt = service.GetOrdersByUser(userId);

            if (Order_Receipt == null)
            {
                return NotFound();
            }

            return Order_Receipt;
        }

        [HttpPost]
        public async Task<ActionResult<Order_Receipt>> CreateAsync([FromForm] Order_ReceiptCreateDto Order_ReceiptCreateDto)
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

        [HttpPost("payment")]
        public async Task<ActionResult<OrderPaymentIntent>> PaymentAsync(PaymentInput paymentInput)
        {
            var order = service.GetDetail(paymentInput.OrderId);

            if (order == null) return BadRequest();

            return await service.CreatePaymentIntentAsync(order);
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

        [HttpPost("webhook")]
        [AllowAnonymous]
        public async Task<IActionResult> StripeWebhook()
        {
            var WhSecret = _config["StripeSettings:WebhookSecret"];

            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();
            var stripeEvent = EventUtility.ConstructEvent(json, Request.Headers["Stripe-Signature"], WhSecret);

            Stripe.PaymentIntent intent;

            switch (stripeEvent.Type)
            {
                case "payment_intent.succeeded":
                    intent = (Stripe.PaymentIntent)stripeEvent.Data.Object;
                    await service.UpdateOrderPaymentSucceeded(intent.Id);
                    break;
                case "payment_intent.payment_failed":
                    intent = (Stripe.PaymentIntent)stripeEvent.Data.Object;
                    service.UpdateOrderPaymentFailed(intent.Id);
                    break;
            }

            return new EmptyResult();
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

        [HttpGet("delivery")]
        public ActionResult<List<DeliveryMethod>> getAllDeliveryMethod()
        {
            try
            {
                return service.GetDeliveryMethods();
            }
            catch (Exception error)
            {
                return Conflict(error.Message);
            }
        }

    }
}