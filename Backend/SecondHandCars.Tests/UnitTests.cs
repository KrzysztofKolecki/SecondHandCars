using System;
using Xunit;
using SecondHandCars.Services;
using SecondHandCars.Models;
using SecondHandCars.Controllers;
using Moq;
using System.Collections.Generic;

namespace SecondHandCars.Tests
{
    public class UnitTests
    {
        [Fact]
        public void Get_ShouldReturnWarehouses()
        {
             // Arrange
            var warehouses = new List<Warehouse>();
            var warehouse = new Warehouse() {
                Id = "1",
                Name = "test",
                Location = null,
                Cars = null
            };
            warehouses.Add(warehouse);

            var warehouseServiceMock = new Mock<IWarehouseService>();
            warehouseServiceMock.Setup(p => p.Get()).Returns(warehouses);

            var warehouseController = new WarehousesController(warehouseServiceMock.Object);

            // Act
            var result = warehouseController.Get();

            // Assert
            Assert.Equal(warehouses[0].Id, result.Value[0].Id);
            Assert.Equal(warehouses[0].Name, result.Value[0].Name);

        }
    }
}
