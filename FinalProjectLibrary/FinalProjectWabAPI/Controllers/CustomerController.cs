//using FinalProjectDapper.Services;
using FinalProjectLibrary.Models;
using FinalProjectWabAPI.DTOs;
using FinalProjectWabAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProjectWabAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _customerService;
        public CustomerController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: api/<CustomerController>
        [HttpGet]
        public async Task<List<Customer>> GetAllCustomers()
        {
            var customers = await _customerService.GetAllCustomersAsync();
            return customers.ToList();
        }

        // GET api/<CustomerController>/5
        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetCustomerById(int customerId)
        {
            var customer = await _customerService.GetCustomerByIdAsync(customerId);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] Customer customer)
        {
            var customerId = await _customerService.CreateCustomerAsync(customer);
            return Ok(customerId);
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{customerId}")]
        public async Task<IActionResult> UpdateCustomer(int customerId, string name, string surname, string pesel)

        {
            bool updated = await _customerService.UpdateCustomerAsync(customerId, name, surname, pesel);
            if (!updated)
            {
                return NotFound();
            }
            return Ok();
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{customerId}")]
        public async Task<IActionResult> DeleteCustomer(int customerId)
        {
            var result = await _customerService.DeleteCustomerAsync(customerId);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
