import { Component, OnInit } from '@angular/core';
import { Sort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import {
  apiResultFormat,
  DataService,
  pageSelection,
  routes,
} from 'src/app/core/core.index';
import { ApisService } from 'src/app/core/service/data/apis.service';
import { PaginationService, tablePageSize } from 'src/app/shared/shared.index';
import { SweetalertService } from 'src/app/shared/sweetalert/sweetalert.service';

@Component({
  selector: 'app-customerlist',
  templateUrl: './customerlist.component.html',
  styleUrls: ['./customerlist.component.scss'],
})
export class CustomerlistComponent implements OnInit {
  public routes = routes;
  initChecked: boolean = false;
  public tableData: Array<any> = [];
  // pagination variables
  pageSize: number = 10;
  length = 100;
  pageSizeOptions: number[] = [5, 10, 25, 100];
  public serialNumberArray: Array<any> = [];
  public totalData: any = 0;
  showFilter: boolean = false;
  dataSource!: MatTableDataSource<any>;
  public searchDataValue = '';
  //** / pagination variables



  constructor(
    private data: ApisService,
    private pagination: PaginationService,
    private sweetalert: SweetalertService,
    private router: Router
  ) {
  }

  deleteBtn(id: number, i: number) {
    this.sweetalert.dinamicConfirmDialog('Esta seguro que desea eliminar este cliente').then((result) => {
      if (result.isConfirmed) {
        this.data.deleteEntidad(id).subscribe(res => {
          this.tableData.splice(i, 1)
        })
      }
    });
  }

  ngOnInit(): void {
    this.getClienntes(1, 10)
  }
  public searchData(value: any): void {
    this.dataSource.filter = value.trim().toLowerCase();
    this.tableData = this.dataSource.filteredData;
  }

  public sortData(sort: Sort) {
    const data = this.tableData.slice();

    if (!sort.active || sort.direction === '') {
      this.tableData = data;
    } else {
      this.tableData = data.sort((a: any, b: any) => {
        const aValue = (a as any)[sort.active];
        const bValue = (b as any)[sort.active];
        return (aValue < bValue ? -1 : 1) * (sort.direction === 'asc' ? 1 : -1);
      });
    }
  }

  selectAll(initChecked: boolean) {
    if (!initChecked) {
      this.tableData.forEach((f: any) => {
        f.isSelected = true;
      });
    } else {
      this.tableData.forEach((f: any) => {
        f.isSelected = false;
      });
    }
  }
  paginate(event: any) {
    this.getClienntes(event.pageIndex + 1, 10)
  }

  getClienntes(pagina?: number, size?: number, termino?: string) {
    this.tableData = [];
    this.data.getClientes(pagina, size, termino).subscribe(clientes => {
      this.tableData = clientes.result
      this.length = clientes.length || 0
      this.dataSource = new MatTableDataSource<any>(this.tableData);
    })
  }
  // [routerLink]="routes.editCustomer"
  editarCliente(id: number) {
    this.router.navigate([this.routes.editCustomer], { queryParams: { cliente: id } })
  }
}
