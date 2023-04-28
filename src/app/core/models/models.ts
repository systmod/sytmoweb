export interface pageSelection {
  skip: number;
  limit: number;
}
export interface apiResultFormat {
  data: Array<any>;
  totalData: number;
}
export interface paginatorResult {
  result?: any;
  error?: boolean;
  message?: string;
  statusCode?: string;
  success?: boolean;
  pageNumber?: number,
  pageSize?: number,
  length?: number,
  totalPages?: number,
  hasPrevious?: boolean,
  hasNext?: boolean,
}
export interface Pais {
  id?: number;
  codigo?: string;
  pais?: string;
  nacionalidad?: string;
  codigoNacionalidad?: string;
}
export interface Provincia {
  id?: number;
  idPais?: number;
  provincia?: string;
  codigo?: string;
}
export interface Ciudad {
  id?: number;
  idProvincia?: number;
  ciudad?: string;
  codigo?: string;
  longitud?: number;
  latitud?: number;
}
export interface Parroquia {
  id?: number;
  idCiudad?: number;
  parroquia?: string;
  longitud?: number;
  latitud?: number;
}

export interface Clientes {
  id?: number;
  codigo?: string;
  cuentaCliente?: string;
  cuentaProveedor?: string;
  razonSocial?: string;
  nombreComercial?: string;
  tipoPrecio?: string;
  ruc?: string;
  telefono1?: string;
  telefono2?: string;
  vendedor?: string;
  diasCredito?: number;
  fechaUltimaVenta?: null;
  valorUltimaVenta?: null;
  fechaUltimaCompra?: null;
  valorUltimaCompra?: null;
  porcentajeDescuento?: number;
  comenta?: string;
  credito?: number;
  idPais?: number;
  idProvincia?: number;
  idCiudad?: number;
  idParroquia?: number;
  fechaNacimiento?: Date;
  sexo?: string;
  titulo?: string;
  profesion?: string;
  email?: string;
  esContribuyente?: string;
  estadoCivil?: string;
  representanteLegal?: string;
  representanteCedula?: string;
  representanteTelefono?: string;
  esCliente?: boolean;
  esProveedor?: null;
}

export interface Producto {
  id?: number;
  codigo?: string;
  codigoInterno?: string;
  codigoBarra?: string;
  cuenta?: string;
  cuenta2?: string;
  cuenta3?: string;
  nombre?: string;
  presentacion?: null;
  aplica?: string;
  tipo?: string;
  modelo?: string;
  clase?: string;
  subClase?: string;
  origen?: string;
  marca?: string;
  unidad?: string;
  factor?: number;
  ubica?: string;
  validaStock?: string;
  ivaSn?: string;
  valorUltimaCompra?: number;
  fechaUltimaCompra?: Date;
  valorUltimaVenta?: null;
  fechaUltimaVenta?: null;
  pvpA?: number;
  pvpB?: number;
  pvpC?: number;
  pvpD?: number;
  pvpE?: number;
  imagen?: string;
  modificaPrecio?: boolean;
  modificaDescripcion?: boolean;
  porcentajeDescuento?: number;
  comentario?: string;
  color?: string;
  talla?: string;
  pideSerie?: boolean;
}
