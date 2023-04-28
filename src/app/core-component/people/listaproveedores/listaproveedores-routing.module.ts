import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListaproveedoresComponent } from './listaproveedores.component';

const routes: Routes = [{ path: '', component: ListaproveedoresComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ListaproveedoresRoutingModule { }
