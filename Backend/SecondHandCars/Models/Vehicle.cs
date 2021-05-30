using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace SecondHandCars.Models
{
    public class Vehicle
    {
        [BsonId]
        public int Id { get; set; }

        [BsonElement("make")]
        public string Make { get; set; }

        [BsonElement("model")]
        public string Model { get; set; }

        [BsonElement("year_model")]
        public int YearModel { get; set; }

        [BsonElement("price")]
        public decimal Price { get; set; }

        [BsonElement("licensed")]
        public bool Licensed { get; set; }

        [BsonElement("date_added")]
        public DateTime DateAdded { get; set; }
    }
}