import { Location } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Pais, Provincia, Ciudad, Parroquia } from 'src/app/core/core.index';
import { ApisService } from 'src/app/core/service/data/apis.service';
import { FormularioStorageService } from 'src/app/core/service/data/formulario-storage.service';
import { SweetalertService } from 'src/app/shared/sweetalert/sweetalert.service';

@Component({
  selector: 'app-editarproveedor',
  templateUrl: './editarproveedor.component.html',
  styleUrls: ['./editarproveedor.component.scss']
})
export class EditarproveedorComponent {
  formularioProveedor = this.fb.group({
    codigo: '',
    cuentaCliente: '',
    cuentaProveedor: '',
    razonSocial: '',
    nombreComercial: '',
    tipoPrecio: '',
    ruc: '',
    telefono1: '',
    telefono2: '',
    diasCredito: 0,
    porcentajeDescuento: 0,
    comenta: '',
    credito: 0,
    pais: '',
    idPais: 0,
    provincia: '',
    idProvincia: 0,
    ciudad: '',
    idCiudad: 0,
    parroquia: '',
    idParroquia: 0,
    fechaNacimiento: new Date(),
    sexo: '',
    titulo: '',
    profesion: '',
    email: '',
    esContribuyente: '',
    estadoCivil: '',
    representanteLegal: '',
    representanteCedula: '',
    representanteTelefono: '',
    esCliente: false,
    esProveedor: true,
    vendedor: ''
  });

  pais: Pais[] = [];
  provincia: Provincia[] = [];
  ciudad: Ciudad[] = [];
  parroquia: Parroquia[] = [];


  formId = 'FormProv';
  boton = 'Crear'
  idCliente?: number;

  dataFormulario: any;

  esNuevo: boolean = true


  constructor(
    private fb: FormBuilder,
    public location: Location,
    private dataApi: ApisService,
    private alertas: SweetalertService,
    private storageFormulario: FormularioStorageService,
    private routerActive: ActivatedRoute,
  ) { }

  ngOnInit(): void {
    this.cargarDatosIniciales();
    this.routerActive.queryParams.subscribe(params => {
      this.idCliente = params['proveedor']
      if (this.idCliente) {
        this.esNuevo = false
        this.boton = 'Modificar'
        this.getClienteId(this.idCliente)
      } else {
        this.esNuevo = true
        this.boton = 'Crear'
        this.persitenciaDatos();
      }
    })

  }
  cargarDatosIniciales() {
    this.dataApi.getPais().subscribe(pais => {
      this.pais = pais.result
    })
  }
  transformInputToUppercase(event: Event) {
    const target = event.target as HTMLInputElement;
    target.value = target.value.toUpperCase();
    this.formularioProveedor.get(target.name)?.setValue(target.value);
  }

  seleccioner(datos: any, tipo: number) {
    switch (tipo) {
      case 1:
        this.formularioProveedor.get('idPais')?.setValue(datos.id)
        this.provincia = []
        this.dataApi.getProvincia(datos.id).subscribe(res => {
          this.provincia = res.result
        })
        break;
      case 2:
        this.formularioProveedor.get('idProvincia')?.setValue(datos.id)
        this.ciudad = []
        this.dataApi.getCiudad(datos.id).subscribe(res => {
          this.ciudad = res.result
        })
        break;
      case 3:
        this.formularioProveedor.get('idCiudad')?.setValue(datos.id)
        this.parroquia = []
        this.dataApi.getParroquia(datos.id).subscribe(res => {
          this.parroquia = res.result
        })
        break;
      case 4:
        this.formularioProveedor.get('idParroquia')?.setValue(datos.id)
        break;

      default:
        break;
    }
  }
  crearCliente() {
    if (this.esNuevo) {
      this.dataApi.crearCliente(this.formularioProveedor.value).subscribe(res => {
        this.alertas.dinamicConfirmDialog('Desea crear otor proveedor?')
          .then((result) => {
            if (result.isConfirmed) {
              this.formularioProveedor.reset();
            } else {
              this.location.back();
            }
          })
      }, error => {
        this.alertas.alertaError('Hubo un error al crear al cliente')
      })
    } else {
      this.alertas.dinamicConfirmDialog('Esta seguro que desea modificar la entidad?')
        .then((result) => {
          if (result.isConfirmed) {
            this.dataApi.modificarCliente(this.idCliente, this.formularioProveedor.value).subscribe(res => {
              this.location.back()
            }, error => {
              this.alertas.alertaError('Hubo un error al modificar al cliente')
            })
          }
        })
      console.log(this.formularioProveedor.value);

    }
  }
  getClienteId(id: number) {
    this.dataApi.getEntidadById(id).subscribe(cliente => {
      console.log(cliente.result);
      this.formularioProveedor.patchValue(cliente.result);
    })
  }

  persitenciaDatos() {
    this.dataFormulario = this.formularioProveedor.value;
    this.formularioProveedor.valueChanges.subscribe((formData) => {
      if (JSON.stringify(formData) !== JSON.stringify(this.dataFormulario)) {
        this.storageFormulario.guardarFormDatos(this.formId, formData);
      }
    });
    const savedData = this.storageFormulario.getDatosForm(this.formId);
    if (savedData) {
      this.formularioProveedor.patchValue(savedData);
      this.dataFormulario = savedData;
    }
  }
  salir() {
    this.location.back()
    this.storageFormulario.eliminarDatosForm(this.formId)
  }
}
