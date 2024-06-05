using CaterMate_Backend.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace CaterMate_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OffersController : ControllerBase
    {
        private readonly IMongoCollection<Offer> _offersCollection;

        public OffersController(IMongoClient client)
        {
            var database = client.GetDatabase("catermate");
            _offersCollection = database.GetCollection<Offer>("offers");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Offer>>> GetOffers()
        {
            var offers = await _offersCollection.Find(offer => true).ToListAsync();
            return Ok(offers);
        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Offer>> GetOffer(string id)
        {
            var offer = await _offersCollection.Find<Offer>(offer => offer.Id == id).FirstOrDefaultAsync();
            if (offer == null)
            {
                return NotFound();
            }

            return Ok(offer);
        }

        [HttpPost]
        public async Task<ActionResult<Offer>> CreateOffer(Offer offer)
        {
            offer.Id = null;

            await _offersCollection.InsertOneAsync(offer);
            return CreatedAtAction(nameof(GetOffer), new { id = offer.Id }, offer);
        }
        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> DeleteOffer(string id)
        {
            var result = await _offersCollection.DeleteOneAsync(o => o.Id == id);

            if (result.DeletedCount == 0)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
