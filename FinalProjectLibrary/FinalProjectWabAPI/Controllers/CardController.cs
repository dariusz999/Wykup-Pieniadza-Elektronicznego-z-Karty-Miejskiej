using FinalProjectLibrary;
using FinalProjectLibrary.Models;
using FinalProjectWabAPI.DTOs;
using FinalProjectWabAPI.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProjectWabAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly CardService _cardService;
        public CardController(CardService cardService)
        {
            _cardService = cardService;
        }

        // GET: api/<CardController>
        [HttpGet]
        public async Task<List<CardDto>> GetAllCards()
        {
            var cards = await _cardService.GetAllCardsAsync();
            return cards.ToList();
        }

        // GET api/<CardController>/5
        [HttpGet("{cardNumber}")]
        public async Task<IActionResult> GetCardById(string cardNumber)
        {
            var card = await _cardService.GetCardByIdAsync(cardNumber);
            if (card == null)
            {
                return NotFound();
            }
            return Ok(card);
        }

        // GET api/<CardController>/5
        [HttpGet("customer/{customerId}")]
        public async Task<IActionResult> GetCardByCustomer(int customerId)
        {
            var card = await _cardService.GetCardByCustomerAsync(customerId);
            if (card == null)
            {
                return NotFound();
            }
            return Ok(card);
        }

        // POST api/<CardController>
        [HttpPost]
        public async Task<IActionResult> CreateCard([FromBody] CardDto card)
        {
            var cardNumber = await _cardService.CreateCardAsync(card);
            return Ok(cardNumber);
        }

        // PUT api/<CardController>/5
        [HttpPut("{cardNumber}")]
        public async Task<IActionResult> UpdateCard(string cardNumber, int customerId, string cardAccountNumber, decimal amount)

        {
            bool updated = await _cardService.UpdateCardAsync(cardNumber, customerId, cardAccountNumber, amount);
            if (!updated)
            {
                return NotFound();
            }
            return Ok();
        }

        //To jest przygotowanie do wykupu:
        // PUT api/<CardController>/5
        [HttpPut("forPayments/{cardNumber}")]
        public async Task<IActionResult> UpdateCardForPayment(string cardNumber, string cardAccountNumber)
        {
            if (_cardService.ValidateCard(cardNumber, cardAccountNumber))
            {
                return Ok("Podano prawidłowe dane");
            }
            else
            {
                return BadRequest("Nieprawidłowy numer karty lub numer konta.");
            }
        }

        // DELETE api/<CardController>/5
        [HttpDelete("{cardNumber}")]
        public async Task<IActionResult> DeleteCard(string cardNumber)
        {
            var result = await _cardService.DeleteCardAsync(cardNumber);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
