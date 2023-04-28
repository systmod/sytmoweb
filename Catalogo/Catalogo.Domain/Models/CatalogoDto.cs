using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogos.Domain.Models
{
    public class CatalogoDto
    {
        public int Id { get; set; }
        public string Master { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public decimal? Valor { get; set; }
        public string Nomtag { get; set; }
        public string Gestion { get; set; }
        public bool Pideval { get; set; }
        public string Campo1 { get; set; }
        public string Grupo { get; set; }
        public string Sgrupo { get; set; }
        public string Campo2 { get; set; }
        public decimal Lencod { get; set; }
        public decimal? Valor2 { get; set; }
    }
}
