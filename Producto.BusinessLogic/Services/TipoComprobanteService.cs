using AutoMapper;
using Common;
using DataAccess.Models;
using Inventario.Domain.Models;
using Inventario.Domain.Services;
using Microsoft.EntityFrameworkCore;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.BusinessLogic.Services
{
    public class TipoComprobanteService: ITipoComprobanteService
    {
        public readonly IEntityRepository<Dp03acom> _tipos;
        private readonly IMapper _mapper;
        public TipoComprobanteService(IEntityRepository<Dp03acom> tipos,
            IMapper mapper)
        {
            _tipos = tipos;
            _mapper = mapper;
        }

        public async Task<IOperationResultList<TipoComprobanteDto>> ConsultarTiposByTerm(IOperationRequest request, string? term, int page = 1, int? pageSize = default)
        {
            try
            {
                //Agregar en campo busqueda
                var tipos = _tipos
                    .Search(x => (term == null || EF.Functions.Like(x.Nombre, "%" + term + "%")) && x.IdEmpresa == request.IdEmpresa && x.IdEstado == 1)
                    .AsQueryable();

                return await tipos.ToResultListAsync<Dp03acom, TipoComprobanteDto>(page, pageSize);
            }
            catch (Exception ex)
            {
                return new OperationResultList<TipoComprobanteDto>(ex);
            }
        }

        public async Task<IOperationResultList<TipoComprobanteDto>> ConsultarTiposByGrupo(IOperationRequest request, string grupo, int page = 1, int? pageSize = default)
        {
            try
            {
                //Agregar en campo busqueda
                var tipos = _tipos
                    .Search(x => x.Grupo== grupo && x.IdEmpresa == request.IdEmpresa && x.IdEstado == 1)
                    .AsQueryable();

                return await tipos.ToResultListAsync<Dp03acom, TipoComprobanteDto>(page, pageSize);
            }
            catch (Exception ex)
            {
                return new OperationResultList<TipoComprobanteDto>(ex);
            }
        }

        public async Task<IOperationResult<TipoComprobanteDto>> ObtenerComprobanteById(IOperationRequest request, string codigo)
        {
            try
            {
                var producto = _tipos.Search(x => x.Codigo == codigo && x.IdEstado > 0)
                    .Select(x => _mapper.Map<TipoComprobanteDto>(x))
                    .FirstOrDefault();

                return await producto.ToResultAsync();
            }
            catch (Exception ex)
            {
                return new OperationResult<TipoComprobanteDto>(ex);
            }
        }

    }
}
