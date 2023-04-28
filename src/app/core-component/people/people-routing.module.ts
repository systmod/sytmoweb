import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PeopleComponent } from './people.component';

const routes: Routes = [
  { path: '', redirectTo: 'customerlist', pathMatch: 'full' },
  {
    path: '',
    children: [
      {
        path: 'lista-clientes',
        loadChildren: () =>
          import('./customerlist/customerlist.module').then(
            (m) => m.CustomerlistModule
          ),
      },
      {
        path: 'lista-proveedores',
        loadChildren: () =>
          import('./listaproveedores/listaproveedores.module').then(
            (m) => m.ListaproveedoresModule
          ),
      },
      {
        path: 'crear-cliente',
        loadChildren: () =>
          import('./addcustomer/addcustomer.module').then(
            (m) => m.AddcustomerModule
          ),
      },
      {
        path: 'crear-proveedor',
        loadChildren: () =>
          import('./editarproveedor/editarproveedor.module').then(
            (m) => m.EditarproveedorModule
          ),
      },
      {
        path: 'supplier-list',
        loadChildren: () =>
          import('./supplierlist/supplierlist.module').then(
            (m) => m.SupplierlistModule
          ),
      },
      {
        path: 'add-supplier',
        loadChildren: () =>
          import('./addsupplier/addsupplier.module').then(
            (m) => m.AddsupplierModule
          ),
      },
      {
        path: 'user-list',
        loadChildren: () =>
          import('./userlist/userlist.module').then((m) => m.UserlistModule),
      },
      {
        path: 'add-user',
        loadChildren: () =>
          import('./adduser/adduser.module').then((m) => m.AdduserModule),
      },
      {
        path: 'store-list',
        loadChildren: () =>
          import('./storelist/storelist.module').then((m) => m.StorelistModule),
      },
      {
        path: 'add-store',
        loadChildren: () =>
          import('./addstore/addstore.module').then((m) => m.AddstoreModule),
      },
      {
        path: 'editar-cliente',
        loadChildren: () =>
          import('./addcustomer/addcustomer.module').then(
            (m) => m.AddcustomerModule
          ),
      },
      {
        path: 'editar-proveedor',
        loadChildren: () =>
          import('./editarproveedor/editarproveedor.module').then(
            (m) => m.EditarproveedorModule
          ),
      },
      {
        path: 'edit-supplier',
        loadChildren: () =>
          import('./editsupplier/editsupplier.module').then(
            (m) => m.EditsupplierModule
          ),
      },
      {
        path: 'edit-user',
        loadChildren: () =>
          import('./edituser/edituser.module').then((m) => m.EdituserModule),
      },
      {
        path: 'edit-store',
        loadChildren: () =>
          import('./editstore/editstore.module').then((m) => m.EditstoreModule),
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class PeopleRoutingModule { }
