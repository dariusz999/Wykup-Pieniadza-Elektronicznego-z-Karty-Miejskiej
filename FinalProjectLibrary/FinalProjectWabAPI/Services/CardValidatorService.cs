using FinalProjectLibrary.Models;
using FinalProjectWabAPI.Repositories;

namespace FinalProjectWabAPI.Services
{
    public class CardValidatorService
    {
        private readonly CardValidatorRepository _cardValidatorRepository;

        public CardValidatorService(CardValidatorRepository cardValidatorRepository)
        {
            _cardValidatorRepository = cardValidatorRepository;
        }

        public async Task<IEnumerable<CardValidator>> GetAllCardsAsync()
        {
            return await _cardValidatorRepository.GetAllCardsAsync();
        }
        public async Task<CardValidator?> GetCardByIdAsync(string cardNumber)
        {
            return await _cardValidatorRepository.GetCardByIdAsync(cardNumber);
        }
    }
}
