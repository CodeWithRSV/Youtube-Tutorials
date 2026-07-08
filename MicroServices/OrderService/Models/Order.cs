using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace OrderService.Models
{
    public class Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

        [Required]
        public string CustomerName { get; set; } = null!;

        [Required]
        public string Product { get; set; } = null!;

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        public string Status { get; set; } = "Pending";
    }
}
