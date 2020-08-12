import { Component, OnInit } from '@angular/core';
import { CompaniesService, CompanyDTO } from 'matkalasku-api-client';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-company-list',
  templateUrl: './company-list.component.html',
  styleUrls: ['./company-list.component.css']
})
export class CompanyListComponent implements OnInit {
  companies: CompanyDTO[] = [];
  company: CompanyDTO = { name: '' };

  constructor(
    private companiesService: CompaniesService,
    private modalService: NgbModal  
  ) {
    this.companiesService.getCompanies().subscribe(c => {
      this.companies.push(...c);
    });
  }

  open(content): void {
    this.modalService.open(content, { ariaLabelledBy: 'company-new-form'});
  }

  onSubmit(company: CompanyDTO): void {
    this.companiesService.postCompany(company).subscribe(c => {
      this.companies.push(c);
      this.company.name = '';
    })
  }

  ngOnInit(): void {}
}
