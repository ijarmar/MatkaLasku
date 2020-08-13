import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { TripsService, CompaniesService, TripDTO, CompanyDTO } from 'matkalasku-api-client';
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
  companies: CompanyDTO[];
  selectedCompany: CompanyDTO;
  departureDate: NgbDateStruct;
  recurrenceDate: NgbDateStruct;
  departureTime = { hour: 10, minute: 0 };
  recurrenceTime = { hour: 11, minute: 30 };

  constructor(
    private tripsService: TripsService,
    private companiesService: CompaniesService,
    private router: Router
  ) {
    this.companiesService.getCompanies().subscribe(c => {
      this.companies = c;

      if (!this.companies.length) {
        this.router.navigate(['/']);
      }

      this.selectedCompany = c[0];
    });
  }

  onSelect(company: CompanyDTO): void {
    this.selectedCompany = company;
  }

  onSubmit(trip: TripDTO): void {
    trip.departure = new Date(`${this.departureDate.year}-${this.departureDate.month}-${this.departureDate.day} ${this.departureTime.hour}:${this.departureTime.minute}`);
    trip.recurrence = new Date(`${this.recurrenceDate.year}-${this.recurrenceDate.month}-${this.recurrenceDate.day} ${this.recurrenceTime.hour}:${this.recurrenceTime.minute}`);
    trip.companyId = this.selectedCompany.id;

    this.tripsService.postTrip(trip).subscribe(t => {
      this.router.navigate(['/']);
    });
  }

  ngOnInit(): void {}
}
