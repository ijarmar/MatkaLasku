import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { HttpClientModule } from '@angular/common/http';
import { ApiModule, BASE_PATH } from 'matkalasku-api-client';
import { environment } from '../environments/environment';

import { CompanyListComponent } from './company-list/company-list.component';
import { TripListComponent } from './trip-list/trip-list.component';

@NgModule({
  declarations: [
    AppComponent,
    CompanyListComponent,
    TripListComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    ApiModule,
    AppRoutingModule,
    NgbModule
  ],
  providers: [{ provide: BASE_PATH, useValue: environment.API_BASE_PATH }],
  bootstrap: [AppComponent]
})
export class AppModule { }
