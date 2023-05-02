using System;
using System.Collections.Generic;

namespace Common.Domain.Models
{
    public class UsuarioDto : IUserEntity
    {
        public UsuarioDto()
        {
            Nombre = "SYSTEM USER";
            Correo = "app@binasystem.com";
            InicioSesion = "SYSTEM";
            Token = $"{Guid.Empty}";
            Roles = Array.Empty<string>();
        }

        public string IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string InicioSesion { get; set; }
        public string Token { get; set; }
        public string Identificacion { get; set; }
        public TokenPermissionEnum Status { get; set; }

        
        public ICollection<string> Roles { get; set; }

        public AplicacionDto Aplicacion { get; set; }
        IApplicationEntity IUserEntity.Aplicacion => this.Aplicacion;

        public EmpresaDto Empresa { get; set; }
        ICompanyEntity IUserEntity.Empresa => this.Empresa;

        public UnidadAdminDto Local { get; set; }
        IAdminUnitEntity IUserEntity.Local => this.Local;
    }
}
