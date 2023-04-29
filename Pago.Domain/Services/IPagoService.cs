using Common;
using Pago.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pago.Domain.Services
{
    public interface IPagoService
    {
        Task<IOperationResultList<MetodoPagoDto>> ConsultarMetodos(IOperationRequest request, int page = 1, int? pageSize = default);
        Task<IOperationResultList<TipoPagoDto>> Consultartipos(IOperationRequest request, int page = 1, int? pageSize = default);
    }
}
