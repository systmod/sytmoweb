import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { OwlOptions } from 'ngx-owl-carousel-o';
import { Producto } from 'src/app/core/core.index';
import { ApisService } from 'src/app/core/service/data/apis.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss'],
})
export class ProductDetailsComponent implements OnInit {
  customOptions: OwlOptions = {
    loop: true,
    mouseDrag: false,
    touchDrag: false,
    pullDrag: false,
    dots: false,
    navSpeed: 700,
    navText: [
      '<i class="fas fa-chevron-left"></i>',
      '<i class="fas fa-chevron-right"></i>',
    ],
    responsive: {
      0: {
        items: 1,
      },
      400: {
        items: 2,
      },
    },
    nav: true,
  };
  idProducto?: number
  producto?: Producto;
  constructor(
    private api: ApisService,
    private routerActive: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.routerActive.queryParams.subscribe(params => {
      this.idProducto = params['producto']
      if (this.idProducto) {
        this.getProductoId(this.idProducto)
      }
    })
  }

  getProductoId(id: number) {
    this.api.getProductoById(id).subscribe(producto => {
      const Datosproducto = {
        codigo: producto.result['codigo'],
        nombre: producto.result['nombre'],
        marca: producto.result['marca'],
        unidad: producto.result['unidad'],
        valorUltimaCompra: producto.result['valorUltimaCompra'],
        fechaUltimaCompra: producto.result['fechaUltimaCompra'],
        pvpA: producto.result['pvpA'],
        comentario: producto.result['comentario'],
      }
      this.producto = Datosproducto
    })
  }

}
