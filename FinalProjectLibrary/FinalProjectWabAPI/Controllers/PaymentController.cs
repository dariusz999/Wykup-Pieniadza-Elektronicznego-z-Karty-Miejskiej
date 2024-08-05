using FinalProjectLibrary.Models;
using FinalProjectWabAPI.DTOs;
using FinalProjectWabAPI.Repositories;
using FinalProjectWabAPI.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProjectWabAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly PaymentService _paymentService;
        public PaymentController(PaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        // GET: api/<CardController>
        [HttpGet]
        public async Task<IActionResult> GetAllPayments()
        {
            var payments = await _paymentService.GetAllPaymentsAsync();
            return Ok(payments);
        }

        // GET api/<PaymentController>/5
        [HttpGet("{cardNumber}")]
        public async Task<IActionResult> GetPaymentById(string cardNumber)
        {
            var payment = await _paymentService.GetPaymentByIdAsync(cardNumber);
            if (payment == null)
            {
                return NotFound();
            }
            return Ok(payment);
        }

        // POST api/<PaymentController>
        [HttpPost]
        public async Task<IActionResult> CreatePayment(string cardNumber, string name, string surname, string accountNumber)
        {
            var newPayment = new Payment()
            {
                CardNumber = cardNumber,
                Name = name,
                Surname = surname,
                AccountNumber = accountNumber,
            };
            await _paymentService.CreatePaymentAsync(newPayment);
            return Ok();

        }
    }

    //// PUT api/<PaymentController>/5
    //[HttpPut("{id}")]
    //public void Put(int id, [FromBody] string value)
    //{
    //}

    //// DELETE api/<PaymentController>/5
    //[HttpDelete("{id}")]
    //public void Delete(int id)
    //{
    //}

}
