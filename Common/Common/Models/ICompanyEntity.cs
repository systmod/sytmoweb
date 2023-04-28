using System;

namespace Common
{
    public interface ICompanyEntity
    {
        int IdEmpresa { get; set; }
        string Ruc { get; set; }
        string RazonSocial { get; set; }
        string NombreComercial { get; set; }
        string Direccion { get; set; }
        string Telefono { get; set; }
        string Correo { get; set; }
        Guid Token { get; set; }

        int IdProvincia { get; set; }
        int IdCanton { get; set; }
                          
    }
}
