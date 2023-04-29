using AutoMapper;
using Cobro.Domain.Models;
using Cobro.Domain.Services;
using Common;
using DataAccess.Models;
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
        private readonly IMapper _mapper;
        public CobroService(IEntityRepository<Dp05a120> metodo,
            IEntityRepository<Dp05a130> tipo,
            IMapper mapper)
        {
            _metodo = metodo;
            _mapper = mapper;
            _tipo = tipo;
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

    }
}
