using Common;
using System;

namespace Common.Domain.Models
{
    public class AplicacionDto : IApplicationEntity
    {
        public int IdAplicacion { get; set; }
        public string Nombre { get; set; }
        public TipoAplicacionEnum Tipo { get; set; }
        public Guid Token { get; set; }
        public int IdEstado { get; set; }
        public ProductoDto Producto { get; set; }

        IProductEntity IApplicationEntity.Producto { get => Producto; }
    }

}