using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobro.Domain.Models
{
    public class TipoCobroDto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }
        public string Numero { get; set; }
        public bool? Integra { get; set; }
        public string TipoComprobanteContable { get; set; }
        public bool? GeneraNc { get; set; }
        public string TipoCredito { get; set; }
        public string CuentaDescuento { get; set; }
        public string CuentaIva { get; set; }
    }
}
