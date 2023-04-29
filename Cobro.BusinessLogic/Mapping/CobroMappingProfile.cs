using AutoMapper;
using Cobro.Domain.Models;
using DataAccess.Models;

namespace Producto.BusinessLogic.Mapping
{
    public class CobroMappingProfile: Profile
    {
        public CobroMappingProfile()
        {
            MapProductos();
        }

        private void MapProductos()
        {
            #region DTO to Entity
            CreateMap<Dp05a120, MetodoCobroDto>()
               .ReverseMap();
            CreateMap<Dp05a130, TipoCobroDto>()
                .ReverseMap();
            #endregion

            #region Request To Entity
            //CreateMap<Dp03a110, ProductoRequest>()
            //    .ReverseMap();
            #endregion
        }
    }
}
