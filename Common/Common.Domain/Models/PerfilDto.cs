using System.Collections.Generic;
using System.Linq;

namespace Common.Domain.Models
{

    public class PerfilDto : IProfileEntity
    {

        public int IdPerfil { get; set; }
        public string Descripcion { get; set; }

        public ICollection<IModuleEntity> Permisos { get; set; }
    }

    public class OpcionDto : IOptionEntity
    {
        public int IdOpcion { get; set; }

        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Accion { get; set; }
        public string Icono { get; set; }
        public int Orden { get; set; }
        public string Operaciones { get; set; }
    }

    public class ModuloDto : IModuleEntity
    {
        public int IdModulo { get; set; }

        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Icono { get; set; }

        public ICollection<IOptionEntity> Opciones { get; set; }  

    }
}
