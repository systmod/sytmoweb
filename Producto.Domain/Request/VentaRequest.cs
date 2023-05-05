using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Domain.Request
{
    public class VentaRequest
    {
        public string Tipo { get; set; }
        public string Numero { get; set; }
        public string NumeroB { get; set; }
        public string Referencia { get; set; }
        public string Grupo { get; set; }
        public string TipoT { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public string BodegaDestino { get; set; }
        public string Bodega { get; set; }
        public long? IdEntidad { get; set; }
        public string Vendedor { get; set; }
        public string TipoPrecio { get; set; }
        public decimal? Subtotal { get; set; }
        public decimal? PorcentajeDescuento { get; set; }
        public decimal? TotalDescuento { get; set; }
        public decimal? PorcentajeIva { get; set; }
        public decimal? TotalIva { get; set; }
        public decimal? Total { get; set; }
        public string Comentario { get; set; }
        public string FacturaProveedor { get; set; }
        public string CodigoIngreso { get; set; }
        public string CodigoEgreso { get; set; }
        public string Asiento { get; set; }
        public string GuiaRemision { get; set; }
        public decimal? Base0 { get; set; }
        public decimal? BaseIva { get; set; }
        public string OrdenCompra { get; set; }
        public List<DetalleVentaRequest> Detalle { get; set; }
    }
}
