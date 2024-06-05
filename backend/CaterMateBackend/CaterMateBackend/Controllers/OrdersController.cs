using CaterMate_Backend.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace CaterMate_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMongoCollection<Order> _ordersCollection;

        public OrdersController(IMongoClient client)
        {
            var database = client.GetDatabase("catermate");
            _ordersCollection = database.GetCollection<Order>("orders");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            var orders = await _ordersCollection.Find(order => true).ToListAsync();
            return Ok(orders);
        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Order>> GetOrderById(string id)
        {
            var order = await _ordersCollection.Find<Order>(order => order.Id == id).FirstOrDefaultAsync();
            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(Order order)
        {
            // Ensure Id is not set to avoid duplicate key error
            order.Id = null;

            await _ordersCollection.InsertOneAsync(order);
            return CreatedAtAction(nameof(GetOrders), new { id = order.Id }, order);
        }

        [HttpDelete("cancel/{id:length(24)}")]
        public async Task<IActionResult> CancelOrder(string id)
        {
            var result = await _ordersCollection.DeleteOneAsync(o => o.Id == id);

            if (result.DeletedCount == 0)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}