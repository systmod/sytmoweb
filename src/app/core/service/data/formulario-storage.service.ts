import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class FormularioStorageService {
  private readonly FORM_DATA_KEY = 'formData';

  guardarFormDatos(formId: string, formData: any): void {
    localStorage.setItem(`${this.FORM_DATA_KEY}_${formId}`, JSON.stringify(formData));
  }

  getDatosForm(formId: string): any {
    const data = localStorage.getItem(`${this.FORM_DATA_KEY}_${formId}`);
    return data ? JSON.parse(data) : null;
  }

  eliminarDatosForm(formId: string): void {
    localStorage.removeItem(`${this.FORM_DATA_KEY}_${formId}`);
  }
}
