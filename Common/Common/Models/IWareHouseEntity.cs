using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public interface IWareHouseEntity
    {
        public int IdSucursal { get; set; }
        public int IdEmpresa { get; set; }
        public bool Matriz { get; set; }
        public int IdProvincia { get; set; }
        public int IdCiudad { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }  
    }
}
