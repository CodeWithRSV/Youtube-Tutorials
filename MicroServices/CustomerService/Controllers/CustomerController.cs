using CustomerService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace CustomerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerDbContext _dbContext;
        public CustomerController(CustomerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/customer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetAllCustomers()
        {
            var customers = await _dbContext.Customers.ToListAsync();
            return Ok(customers);
        }

        // GET: api/customer/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomerById(int id)
        {
            var customer = await _dbContext.Customers.FindAsync(id);
            if (customer == null)
                return NotFound($"Customer with id {id} not found");

            return Ok(customer);
        }

        // POST: api/customer
        [HttpPost]
        public async Task<ActionResult<Customer>> CreateCustomer([FromBody] Customer customer)
        {
            await _dbContext.Customers.AddAsync(customer);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCustomerById), new { id = customer.Id }, customer);
        }

        // PUT: api/customer/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, [FromBody] Customer customer)
        {
            if (id != customer.Id)
                return BadRequest("Id mismatch");

            var existingCustomer = await _dbContext.Customers.FindAsync(id);
            if (existingCustomer == null)
                return NotFound($"Customer with id {id} not found");

            existingCustomer.Name = customer.Name;
            existingCustomer.Email = customer.Email;
            existingCustomer.MobileNumber = customer.MobileNumber;

            _dbContext.Customers.Update(existingCustomer);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/customer/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _dbContext.Customers.FindAsync(id);
            if (customer == null)
                return NotFound($"Customer with id {id} not found");

            _dbContext.Customers.Remove(customer);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
