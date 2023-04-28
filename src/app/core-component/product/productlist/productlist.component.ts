import { Component, OnInit } from '@angular/core';
import { Sort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import {
  apiResultFormat,
  DataService,
  pageSelection,
  routes,
} from 'src/app/core/core.index';
import { PaginationService, tablePageSize } from 'src/app/shared/shared.index';
import { SweetalertService } from 'src/app/shared/sweetalert/sweetalert.service';
import { Router } from '@angular/router';
import { ApisService } from 'src/app/core/service/data/apis.service';

@Component({
  selector: 'app-productlist',
  templateUrl: './productlist.component.html',
  styleUrls: ['./productlist.component.scss'],
})
export class ProductlistComponent implements OnInit {
  initChecked: boolean = false;
  public tableData: Array<any> = [];
  public routes = routes;
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
    private sweetlalert: SweetalertService,
    private router: Router
  ) { }

  deleteBtn(id: number, i: number) {
    this.sweetlalert.dinamicConfirmDialog('Esta seguro que desea eliminar este cliente').then((result) => {
      if (result.isConfirmed) {
        this.data.deleteProducto(id).subscribe(res => {
          this.tableData.splice(i, 1)
        })
      }
    });
  }
  ngOnInit(): void {
    this.getProductos(1, 10)
  }

  public searchData(value: any): void {
    this.dataSource.filter = value.trim().toLowerCase();
    this.tableData = this.dataSource.filteredData;
    this.getProductos(1, 10, value.trim().toLowerCase())
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
    this.getProductos(event.pageIndex + 1, 10, this.dataSource.filter)
  }

  getProductos(pagina?: number, size?: number, termino?: string) {
    this.tableData = [];
    this.data.getProductos(pagina, size, termino).subscribe(clientes => {
      this.tableData = clientes.result
      this.length = clientes.length || 0
      this.dataSource = new MatTableDataSource<any>(this.tableData);
    })
  }
  verProducto(id: number) {
    this.router.navigate([this.routes.verProducto], { queryParams: { producto: id } })
  }
  editarProdcuto(id: number) {
    this.router.navigate([this.routes.editProduct], { queryParams: { producto: id } })
  }
}
