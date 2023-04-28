using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogos.Domain.Models
{
    public class ProvinciaDto
    {
        public int Id { get; set; }
        public short IdPais { get; set; }
        public string Provincia { get; set; }
        public string Codigo { get; set; }
    }
}
