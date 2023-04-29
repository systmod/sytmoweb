using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Domain.Models
{
    public class TipoComprobanteDto
    {
        public string Codigo { get; set; }
        public string CodigoI { get; set; }
        public string CodigoE { get; set; }
        public string Nombre { get; set; }
        public string Main { get; set; }
        public string Tipo { get; set; }
        public string PideCosto { get; set; }
        public string Inventario { get; set; }
        public string Numero { get; set; }
        public string Forma { get; set; }
        public string Grupo { get; set; }
        public string Iva { get; set; }
        public string Items { get; set; }
        public string OcultaIva { get; set; }
        public string PermiteDescuento { get; set; }
        public bool? Integra { get; set; }
        public string TipoComprobanteContable { get; set; }
        public bool? GeneraNc { get; set; }
        public string TipoCredito { get; set; }
        public string TipoAplica { get; set; }
        public string PuntoVenta { get; set; }
        public string TipoRetencion { get; set; }
        public string Serie { get; set; }
    }

    public static class GrupoComprobante
    {
        public const string
            Compra = "C",
            Venta = "V";
    }
}
