using System;
using System.Collections.Generic;
using Common;

namespace Common.Domain.Models
{
    public partial class EmpresaDto : ICompanyEntity
    { 
        public int IdEmpresa { get; set; }
        public string Ruc { get; set; }
        public string RazonSocial { get; set; }
        public string NombreComercial { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public Guid Token { get; set; } 

        public int IdProvincia { get; set; }
        public int IdCanton { get; set; }
                                   
    }
}
