using System.Collections.Generic;

namespace Common 
{
    public interface IProfileEntity
    {
        string Descripcion { get; set; }
        int IdPerfil { get; set; }
        ICollection<IModuleEntity> Permisos { get; set; }
    }
}
