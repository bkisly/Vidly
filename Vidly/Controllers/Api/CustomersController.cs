using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Vidly.Models.DataTransferObjects;
using Vidly.Services;
using System.Diagnostics;

namespace Vidly.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersDataService _service;

        public CustomersController(ICustomersDataService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetCustomers()
        {
            var customers = await _service.GetItemsAsync();
            return customers.Select(c => CustomerDto.ConvertToDto(c)).ToArray();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDto>> GetCustomer(int id)
        {
            var customer = await _service.GetItemByIdAsync(id);
            return customer != null ? CustomerDto.ConvertToDto(customer) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<CustomerDto>> PostCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var customer = customerDto.ConvertToModel();
            await _service.AddItemAsync(customer);

            return CreatedAtAction(nameof(PostCustomer), new { id = customer.Id }, CustomerDto.ConvertToDto(customer));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            try
            {
                await _service.UpdateItemAsync(id, customerDto.ConvertToModel());
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            try
            {
                await _service.DeleteItemAsync(id);
            }
            catch(InvalidOperationException)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}