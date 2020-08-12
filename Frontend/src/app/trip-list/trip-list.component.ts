import { Component, OnInit } from '@angular/core';
import { TripsService, TripDTO } from 'matkalasku-api-client';

@Component({
  selector: 'app-trip-list',
  templateUrl: './trip-list.component.html',
  styleUrls: ['./trip-list.component.css']
})
export class TripListComponent implements OnInit {
  trips: TripDTO[] = [];
  
  constructor(private tripsService: TripsService) {
    this.tripsService.getTrips().subscribe(t => {
      this.trips.push(...t);
    });
  }

  ngOnInit(): void {}
}
