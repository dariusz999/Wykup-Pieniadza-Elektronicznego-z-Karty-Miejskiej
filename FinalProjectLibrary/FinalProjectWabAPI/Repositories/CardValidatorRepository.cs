using Dapper;
using FinalProjectWabAPI.Db;
using FinalProjectWabAPI.DTOs;
using FinalProjectLibrary.Models;


namespace FinalProjectWabAPI.Repositories
{
    public class CardValidatorRepository
    {
        private readonly IDapperContext _dapperContext;

        public CardValidatorRepository(IDapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<IEnumerable<CardValidator>> GetAllCardsAsync()
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                var sql = "SELECT Customers.*, Cards.* FROM Cards JOIN Customers ON Cards.CustomerId = Customers.CustomerId";
                return await connection.QueryAsync<CardValidator>(sql);
            }
        }
        public async Task<CardValidator?> GetCardByIdAsync(string cardNumber)
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                var sql =
                    "SELECT Customers.*, Cards.* FROM Cards JOIN Customers ON Cards.CustomerId = Customers.CustomerId WHERE AND CardNumber = @CardNumber";
                //"SELECT Customers.*, Cards.CardNumber, Cards.CardAccountNumber, Cards.Amount, Cards.CardPaid FROM Cards JOIN Customers ON Cards.CustomerId = Customers.CustomerId ORDER BY Customers.CustomerId WHERE CardNumber = @CardNumber";
                return await connection.QuerySingleOrDefaultAsync<CardValidator>(sql, new { CardNumber = cardNumber });
            }
        }
    }
}
