import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddressListComponent } from './components/address-list/address-list.component';
import { AboutComponent } from './components/about/about.component';

const routes: Routes = [
  { path: '', redirectTo: '/addresses', pathMatch: 'full' }, 
  { path: 'addresses', component: AddressListComponent }, 
  { path: 'about', component: AboutComponent },
  { path: '**', redirectTo: '/addresses' } 
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
