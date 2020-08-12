import { Component } from '@angular/core';
import { CompaniesService, CompanyDTO } from 'matkalasku-api-client';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  companies: CompanyDTO[] = [];

  constructor(private companiesService: CompaniesService) {
    this.companiesService.getCompanies().subscribe(companies => {
      this.companies.push(...companies);
    });
  }
}
