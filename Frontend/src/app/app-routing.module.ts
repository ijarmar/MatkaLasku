import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { NewTripFormComponent } from './new-trip-form/new-trip-form.component';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'trip/new', component: NewTripFormComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
