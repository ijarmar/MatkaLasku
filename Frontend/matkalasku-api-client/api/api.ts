export * from './companies.service';
import { CompaniesService } from './companies.service';
export * from './invoices.service';
import { InvoicesService } from './invoices.service';
export * from './trips.service';
import { TripsService } from './trips.service';
export const APIS = [CompaniesService, InvoicesService, TripsService];
