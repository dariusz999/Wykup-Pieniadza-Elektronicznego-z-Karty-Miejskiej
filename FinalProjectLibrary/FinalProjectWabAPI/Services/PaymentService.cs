using FinalProjectLibrary.Models;
using FinalProjectWabAPI.DTOs;
using FinalProjectWabAPI.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;

namespace FinalProjectWabAPI.Services
{
    public class PaymentService
    {
        private readonly PaymentRepository _paymentRepository;

        public PaymentService(PaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }
        public async Task<IEnumerable<PaymentDto>> GetAllPaymentsAsync()
        {
            var payments = await _paymentRepository.GetAllPaymentsAsync();
            return payments.Select(payment => new PaymentDto()
            {
                CardNumber = payment.CardNumber,
                CustomerId = payment.CustomerId,
                Name = payment.Name,
                Surname = payment.Surname,
                AccountNumber = payment.AccountNumber,
                Amount = payment.Amount,
                DetailsOfPayments = payment.DetailsOfPayments
            });
        }

        public async Task<PaymentDto?> GetPaymentByIdAsync(string cardNumber)
        {
            return await _paymentRepository.GetPaymentByIdAsync(cardNumber);
        }


        public async Task<PaymentDto> CreatePaymentAsync(Payment paymentDto)
        {
            var payment = await _paymentRepository.CreatePaymentAsync(paymentDto.CardNumber, paymentDto.Name, paymentDto.Surname, paymentDto.AccountNumber);

            var mappedPaymentDto = new PaymentDto()
            {
                CardNumber = paymentDto.CardNumber,
                Name = paymentDto.Name,
                Surname = paymentDto.Surname,
                AccountNumber = paymentDto.AccountNumber,
            };

            return (mappedPaymentDto);
        }


    }

}

