//using FinalProjectDapper.Repositories;
using FinalProjectLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProjectLibrary.Models;
using FinalProjectWabAPI.Repositories;

namespace FinalProjectWabAPI.Services
{
    public class CustomerService
    {
        private readonly CustomerRepository _customerRepository;

        public CustomerService(CustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await _customerRepository.GetAllCustomersAsync();
        }
        public async Task<Customer?> GetCustomerByIdAsync(int id)
        {
            return await _customerRepository.GetCustomerByIdAsync(id);
        }

        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            return await _customerRepository.CreateCustomerAsync(customer);
        }
        public async Task<bool> UpdateCustomerAsync(int id, string name, string surname, string pesel)
        {
            return await _customerRepository.UpdateCustomerAsync(id, name, surname, pesel);
        }

        public async Task<bool> DeleteCustomerAsync(int id)
        {
            return await _customerRepository.DeleteCustomerAsync(id);
        }
    }
}