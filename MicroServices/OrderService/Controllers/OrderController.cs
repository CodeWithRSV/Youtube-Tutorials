using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using OrderService.Models;

namespace OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderDbContext _context;

        public OrderController(OrderDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _context.Orders.ToListAsync();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order is null)
                return NotFound();

            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Order order)
        {
            order.Id = ObjectId.GenerateNewId().ToString();
            order.OrderDate = DateTime.UtcNow;

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = order.Id }, order);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Order updatedOrder)
        {
            if (!ObjectId.TryParse(id, out var objectId))
                return BadRequest("Invalid ID format");

            var existing = await _context.Orders.FindAsync(objectId);
            if (existing is null)
                return NotFound();

            existing.CustomerName = updatedOrder.CustomerName;
            existing.Product = updatedOrder.Product;
            existing.Quantity = updatedOrder.Quantity;
            existing.Price = updatedOrder.Price;
            existing.Status = updatedOrder.Status;

            await _context.SaveChangesAsync();
            return Ok(existing);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order is null)
                return NotFound();

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
