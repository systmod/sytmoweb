using AutoMapper;
using DataAccess.Models;
using Pago.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Pago.BusinessLogic.Mapping
{
    public class PagoMappingProfile : Profile
    {
        public PagoMappingProfile()
        {
            MapPagos();
        }
        private void MapPagos()
        {
            #region DTO to Entity
            CreateMap<Dp06a150, MetodoPagoDto>()
               .ReverseMap();
            CreateMap<Dp06a140, TipoPagoDto>()
                .ReverseMap();
            #endregion

            #region Request To Entity
            //CreateMap<Dp06acab, CobroRequest>()
            //    .ReverseMap();
            #endregion
        }
    }
}
