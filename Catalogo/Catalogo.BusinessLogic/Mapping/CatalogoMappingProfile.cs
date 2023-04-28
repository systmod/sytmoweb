using AutoMapper;
using Catalogos.Domain.Models;
using DataAccess.Models;

namespace Catalogos.Domain.Mapping
{
    public class CatalogoMappingProfile : Profile
    {
        public CatalogoMappingProfile()
        {
            MapCatalogos();
        }

        private void MapCatalogos()
        {
            #region DTO to Entity
            CreateMap<Pais, PaisDto>()
                .ForMember(x => x.Pais, opts => opts.MapFrom(x => x.Pais1))
                .ReverseMap();

            CreateMap<Provincia, ProvinciaDto>()
                .ForMember(x => x.Provincia, opts => opts.MapFrom(x => x.Provincia1))
                .ReverseMap();

            CreateMap<Ciudad, CiudadDto>()
                .ForMember(x => x.Ciudad, opts => opts.MapFrom(x => x.Ciudad1))
                .ReverseMap();

            CreateMap<Parroquia, ParroquiaDto>()
                .ForMember(x => x.Parroquia, opts => opts.MapFrom(x => x.Parroquia1))
                .ReverseMap();

            CreateMap<Alptabla, CatalogoDto>()
                .ReverseMap();
            #endregion

            #region Request To Entity

            #endregion
        }

    }

}
