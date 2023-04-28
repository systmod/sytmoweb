import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { routes } from 'src/app/core/helpers/routes';
import { ApisService } from 'src/app/core/service/data/apis.service';
import { FormularioStorageService } from 'src/app/core/service/data/formulario-storage.service';
import { SweetalertService } from 'src/app/shared/sweetalert/sweetalert.service';

@Component({
  selector: 'app-addproduct',
  templateUrl: './addproduct.component.html',
  styleUrls: ['./addproduct.component.scss']
})
export class AddproductComponent implements OnInit {
  formularioProducto = this.fb.group({
    codigo: '',
    codigoInterno: '',
    codigoBarra: '',
    cuenta: '',
    cuenta2: '',
    cuenta3: '',
    nombre: '',
    presentacion: '',
    aplica: '',
    tipo: '',
    modelo: '',
    clase: '',
    subClase: '',
    origen: '',
    marca: '',
    unidad: '',
    factor: 0,
    ubica: '',
    validaStock: '',
    ivaSn: '',
    pvpA: 0,
    pvpB: 0,
    pvpC: 0,
    pvpD: 0,
    pvpE: 0,
    imagen: '',
    modificaPrecio: true,
    modificaDescripcion: true,
    porcentajeDescuento: 0,
    comentario: '',
    color: '',
    talla: '',
    pideSerie: true
  });
  formId = 'FormPro';
  boton = 'Crear';
  imageSelected: string | ArrayBuffer | null = null;
  idProducto?: number;
  esNuevo: boolean = true
  isZoomed = false;
  isModalOpen = false;
  dataFormulario: any;

  constructor(
    private fb: FormBuilder,
    public location: Location,
    private dataApi: ApisService,
    private alertas: SweetalertService,
    private storageFormulario: FormularioStorageService,
    private routerActive: ActivatedRoute,
  ) { }

  ngOnInit(): void {
    this.routerActive.queryParams.subscribe(params => {
      this.idProducto = params['producto']
      if (this.idProducto) {
        this.esNuevo = false
        this.boton = 'Modificar'
        this.getProductoId(this.idProducto)
      } else {
        this.esNuevo = true
        this.boton = 'Crear'
        this.persitenciaDatos();
      }
    })
  }

  getProductoId(id: number) {
    this.dataApi.getProductoById(id).subscribe(producto => {
      console.log(producto.result);
      this.formularioProducto.patchValue(producto.result);
    })
  }

  transformInputToUppercase(event: Event) {
    const target = event.target as HTMLInputElement;
    target.value = target.value.toUpperCase();
    this.formularioProducto.get(target.name)?.setValue(target.value);
  }
  persitenciaDatos() {
    this.dataFormulario = this.formularioProducto.value;
    this.formularioProducto.valueChanges.subscribe((formData) => {
      if (JSON.stringify(formData) !== JSON.stringify(this.dataFormulario)) {
        this.storageFormulario.guardarFormDatos(this.formId, formData);
      }
    });
    const savedData = this.storageFormulario.getDatosForm(this.formId);
    if (savedData) {
      this.formularioProducto.patchValue(savedData);
      this.dataFormulario = savedData;
    }
  }

  onFileSelected(event: any) {
    const file: File = event.target.files[0];
    if (file) {
      const reader = new FileReader();
      reader.onload = (e: any) => {
        console.log(e);
        this.imageSelected = e.target.result;
        this.formularioProducto.controls.imagen.setValue(e.target.result)
      };
      reader.readAsDataURL(file);
    }
  }
  ZoomImagen() {
    this.isModalOpen = true;
  }
  closeModal() {
    this.isModalOpen = false;
  }
  crearProducto() {
    if (this.esNuevo) {
      this.dataApi.crearProducto(this.formularioProducto.value).subscribe(res => {
        this.alertas.dinamicConfirmDialog('Desea crear otro Producto ?')
          .then((result) => {
            if (result.isConfirmed) {
              this.formularioProducto.reset();
            } else {
              this.location.back();
            }
          })
      }, error => {
        this.alertas.alertaError('Hubo un error al crear el Producto')
      })
    } else {
      this.alertas.dinamicConfirmDialog('Esta seguro que desea modificar el Producto?')
        .then((result) => {
          if (result.isConfirmed) {
            this.dataApi.modificarProducto(this.idProducto, this.formularioProducto.value).subscribe(res => {
              this.location.back()
            }, error => {
              this.alertas.alertaError('Hubo un error al modificar el Producto')
            })
          }
        })
    }
  }
  salir() {
    this.location.back()
    this.storageFormulario.eliminarDatosForm(this.formId)
  }
}
