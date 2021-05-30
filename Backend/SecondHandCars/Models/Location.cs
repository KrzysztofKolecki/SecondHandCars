using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SecondHandCars.Models
{
    public class Location
    {
        [BsonElement("lat")]
        public decimal Lat { get; set; }

        [BsonElement("long")]
        public decimal Long { get; set; }
    }
}