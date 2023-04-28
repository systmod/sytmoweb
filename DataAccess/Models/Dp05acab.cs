﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Dp05acab
    {
        public long Id { get; set; }
        public int IdTipo { get; set; }
        public string Numero { get; set; }
        public DateTime Fecha { get; set; }
        public long IdCliente { get; set; }
        public long? IdFactura { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public int IdTipoPago { get; set; }
        public string NumeroPago { get; set; }
        public decimal? Monto { get; set; }
        public string CodigoBanco { get; set; }
        public string CuentaBanco { get; set; }
        public DateTime? FechaDocumento { get; set; }
        public string Comenta { get; set; }
        public string Cajero { get; set; }
        public string Asiento { get; set; }
        public int? IdCuota { get; set; }
        public string IpIngreso { get; set; }
        public string UsuarioIngreso { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string IpModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public short IdEstado { get; set; }
        public int IdEmpresa { get; set; }

        public virtual Entidad IdClienteNavigation { get; set; }
        public virtual Dpinvcab IdFacturaNavigation { get; set; }
        public virtual Dp05a130 IdTipoNavigation { get; set; }
        public virtual Dp05a120 IdTipoPagoNavigation { get; set; }
    }
}