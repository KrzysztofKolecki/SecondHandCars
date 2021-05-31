import { Component, OnInit } from '@angular/core';
import { Vehicle, Warehouse } from './warehouse.model';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  warehouses: Warehouse[] = [];
  displayModal = false;
  carDetailsWarehouse = '';
  carDetailsLocation = '';

  shoppingCartCars: Vehicle[] = [];

  constructor(private httpClient: HttpClient) { }

  ngOnInit() {
    this.httpClient.get<Warehouse[]>('https://localhost:5001/api/warehouses').subscribe((data: Warehouse[]) => {
      this.warehouses = data;
    });
  }

  getCars(): Vehicle[] {

    if (!this.warehouses) return [];

    const vehicles: Vehicle[] = [];

    this.warehouses.forEach(warehouse => warehouse.cars.vehicles.forEach(vehicle => {
      vehicle.warehouseId = warehouse.id;
      vehicles.push(vehicle);
    }));

    vehicles.sort((a, b) => a.dateAdded > b.dateAdded ? -1 : 1)

    return vehicles;
  }

  onVehicleClick(warehouseId: string, vehicleId: number): void {

    if(this.warehouses.find(w => w.id === warehouseId)!.cars.vehicles.find(v => v.id === vehicleId)!.licensed) {
      this.displayModal = true;
      this.carDetailsWarehouse = this.warehouses.find(w => w.id === warehouseId)!.name;
      this.carDetailsLocation = this.warehouses.find(w => w.id === warehouseId)!.cars.location;
    }

  }

  addCarToShoppingCart(warehouseId: string, vehicleId: number): void {
    this.shoppingCartCars.push(this.warehouses.find(w => w.id === warehouseId)!.cars.vehicles.find(v => v.id === vehicleId)!);
    this.warehouses.find(w => w.id === warehouseId)!.cars.vehicles =
      this.warehouses.find(w => w.id === warehouseId)!.cars.vehicles.filter(v => v.id !== vehicleId);
  }

  deleteCarFromShoppingCart(warehouseId: string, vehicle: Vehicle): void {
    this.shoppingCartCars = this.shoppingCartCars.filter(c => c.id !== vehicle.id);
    this.warehouses.find(w => w.id === warehouseId)!.cars.vehicles.push(vehicle);
  }

  getTotalAmount(): string {
    let total = 0;
    this.shoppingCartCars.forEach(c => total += c.price);
    return total.toFixed(2);
  }

  closeModal(): void {
    this.displayModal = false;
  }

}
