import { Component, OnInit } from '@angular/core';
import { CompaniesService, CompanyDTO } from 'matkalasku-api-client';

@Component({
  selector: 'app-company-list',
  templateUrl: './company-list.component.html',
  styleUrls: ['./company-list.component.css']
})
export class CompanyListComponent implements OnInit {
  companies: CompanyDTO[] = [];

  constructor(
    private companiesService: CompaniesService
  ) {
    this.companiesService.getCompanies().subscribe(c => {
      this.companies.push(...c);
    });
  }

  ngOnInit(): void {}
}
