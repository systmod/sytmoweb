using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Domain.Request
{
    public class DetalleVentaRequest
    {
        public long? IdComprobante { get; set; }
        public string Tipo { get; set; }
        public string Numero { get; set; }
        public string TipoT { get; set; }
        public string Presenta { get; set; }
        public decimal? Factor { get; set; }
        public DateTime? Fecha { get; set; }
        public string Touch { get; set; }
        public long IdProducto { get; set; }
        public string Consumo { get; set; }
        public string Bodega { get; set; }
        public decimal? Cantidad { get; set; }
        public decimal? Despacho { get; set; }
        public decimal? PrecioU { get; set; }
        public decimal? PrecioT { get; set; }
        public decimal? CostoU { get; set; }
        public decimal? CostoT { get; set; }
        public decimal? PorcentajeIva { get; set; }
        public decimal? ValorIva { get; set; }
        public decimal? PorcentajeDescuento { get; set; }
        public decimal? ValorDescuento { get; set; }
        public decimal? PrecioNeto { get; set; }
        public string Servicio { get; set; }
        public decimal? DescuentoItem { get; set; }
        public string TipoPrecio { get; set; }
        public string Serie { get; set; }
        public bool? Devolucion { get; set; }
        public decimal? CantidadDevuelta { get; set; }
        public string CentroCosto { get; set; }
        public string Lote { get; set; }
    }
}
