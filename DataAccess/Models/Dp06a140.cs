﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Dp06a140
    {
        public Dp06a140()
        {
            Dp06acab = new HashSet<Dp06acab>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }
        public string Numero { get; set; }
        public bool Integra { get; set; }
        public string TipoComprobanteContable { get; set; }
        public string CuentaCruce { get; set; }
        public string CuentaIva { get; set; }
        public string CuentaDescuento { get; set; }
        public string IpIngreso { get; set; }
        public string UsuarioIngreso { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string IpModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public short IdEstado { get; set; }
        public int IdEmpresa { get; set; }

        public virtual ICollection<Dp06acab> Dp06acab { get; set; }
    }
}