using Dapper;
using FinalProjectLibrary;
using FinalProjectLibrary.Models;
using FinalProjectWabAPI.Db;
using FinalProjectWabAPI.DTOs;
using Microsoft.Data.SqlClient;

namespace FinalProjectWabAPI.Repositories
{
    public class CardRepository
    {
        private readonly IDapperContext _dapperContext;

        public CardRepository(IDapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<IEnumerable<CardDto>> GetAllCardsAsync()
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                var sql = "SELECT * FROM Cards";
                return await connection.QueryAsync<CardDto>(sql);
            }
        }
        public async Task<CardDto?> GetCardByIdAsync(string cardNumber)
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                var sql = "SELECT * FROM Cards WHERE CardNumber = @CardNumber";
                return await connection.QuerySingleOrDefaultAsync<CardDto>(sql, new { CardNumber = cardNumber });
            }
        }

        public async Task<IEnumerable<CardDto>> GetCardByCustomerAsync(int customerId)
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                var sql = "SELECT * FROM Cards WHERE CustomerId = @CustomerId";
                return await connection.QueryAsync<CardDto>(sql, new { CustomerId = customerId });
            }
        }

        public async Task<CardDto> CreateCardAsync(CardDto card)
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                var sql =
                    "INSERT INTO Cards (CardNumber, CustomerId, CardAccountNumber, Amount) VALUES (@CardNumber, @CustomerId, @CardAccountNumber, @Amount); SELECT CAST(SCOPE_IDENTITY() as char)";
                var id = await connection.ExecuteScalarAsync<string>(sql, card);
                card.CardNumber = id;
                return card;
            }
        }

        public async Task<bool> UpdateCardAsync(string cardNumber, int customerId, string cardAccountNumber, decimal amount)
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                var sql = "UPDATE Cards SET CardNumber = @CardNumber, CustomerId = @CustomerId, CardAccountNumber = @CardAccountNumber, Amount = @Amount WHERE CardNumber = @CardNumber";
                var affectedRows = await connection.ExecuteAsync(sql, new
                {
                    CardNumber = cardNumber,
                    CustomerId = customerId,
                    CardAccountNumber = cardAccountNumber,
                    Amount = amount

                });
                return affectedRows > 0;
            }
        }

        //Tu jest do oznaczenia karty jako opłacona - sprawdzić czy można przenieść do CardValidator:
        public async Task<bool> UpdateCardForPaymentAsync(string cardNumber, string cardAccountNumber)
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                var sql = "SELECT CardNumber, CardAccountNumber, Amount FROM Cards WHERE CardNumber = @CardNumber AND CardAccountNumber = @CardAccountNumber " +
                          "UPDATE Cards SET CardPaid = 1 WHERE CardNumber = @CardNumber";
                var affectedRows = await connection.ExecuteAsync(sql, new
                {
                    CardNumber = cardNumber,
                    CardAccountNumber = cardAccountNumber,

                });
                return affectedRows > 0;
            }
        }

        public async Task<bool> DeleteCardAsync(string cardNumber)
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                var sql = "DELETE FROM Cards WHERE CardNumber = @CardNumber";
                var affectedRows = await connection.ExecuteAsync(sql, new { CardNumber = cardNumber });
                return affectedRows > 0;
            }
        }


    }
}
