using SecondHandCars.Models;
using SecondHandCars.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace SecondHandCars.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehousesController : ControllerBase
    {
        private readonly IWarehouseService _warehouseService;

        public WarehousesController(IWarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }

        [HttpGet]
        public ActionResult<List<Warehouse>> Get() =>
            _warehouseService.Get();

    }
}