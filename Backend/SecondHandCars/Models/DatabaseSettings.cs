namespace SecondHandCars.Models
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string WarehousesCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IDatabaseSettings
    {
        string WarehousesCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}