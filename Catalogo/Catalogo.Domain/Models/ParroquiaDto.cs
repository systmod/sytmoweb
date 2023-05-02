using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogos.Domain.Models
{
    public class ParroquiaDto
    {
        public int Id { get; set; }
        public int IdCiudad { get; set; }
        public string Parroquia { get; set; }
        public decimal? Longitud { get; set; }
        public decimal? Latitud { get; set; }
    }
}
