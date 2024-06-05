using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CaterMate_Backend.Models
{
    public class Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("service")]
        public string Service { get; set; }

        [BsonElement("date")]
        public DateTime Date { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("phone")]
        public string Phone { get; set; }

        [BsonElement("address")]
        public string Address { get; set; }

        [BsonElement("status")]
        public string Status { get; set; }

        [BsonIgnore]
        public int __v { get; set; }
    }
}
