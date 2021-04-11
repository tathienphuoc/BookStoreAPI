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
    public class CreditCardController : ControllerBase
    {
        private readonly CreditCardService service;

        public CreditCardController(CreditCardService service)
        {
            this.service = service;
        }

        public IEnumerable<CreditCard> GetCreditCards()
        {
            return service.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<CreditCard> GetCreditCard(int id)
        {
            var CreditCard = service.GetDetail(id);

            if (CreditCard == null)
            {
                return NotFound();
            }

            return CreditCard;
        }


        [HttpPost]
        public ActionResult<CreditCard> Create(CreditCardCreateDto CreditCardCreateDto)
        {
            try
            {
                return service.Create(CreditCardCreateDto);
            }
            catch (Exception error)
            {
                return Conflict(error.Message);
            }
        }

        [HttpPut]
        public ActionResult<CreditCard> Update(CreditCardUpdateDto CreditCardUpdateDto)
        {
            try
            {
                return service.Update(CreditCardUpdateDto);
            }
            catch (Exception error)
            {
                return Conflict(error.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<CreditCard> DeleteCreditCard(int id)
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