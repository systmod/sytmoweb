using AutoMapper;
using Entidad.Domain.Models;
using Entidad.Domain.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad.BusinessLogic.Mapping
{
    public class EntidadMappingProfile: Profile
    {
        public EntidadMappingProfile()
        {
            MapCatalogos();
        }

        private void MapCatalogos()
        {
            #region DTO to Entity
            CreateMap<DataAccess.Models.Entidad, EntidadDto>()
                .ForMember(x => x.Pais, opt => opt.MapFrom(x => x.IdPaisNavigation.Pais1))
                .ForMember(x => x.Provincia, opt => opt.MapFrom(x => x.IdProvinciaNavigation.Provincia1))
                .ForMember(x => x.Ciudad, opt => opt.MapFrom(x => x.IdCiudadNavigation.Ciudad1))
                .ForMember(x => x.Parroquia, opt => opt.MapFrom(x => x.IdParroquiaNavigation.Parroquia1))
                .ReverseMap();
            #endregion

            #region Request To Entity
            CreateMap<DataAccess.Models.Entidad, EntidadRequest>()
                .ReverseMap();
            #endregion
        }
    }
}
