using Cobro.Domain.Models;
using Cobro.Domain.Request;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobro.Domain.Services
{
    public interface ICobroService
    {
        Task<IOperationResultList<MetodoCobroDto>> ConsultarMetodos(IOperationRequest request, int page = 1, int? pageSize = default);
        Task<IOperationResultList<TipoCobroDto>> Consultartipos(IOperationRequest request, int page = 1, int? pageSize = default);
        Task<IOperationResult<CobroDto>> GuardarCobro(IOperationRequest<CobroRequest> request);
    }
}
