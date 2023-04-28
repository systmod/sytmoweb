import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ElementRoutingModule } from './element-routing.module';
import { ElementComponent } from './element.component';


@NgModule({
  declarations: [
    ElementComponent
  ],
  imports: [
    CommonModule,
    ElementRoutingModule
  ]
})
export class ElementModule { }
