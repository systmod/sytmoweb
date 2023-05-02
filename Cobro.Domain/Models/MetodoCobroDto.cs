using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobro.Domain.Models
{
    public class MetodoCobroDto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string NombreCorto { get; set; }
        public string Entidad { get; set; }
        public bool? Numero { get; set; }
        public bool? CodigoBanco { get; set; }
        public bool? CuentaBanco { get; set; }
        public bool? PuntoVenta { get; set; }
        public string Cuenta { get; set; }
        public bool? Tarjeta { get; set; }
        public bool? GeneraNd { get; set; }
        public string TipoNd { get; set; }
        public bool? GeneraNc { get; set; }
        public string TipoNc { get; set; }
    }
}
