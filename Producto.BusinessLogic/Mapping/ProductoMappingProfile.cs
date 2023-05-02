using AutoMapper;
using DataAccess.Models;
using Inventario.Domain.Models;
using Producto.Domain.Models;
using Producto.Domain.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Producto.BusinessLogic.Mapping
{
    public class ProductoMappingProfile: Profile
    {
        public ProductoMappingProfile()
        {
            MapProductos();
        }

        private void MapProductos()
        {
            #region DTO to Entity
            CreateMap<Dp03a110, ProductoDto>()
               .ReverseMap();

            CreateMap<Dp03acom, TipoComprobanteDto>()
                .ReverseMap();
            #endregion

            #region Request To Entity
            CreateMap<Dp03a110, ProductoRequest>()
                .ReverseMap();
            #endregion
        }
    }
}
