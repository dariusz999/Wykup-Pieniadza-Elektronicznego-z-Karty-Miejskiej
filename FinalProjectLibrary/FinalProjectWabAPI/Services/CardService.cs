using FinalProjectLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProjectLibrary.Models;
using FinalProjectWabAPI.Repositories;
using FinalProjectWabAPI.DTOs;

namespace FinalProjectWabAPI.Services
{
    public class CardService
    {
        private readonly CardRepository _cardRepository;

        public CardService(CardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public async Task<IEnumerable<CardDto>> GetAllCardsAsync()
        {
            return await _cardRepository.GetAllCardsAsync();
        }
        public async Task<CardDto?> GetCardByIdAsync(string cardNumber)
        {
            return await _cardRepository.GetCardByIdAsync(cardNumber);
        }

        public async Task<IEnumerable<CardDto>> GetCardByCustomerAsync(int customerId)
        {
            return await _cardRepository.GetCardByCustomerAsync(customerId);
        }

        public async Task<CardDto> CreateCardAsync(CardDto card)
        {
            return await _cardRepository.CreateCardAsync(card);
        }
        public async Task<bool> UpdateCardAsync(string cardNumber, int customerId, string cardAccountNumber, decimal amount)
        {
            return await _cardRepository.UpdateCardAsync(cardNumber, customerId, cardAccountNumber, amount);
        }


        //To jest przygotowanie do wykupu: - sprawdzić, czy się nie da przenieść do CardValidator:
        public bool ValidateCard(string cardNumber, string cardAccountNumber)
        {

            var card = _cardRepository.UpdateCardForPaymentAsync(cardNumber, cardAccountNumber);
            return card != null;
        }


        public async Task<bool> DeleteCardAsync(string cardNumber)
        {
            return await _cardRepository.DeleteCardAsync(cardNumber);
        }


    }
}
