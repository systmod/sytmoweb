import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Ciudad, DataService, Pais, Parroquia, Provincia } from 'src/app/core/core.index';
import { ApisService } from 'src/app/core/service/data/apis.service';
import { FormularioStorageService } from 'src/app/core/service/data/formulario-storage.service';
import { SweetalertService } from 'src/app/shared/sweetalert/sweetalert.service';

@Component({
  selector: 'app-addcustomer',
  templateUrl: './addcustomer.component.html',
  styleUrls: ['./addcustomer.component.scss']
})
export class AddcustomerComponent implements OnInit {
  formularioCliente = this.fb.group({
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
    esCliente: true,
    esProveedor: false,
    vendedor: ''
  });

  pais: Pais[] = [];
  provincia: Provincia[] = [];
  ciudad: Ciudad[] = [];
  parroquia: Parroquia[] = [];


  formId = 'FormCli';
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
      this.idCliente = params['cliente']
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
    this.formularioCliente.get(target.name)?.setValue(target.value);
  }

  seleccioner(datos: any, tipo: number) {
    switch (tipo) {
      case 1:
        this.formularioCliente.get('idPais')?.setValue(datos.id)
        this.provincia = []
        this.dataApi.getProvincia(datos.id).subscribe(res => {
          this.provincia = res.result
        })
        break;
      case 2:
        this.formularioCliente.get('idProvincia')?.setValue(datos.id)
        this.ciudad = []
        this.dataApi.getCiudad(datos.id).subscribe(res => {
          this.ciudad = res.result
        })
        break;
      case 3:
        this.formularioCliente.get('idCiudad')?.setValue(datos.id)
        this.parroquia = []
        this.dataApi.getParroquia(datos.id).subscribe(res => {
          this.parroquia = res.result
        })
        break;
      case 4:
        this.formularioCliente.get('idParroquia')?.setValue(datos.id)
        break;

      default:
        break;
    }
  }
  crearCliente() {
    if (this.esNuevo) {
      this.dataApi.crearCliente(this.formularioCliente.value).subscribe(res => {
        this.alertas.dinamicConfirmDialog('Desea crear otro cliente?')
          .then((result) => {
            if (result.isConfirmed) {
              this.formularioCliente.reset();
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
            this.dataApi.modificarCliente(this.idCliente, this.formularioCliente.value).subscribe(res => {
              this.location.back()
            }, error => {
              this.alertas.alertaError('Hubo un error al modificar al cliente')
            })
          }
        })
      console.log(this.formularioCliente.value);

    }
  }
  getClienteId(id: number) {
    this.dataApi.getEntidadById(id).subscribe(cliente => {
      console.log(cliente.result);
      this.formularioCliente.patchValue(cliente.result);
    })
  }

  persitenciaDatos() {
    this.dataFormulario = this.formularioCliente.value;
    this.formularioCliente.valueChanges.subscribe((formData) => {
      if (JSON.stringify(formData) !== JSON.stringify(this.dataFormulario)) {
        this.storageFormulario.guardarFormDatos(this.formId, formData);
      }
    });
    const savedData = this.storageFormulario.getDatosForm(this.formId);
    if (savedData) {
      this.formularioCliente.patchValue(savedData);
      this.dataFormulario = savedData;
    }
  }
  salir() {
    this.location.back()
    this.storageFormulario.eliminarDatosForm(this.formId)
  }
}
