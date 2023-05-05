using Common;
using Inventario.Domain.Models;
using Inventario.Domain.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Domain.Services
{
    public interface ITransaccionService
    {
        Task<IOperationResult<VentaDto>> GuardarFactura(IOperationRequest<VentaRequest> request);
    }
}
