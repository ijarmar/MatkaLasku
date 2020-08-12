import { Component } from '@angular/core';
import { CompaniesService, CompanyDTO } from 'matkalasku-api-client';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Frontend';

  constructor(companiesService: CompaniesService) {
    var company: CompanyDTO = {
      name: 'Nettifixium'
    };

    companiesService
      .postCompany(company)
      .subscribe(console.log);

    companiesService.getCompanies().subscribe(console.log);
  }
}
