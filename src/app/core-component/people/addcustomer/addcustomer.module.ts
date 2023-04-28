import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AddcustomerRoutingModule } from './addcustomer-routing.module';
import { AddcustomerComponent } from './addcustomer.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatPaginatorModule } from '@angular/material/paginator';


@NgModule({
  declarations: [
    AddcustomerComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    MatInputModule,
    MatSelectModule,
    MatPaginatorModule,
    AddcustomerRoutingModule
  ]
})
export class AddcustomerModule { }
