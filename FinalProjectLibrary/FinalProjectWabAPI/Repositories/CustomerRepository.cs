using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using FinalProjectWabAPI.Db;
using FinalProjectLibrary.Models;

namespace FinalProjectWabAPI.Repositories
{
    public class CustomerRepository
    {
        private readonly IDapperContext _dapperContext;

        public CustomerRepository(IDapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                var sql = "SELECT * FROM Customers";
                return await connection.QueryAsync<Customer>(sql);
            }
        }
        public async Task<Customer?> GetCustomerByIdAsync(int customerId)
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                var sql = "SELECT * FROM Customers WHERE CustomerId = @CustomerId";
                return await connection.QuerySingleOrDefaultAsync<Customer>(sql, new { CustomerId = customerId });
            }
        }

        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                var sql =
                    "INSERT INTO Customers (Name, Surname, Pesel) VALUES (@Name, @Surname, @Pesel); SELECT CAST(SCOPE_IDENTITY() as int)";
                var id = await connection.ExecuteScalarAsync<int>(sql, customer);
                customer.CustomerId = id;
                return customer;
            }
        }

        public async Task<bool> UpdateCustomerAsync(int customerId, string name, string surname, string pesel)
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                var sql = "UPDATE Customers SET Name = @Name, Surname = @Surname, Pesel = @Pesel WHERE CustomerId = @CustomerId";
                var affectedRows = await connection.ExecuteAsync(sql, new
                {
                    CustomerId = customerId,
                    Name = name,
                    Surname = surname,
                    Pesel = pesel
                });
                return affectedRows > 0;
            }
        }

        public async Task<bool> DeleteCustomerAsync(int customerId)
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                var sql = "DELETE FROM Customers WHERE CustomerId = @CustomerId";
                var affectedRows = await connection.ExecuteAsync(sql, new { CustomerId = customerId });
                return affectedRows > 0;
            }
        }

    }
}
