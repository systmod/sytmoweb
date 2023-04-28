import { Injectable } from '@angular/core';
import Swal from 'sweetalert2';

@Injectable({
  providedIn: 'root'
})
export class SweetalertService {

  confirmDialog = Swal;
  Toast = Swal.mixin({
    toast: true,
    position: 'top-end',
    showConfirmButton: false,
    timer: 3000,
    timerProgressBar: true,
    didOpen: (toast) => {
      toast.addEventListener('mouseenter', Swal.stopTimer)
      toast.addEventListener('mouseleave', Swal.resumeTimer)
    }
  })


  constructor() { }

  ngOnInit(): void {
  }
  public dinamicToast(icono?: any, backgroundColor?: string, titulo?: string) {
    this.Toast.fire({
      icon: icono,
      background: backgroundColor,
      title: titulo,
      color: '#fff'
    })
  }
  public dinamicConfirmDialog(titulo?: string, icono?: any, titloCancelar?: string, tituloConfirmar?: string, subtitle?: string, mostrarConfirmar = true, mostrarCancelar = true) {
    var confirm = this.confirmDialog.fire({
      title: titulo,
      icon: icono || 'warning',
      text: subtitle,
      showCancelButton: mostrarCancelar,
      showConfirmButton: mostrarConfirmar,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      cancelButtonText: titloCancelar || 'NO',
      confirmButtonText: tituloConfirmar || 'Si',

    })
    return confirm;
  }
  public alertaError(titulo: string) {
    this.Toast.fire({
      icon: 'error',
      background: '#d33',
      title: titulo,
      color: '#fff'
    })
  }
  public alertaSuccess(titulo: string) {
    this.Toast.fire({
      icon: 'success',
      background: '#458f47',
      title: titulo,
      color: '#fff'
    })
  }
  public alertaWarnig(titulo: string) {
    this.Toast.fire({
      icon: 'warning',
      background: '#ffcc00',
      title: titulo,
      color: '#fff'
    })
  }

  deleteBtn() {
    // const swalWithBootstrapButtons = Swal.mixin({
    //   customClass: {
    //     confirmButton: 'btn btn-success',
    //     cancelButton: 'me-2 btn btn-danger'
    //   },
    //   buttonsStyling: false
    // })

    // swalWithBootstrapButtons.fire({
    //   title: 'Are you sure?',
    //   text: "You won't be able to revert this!",
    //   icon: 'warning',
    //   showCancelButton: true,
    //   confirmButtonText: 'Yes, delete it!',
    //   cancelButtonText: 'No, cancel!',
    //   reverseButtons: true
    // }).then((result) => {
    //   if (result.isConfirmed) {
    //     swalWithBootstrapButtons.fire(
    //       'Deleted!',
    //       'Your file has been deleted.',
    //       'success'
    //     )
    //   } else if (
    //     /* Read more about handling dismissals below */
    //     result.dismiss === Swal.DismissReason.cancel
    //   ) {
    //     swalWithBootstrapButtons.fire(
    //       'Cancelled',
    //       'Your imaginary file is safe :)',
    //       'error'
    //     )
    //   }
    // })
  }
}
