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

  constructor(private httpClient: HttpClient) { }

  ngOnInit() {
    this.httpClient.get<Warehouse[]>('https://localhost:5001/api/warehouses').subscribe((data: Warehouse[]) => {
      this.warehouses = data;
      console.log(this.warehouses);
    });
  }

  getCars(): Vehicle[] {

    if (!this.warehouses) return [];

    const vehicles: Vehicle[] = [];

    this.warehouses.forEach(warehouse => warehouse.cars.vehicles.forEach(vehicle => vehicles.push(vehicle)));

    return vehicles;
  }

}
