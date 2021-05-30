using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SecondHandCars.Models
{
    public class Warehouse
    {
        [BsonId]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("location")]
        public Location Location { get; set; }

        [BsonElement("cars")]
        public Cars Cars { get; set; }

    }
}