import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EditcustomerRoutingModule } from './editcustomer-routing.module';
import { EditcustomerComponent } from './editcustomer.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSelectModule } from '@angular/material/select';


@NgModule({
  declarations: [
    EditcustomerComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    MatInputModule,
    MatSelectModule,
    MatPaginatorModule,
    EditcustomerRoutingModule
  ]
})
export class EditcustomerModule { }
