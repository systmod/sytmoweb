import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EditarproveedorComponent } from './editarproveedor.component';

const routes: Routes = [{ path: '', component: EditarproveedorComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EditarproveedorRoutingModule { }
