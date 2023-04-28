import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ListaproveedoresRoutingModule } from './listaproveedores-routing.module';
import { ListaproveedoresComponent } from './listaproveedores.component';
import { sharedModule } from 'src/app/shared/shared.module';


@NgModule({
  declarations: [
    ListaproveedoresComponent
  ],
  imports: [
    CommonModule,
    ListaproveedoresRoutingModule,
    sharedModule
  ]
})
export class ListaproveedoresModule { }
