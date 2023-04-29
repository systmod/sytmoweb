using AutoMapper;
using Cobro.Domain.Models;
using Cobro.Domain.Request;
using DataAccess.Models;

namespace Producto.BusinessLogic.Mapping
{
    public class CobroMappingProfile: Profile
    {
        public CobroMappingProfile()
        {
            MapCobros();
        }

        private void MapCobros()
        {
            #region DTO to Entity
            CreateMap<Dp05a120, MetodoCobroDto>()
               .ReverseMap();
            CreateMap<Dp05a130, TipoCobroDto>()
                .ReverseMap();
            #endregion

            #region Request To Entity
            CreateMap<Dp05acab, CobroRequest>()
                .ReverseMap();
            #endregion
        }
    }
}
