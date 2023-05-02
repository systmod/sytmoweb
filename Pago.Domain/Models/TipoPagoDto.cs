using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pago.Domain.Models
{
    public class TipoPagoDto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }
        public string Numero { get; set; }
        public bool Integra { get; set; }
        public string TipoComprobanteContable { get; set; }
        public string CuentaCruce { get; set; }
        public string CuentaIva { get; set; }
        public string CuentaDescuento { get; set; }
    }
}
