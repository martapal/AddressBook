import { Component, OnInit } from '@angular/core';
import { AddressService, Person } from '../../services/address/address.service';
import { MatDialog } from '@angular/material/dialog';
import { AddressDialogComponent } from '../address-dialog/address-dialog.component';

@Component({
  selector: 'app-address-list',
  templateUrl: './address-list.component.html',
  styleUrls: ['./address-list.component.scss']
})
export class AddressListComponent implements OnInit {
  people: Person[] = [];

  constructor(private addressService: AddressService, public dialog: MatDialog) { }

  ngOnInit(): void {
    this.addressService.getPeople().subscribe(data => {
      this.people = data;
    });
  }

  openDialog(person: Person): void {
    this.dialog.open(AddressDialogComponent, {
      width: '300px',
      data: person
    });
  }
}
