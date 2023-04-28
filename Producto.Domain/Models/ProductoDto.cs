using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Producto.Domain.Models
{
    public class ProductoDto
    {
        public long Id { get; set; }
        public string Codigo { get; set; }
        public string CodigoInterno { get; set; }
        public string CodigoBarra { get; set; }
        public string Cuenta { get; set; }
        public string Cuenta2 { get; set; }
        public string Cuenta3 { get; set; }
        public string Nombre { get; set; }
        public string Presentacion { get; set; }
        public string Aplica { get; set; }
        public string Tipo { get; set; }
        public string Modelo { get; set; }
        public string Clase { get; set; }
        public string SubClase { get; set; }
        public string Origen { get; set; }
        public string Marca { get; set; }
        public string Unidad { get; set; }
        public decimal Factor { get; set; }
        public string Ubica { get; set; }
        public string ValidaStock { get; set; }
        public string IvaSn { get; set; }
        public decimal? ValorUltimaCompra { get; set; }
        public DateTime? FechaUltimaCompra { get; set; }
        public decimal? ValorUltimaVenta { get; set; }
        public DateTime? FechaUltimaVenta { get; set; }
        public decimal? PvpA { get; set; }
        public decimal? PvpB { get; set; }
        public decimal? PvpC { get; set; }
        public decimal? PvpD { get; set; }
        public decimal? PvpE { get; set; }
        public string Imagen { get; set; }
        public bool ModificaPrecio { get; set; }
        public bool ModificaDescripcion { get; set; }
        public decimal? PorcentajeDescuento { get; set; }
        public string Comentario { get; set; }
        public string Color { get; set; }
        public string Talla { get; set; }
        public bool? PideSerie { get; set; }
    }
}
