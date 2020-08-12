import { Component, OnInit } from '@angular/core';
import { TripsService, TripDTO } from 'matkalasku-api-client';
import { NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-new-trip-form',
  templateUrl: './new-trip-form.component.html',
  styleUrls: ['./new-trip-form.component.css']
})
export class NewTripFormComponent implements OnInit {
  trip: TripDTO = {
    companyId: 0,
    departure: new Date(),
    recurrence: new Date(),
    recipient: '',
    purpose: '',
    distanceInKM: 0,
    locationDeparture: '',
    locationDestination: '',
    description: '',
    passengerCount: 0
  };
  departureDate: NgbDateStruct;
  recurrenceDate: NgbDateStruct;
  departureTime: object = { hour: 10, minute: 0 };
  recurrenceTime: object = { hour: 11, minute: 30 };

  constructor(tripsService: TripsService) {}

  onSubmit(trip: TripDTO): void {
    
  }

  ngOnInit(): void {}

}
