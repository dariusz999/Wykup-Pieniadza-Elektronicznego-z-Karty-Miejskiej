using Dapper;
using FinalProjectLibrary.Models;
using FinalProjectWabAPI.Db;
using FinalProjectWabAPI.DTOs;

namespace FinalProjectWabAPI.Repositories
{
    public class PaymentRepository
    {
        private readonly IDapperContext _dapperContext;

        public PaymentRepository(IDapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<IEnumerable<Payment>> GetAllPaymentsAsync()
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                var sql = "SELECT * FROM Payments";
                return await connection.QueryAsync<Payment>(sql);
            }
        }
        public async Task<PaymentDto?> GetPaymentByIdAsync(string cardNumber)
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                var sql = "SELECT * FROM Payments WHERE CardNumber = @CardNumber";
                return await connection.QuerySingleOrDefaultAsync<PaymentDto>(sql, new { CardNumber = cardNumber });
            }
        }
        public async Task<Payment> CreatePaymentAsync(string cardNumber, string name, string surname, string accountNumber)
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                var sql =
                    "INSERT INTO Payments(CardNumber, CustomerId, Name, Surname, AccountNumber, Amount, DetailsOfPayments) " +
                    "SELECT Cards.CardNumber, Customers.CustomerId, Customers.Name, Customers.Surname, Cards.CardAccountNumber, Cards.Amount, 'Wykup z karty nr: ' + Cards.CardNumber " +
                    "FROM Cards JOIN Customers ON Cards.CustomerId = Customers.CustomerId WHERE CardNumber = @CardNumber;" +
                    " UPDATE Payments" +
                    " SET AccountNumber = @AccountNumber, Name = @Name, Surname = @Surname WHERE CardNumber = @CardNumber";
                var payment = await connection.ExecuteScalarAsync(sql, new
                {
                    CardNumber = cardNumber,
                    Name = name,
                    Surname = surname,
                    AccountNumber = accountNumber

                });
                return (payment as Payment);

            }
        }



    }
}
