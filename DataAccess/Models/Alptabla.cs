﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Alptabla
    {
        public int Id { get; set; }
        public string Master { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public decimal? Valor { get; set; }
        public string Nomtag { get; set; }
        public string Gestion { get; set; }
        public bool Pideval { get; set; }
        public string Campo1 { get; set; }
        public string Grupo { get; set; }
        public string Sgrupo { get; set; }
        public string Campo2 { get; set; }
        public decimal Lencod { get; set; }
        public decimal? Valor2 { get; set; }
        public string IpIngreso { get; set; }
        public string UsuarioIngreso { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string IpModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public short IdEstado { get; set; }
        public int IdEmpresa { get; set; }
    }
}