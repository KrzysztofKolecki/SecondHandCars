using System.Collections.Generic;
using SecondHandCars.Models;

namespace SecondHandCars.Services
{
    public interface IWarehouseService
    {
        List<Warehouse> Get();
    }
}