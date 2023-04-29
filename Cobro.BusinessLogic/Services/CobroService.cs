using AutoMapper;
using Cobro.Domain.Models;
using Cobro.Domain.Request;
using Cobro.Domain.Services;
using Common;
using DataAccess.Models;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobro.BusinessLogic.Services
{
    public class CobroService: ICobroService
    {
        public readonly IEntityRepository<Dp05a120> _metodo;
        public readonly IEntityRepository<Dp05a130> _tipo;
        public readonly IEntityRepository<Dp05acab> _cobro;
        private readonly IMapper _mapper;
        public CobroService(IEntityRepository<Dp05a120> metodo,
            IEntityRepository<Dp05a130> tipo,
            IEntityRepository<Dp05acab> cobro,
        IMapper mapper)
        {
            _metodo = metodo;
            _mapper = mapper;
            _tipo = tipo;
            _cobro= cobro;
        }

        public async Task<IOperationResultList<MetodoCobroDto>> ConsultarMetodos(IOperationRequest request, int page = 1, int? pageSize = default)
        {
            try
            {
                //Agregar en campo busqueda
                var metodo = _metodo
                    .Search(x => x.IdEmpresa == request.IdEmpresa && x.IdEstado == 1)
                    .AsQueryable();

                return await metodo.ToResultListAsync<Dp05a120, MetodoCobroDto>(page, pageSize);
            }
            catch (Exception ex)
            {
                return new OperationResultList<MetodoCobroDto>(ex);
            }
        }
        public async Task<IOperationResultList<TipoCobroDto>> Consultartipos(IOperationRequest request, int page = 1, int? pageSize = default)
        {
            try
            {
                //Agregar en campo busqueda
                var tipo = _tipo
                    .Search(x => x.IdEmpresa == request.IdEmpresa && x.IdEstado == 1)
                    .AsQueryable();

                return await tipo.ToResultListAsync<Dp05a130, TipoCobroDto>(page, pageSize);
            }
            catch (Exception ex)
            {
                return new OperationResultList<TipoCobroDto>(ex);
            }
        }
        public async Task<IOperationResult<CobroDto>> GuardarCobro(IOperationRequest<CobroRequest> request)
        {
            try
            {
                var cobro = _mapper.Map<Dp05acab>(request.Data);
                cobro.IdEstado = 1;

                await _cobro.InsertAsync(cobro);
                await _cobro.SaveAsync(request);

                var result = _mapper.Map<CobroDto>(cobro);
                return await result.ToResultAsync();

            }
            catch (Exception ex)
            {
                return new OperationResult<CobroDto>(ex);
            }
        }

    }
}
