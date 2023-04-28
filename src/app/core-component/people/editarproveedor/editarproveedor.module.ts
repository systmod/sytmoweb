import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EditarproveedorRoutingModule } from './editarproveedor-routing.module';
import { EditarproveedorComponent } from './editarproveedor.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSelectModule } from '@angular/material/select';


@NgModule({
  declarations: [
    EditarproveedorComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    MatInputModule,
    MatSelectModule,
    MatPaginatorModule,
    EditarproveedorRoutingModule
  ]
})
export class EditarproveedorModule { }
