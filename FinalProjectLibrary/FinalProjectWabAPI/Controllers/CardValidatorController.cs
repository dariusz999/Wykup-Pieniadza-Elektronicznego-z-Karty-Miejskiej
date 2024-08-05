using FinalProjectLibrary.Models;
using FinalProjectWabAPI.DTOs;
using FinalProjectWabAPI.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProjectWabAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardValidatorController : ControllerBase
    {
        private readonly CardValidatorService _cardValidatorService;
        public CardValidatorController(CardValidatorService cardValidatorService)
        {
            _cardValidatorService = cardValidatorService;
        }

        // GET: api/<CardValidatorController>
        [HttpGet]
        public async Task<List<CardValidator>> GetAllCards()
        {
            var cards = await _cardValidatorService.GetAllCardsAsync();
            return cards.ToList();
        }

        // GET api/<CardValidatorController>/5
        [HttpGet("{cardNumber}")]
        public async Task<IActionResult> GetCardById(string cardNumber)
        {
            var card = await _cardValidatorService.GetCardByIdAsync(cardNumber);
            if (card == null)
            {
                return NotFound();
            }
            return Ok(card);
        }

        // POST api/<CardValidatorController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CardValidatorController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CardValidatorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
