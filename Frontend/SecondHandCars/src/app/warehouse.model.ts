export interface Warehouse {
    id:       string;
    name:     string;
    location: Location;
    cars:     Cars;
}

export interface Cars {
    location: string;
    vehicles: Vehicle[];
}

export interface Vehicle {
    id:        number;
    make:      string;
    model:     string;
    yearModel: number;
    price:     number;
    licensed:  boolean;
    dateAdded: string;
}

export interface Location {
    lat:  number;
    long: number;
}
