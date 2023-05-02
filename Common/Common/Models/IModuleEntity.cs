using System.Collections.Generic;

namespace Common
{
    public interface IModuleEntity
    {
        string Codigo { get; }
        string Descripcion { get; }
        string Icono { get; }
        string Nombre { get; }
        ICollection<IOptionEntity> Opciones { get; }
    }
}