using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogos.Domain.Models
{
    public class PaisDto
    {
        public short Id { get; set; }
        public string Codigo { get; set; }
        public string Pais { get; set; }
        public string Nacionalidad { get; set; }
        public string CodigoNacionalidad { get; set; }
    }
}
