using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SecondHandCars.Models
{
    public class Cars
    {
        [BsonElement("location")]
        public string Location { get; set; }

        [BsonElement("vehicles")]
        public Vehicle[] Vehicles { get; set; }

    }
}