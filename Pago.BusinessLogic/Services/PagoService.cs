using AutoMapper;
using Common;
using DataAccess.Models;
using Pago.Domain.Models;
using Pago.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pago.BusinessLogic.Services
{
    public class PagoService: IPagoService
    {
        public readonly IEntityRepository<Dp06a150> _metodo;
        public readonly IEntityRepository<Dp06a140> _tipo;
        public readonly IEntityRepository<Dp06acab> _pago;
        private readonly IMapper _mapper;
        public PagoService(IEntityRepository<Dp06a150> metodo,
            IEntityRepository<Dp06a140> tipo,
            IEntityRepository<Dp06acab> pago,
        IMapper mapper)
        {
            _metodo = metodo;
            _mapper = mapper;
            _tipo = tipo;
            _pago = pago;
        }

        public async Task<IOperationResultList<MetodoPagoDto>> ConsultarMetodos(IOperationRequest request, int page = 1, int? pageSize = default)
        {
            try
            {
                //Agregar en campo busqueda
                var metodo = _metodo
                    .Search(x => x.IdEmpresa == request.IdEmpresa && x.IdEstado == 1)
                    .AsQueryable();

                return await metodo.ToResultListAsync<Dp06a150, MetodoPagoDto>(page, pageSize);
            }
            catch (Exception ex)
            {
                return new OperationResultList<MetodoPagoDto>(ex);
            }
        }
        public async Task<IOperationResultList<TipoPagoDto>> Consultartipos(IOperationRequest request, int page = 1, int? pageSize = default)
        {
            try
            {
                //Agregar en campo busqueda
                var tipo = _tipo
                    .Search(x => x.IdEmpresa == request.IdEmpresa && x.IdEstado == 1)
                    .AsQueryable();

                return await tipo.ToResultListAsync<Dp06a140, TipoPagoDto>(page, pageSize);
            }
            catch (Exception ex)
            {
                return new OperationResultList<TipoPagoDto>(ex);
            }
        }

    }
}
