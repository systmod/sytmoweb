using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pago.Domain.Models
{
    public class MetodoPagoDto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Entidad { get; set; }
        public bool Numero { get; set; }
        public decimal UltimoNumero { get; set; }
        public bool CodigoBanco { get; set; }
        public bool CuentaBanco { get; set; }
        public string CuentaContable { get; set; }
    }
}
