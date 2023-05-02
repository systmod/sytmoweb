using Common;
using Entidad.Domain.Models;
using Entidad.Domain.Request;

namespace Entidad.Domain.Services
{
    public interface IEntidadService
    {
        Task<IOperationResult<EntidadDto>> GuardarEntidad(IOperationRequest<EntidadRequest> request);
        Task<IOperationResult<EntidadDto>> ObtenerEntidadById(IOperationRequest request, int id);
        Task<IOperationResult<EntidadDto>> ModificarEntidad(IOperationRequest<EntidadRequest> request, int id);
        Task<IOperationResult> BorrarEntidad(IOperationRequest request, int id);
        Task<IOperationResultList<EntidadDto>> ConsultarClientes(IOperationRequest request, string? term, int page = 1, int? pageSize = default);
        Task<IOperationResultList<EntidadDto>> ConsultarProveedores(IOperationRequest request, string? term, int page = 1, int? pageSize = default);
    }
}
