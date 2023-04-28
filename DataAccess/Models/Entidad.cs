﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Entidad
    {
        public Entidad()
        {
            Dp05acab = new HashSet<Dp05acab>();
            Dpinvcab = new HashSet<Dpinvcab>();
        }

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
        public int? IdProvincia { get; set; }
        public int? IdCiudad { get; set; }
        public int? IdParroquia { get; set; }
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
        public string IpIngreso { get; set; }
        public string UsuarioIngreso { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string IpModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public short IdEstado { get; set; }
        public int IdEmpresa { get; set; }

        public virtual Ciudad IdCiudadNavigation { get; set; }
        public virtual Pais IdPaisNavigation { get; set; }
        public virtual Parroquia IdParroquiaNavigation { get; set; }
        public virtual Provincia IdProvinciaNavigation { get; set; }
        public virtual ICollection<Dp05acab> Dp05acab { get; set; }
        public virtual ICollection<Dpinvcab> Dpinvcab { get; set; }
    }
}