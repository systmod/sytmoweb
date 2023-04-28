using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad.Domain.Models
{
    public class EntidadDto
    {
        public long Id { get; set; }
        public string Codigo { get; set; }
        public string CuentaCliente { get; set; }
        public string CuentaProveedor { get; set; }
        public string RazonSocial { get; set; }
        public string NombreComercial { get; set; }
        public string TipoPrecio { get; set; }
        public string Ruc { get; set; }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        public string Vendedor { get; set; }
        public decimal? DiasCredito { get; set; }
        public DateTime? FechaUltimaVenta { get; set; }
        public decimal? ValorUltimaVenta { get; set; }
        public DateTime? FechaUltimaCompra { get; set; }
        public decimal? ValorUltimaCompra { get; set; }
        public decimal? PorcentajeDescuento { get; set; }
        public string Comenta { get; set; }
        public decimal? Credito { get; set; }
        public short? IdPais { get; set; }
        public string Pais { get; set; }
        public int? IdProvincia { get; set; }
        public string Provincia { get; set; }
        public int? IdCiudad { get; set; }
        public string Ciudad { get; set; }
        public int? IdParroquia { get; set; }
        public string Parroquia { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Sexo { get; set; }
        public string Titulo { get; set; }
        public string Profesion { get; set; }
        public string Email { get; set; }
        public string EsContribuyente { get; set; }
        public string EstadoCivil { get; set; }
        public string RepresentanteLegal { get; set; }
        public string RepresentanteCedula { get; set; }
        public string RepresentanteTelefono { get; set; }
        public bool? EsCliente { get; set; }
        public bool? EsProveedor { get; set; }
        public string Direccion { get; set; }
    }
}
