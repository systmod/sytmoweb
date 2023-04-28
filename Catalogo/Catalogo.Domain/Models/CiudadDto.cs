using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogos.Domain.Models
{
    public class CiudadDto
    {
        public int Id { get; set; }
        public int IdProvincia { get; set; }
        public string Ciudad { get; set; }
        public string Codigo { get; set; }
        public decimal? Longitud { get; set; }
        public decimal? Latitud { get; set; }
    }
}
