import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CoreComponentRoutingModule } from './core-component-routing.module';
import { CoreComponentComponent } from './core-component.component';

import { SidebarOneComponent } from '../common-component/sidebar-one/sidebar-one.component';
import { SidebarTwoComponent } from '../common-component/sidebar-two/sidebar-two.component';
import { SidebarThreeComponent } from '../common-component/sidebar-three/sidebar-three.component';
import { SidebarFourComponent } from '../common-component/sidebar-four/sidebar-four.component';
import { SidebarFiveComponent } from '../common-component/sidebar-five/sidebar-five.component';
import { HeaderComponent } from '../common-component/header/header.component';
import { LayoutComponent } from '../common-component/layout/layout.component';
import { sharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [
    CoreComponentComponent,
    HeaderComponent,
    SidebarOneComponent,
    SidebarTwoComponent,
    SidebarThreeComponent,
    SidebarFourComponent,
    SidebarFiveComponent,
    LayoutComponent,
  ],
  imports: [CommonModule, CoreComponentRoutingModule, sharedModule],
  providers: [],
})
export class CoreComponentModule { }
