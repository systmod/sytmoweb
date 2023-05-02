using Common;
using Inventario.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Domain.Services
{
    public interface ITipoComprobanteService
    {
        Task<IOperationResultList<TipoComprobanteDto>> ConsultarTiposByTerm(IOperationRequest request, string? term, int page = 1, int? pageSize = default);
        Task<IOperationResultList<TipoComprobanteDto>> ConsultarTiposByGrupo(IOperationRequest request, string grupo, int page = 1, int? pageSize = default);
        Task<IOperationResult<TipoComprobanteDto>> ObtenerComprobanteById(IOperationRequest request, string codigo);
    }
}
