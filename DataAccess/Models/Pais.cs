﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Pais
    {
        public Pais()
        {
            Entidad = new HashSet<Entidad>();
            Provincia = new HashSet<Provincia>();
        }

        public short Id { get; set; }
        public string Codigo { get; set; }
        public string Pais1 { get; set; }
        public string Nacionalidad { get; set; }
        public string CodigoNacionalidad { get; set; }
        public string IpIngreso { get; set; }
        public string UsuarioIngreso { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string IpModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public short IdEstado { get; set; }

        public virtual ICollection<Entidad> Entidad { get; set; }
        public virtual ICollection<Provincia> Provincia { get; set; }
    }
}