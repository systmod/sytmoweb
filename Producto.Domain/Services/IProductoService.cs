using Common;
using Producto.Domain.Models;
using Producto.Domain.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Producto.Domain.Services
{
    public interface IProductoService
    {
        Task<IOperationResult<ProductoDto>> GuardarProducto(IOperationRequest<ProductoRequest> request);
        Task<IOperationResult<ProductoDto>> ObtenerProductoById(IOperationRequest request, int id);
        Task<IOperationResult<ProductoDto>> ModificarProducto(IOperationRequest<ProductoRequest> request, int id);
        Task<IOperationResult> BorrarProducto(IOperationRequest request, int id);
        Task<IOperationResultList<ProductoDto>> ConsultarProductos(IOperationRequest request, string? term, int page = 1, int? pageSize = default);
    }
}
