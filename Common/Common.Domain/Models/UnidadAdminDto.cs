using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain.Models
{
    public class UnidadAdminDto : IAdminUnitEntity
    {
        public int IdUnidadAdmin { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }

        public string TipoUnidad { get; set; }

        public Guid Token { get; set; }
    }
}
