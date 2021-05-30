using SecondHandCars.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace SecondHandCars.Services
{
    public class WarehouseService : IWarehouseService
    {
        private readonly IMongoCollection<Warehouse> _warehouses;

        public WarehouseService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _warehouses = database.GetCollection<Warehouse>(settings.WarehousesCollectionName);
        }

        public List<Warehouse> Get() =>
            _warehouses.Find(warehouse => true).ToList();

    }
}