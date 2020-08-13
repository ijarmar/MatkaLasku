import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { ApiModule, BASE_PATH } from 'matkalasku-api-client';
import { environment } from '../environments/environment';

import { NewTripFormComponent } from './new-trip-form/new-trip-form.component';
import { HomeComponent } from './home/home.component';
import { CompanyListComponent } from './company-list/company-list.component';
import { TripListComponent } from './trip-list/trip-list.component';

const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'trip/new', component: NewTripFormComponent }
];

@NgModule({
  declarations: [   
    HomeComponent,
    CompanyListComponent,
    TripListComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes), 
    FormsModule,
    HttpClientModule,
    ApiModule,
    NgbModule,
  ],
  exports: [RouterModule],
  providers: [{ provide: BASE_PATH, useValue: environment.API_BASE_PATH }],
})
export class AppRoutingModule { }
