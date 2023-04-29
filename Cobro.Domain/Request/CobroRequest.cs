using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobro.Domain.Request
{
    public class CobroRequest
    {        
        public int IdTipo { get; set; }
        public string Numero { get; set; }
        public DateTime Fecha { get; set; }
        public long IdCliente { get; set; }
        public long? IdFactura { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public int IdTipoPago { get; set; }
        public string NumeroPago { get; set; }
        public decimal? Monto { get; set; }
        public string CodigoBanco { get; set; }
        public string CuentaBanco { get; set; }
        public DateTime? FechaDocumento { get; set; }
        public string Comenta { get; set; }
        public string Cajero { get; set; }
        public string Asiento { get; set; }
        public int? IdCuota { get; set; }
    }
}
