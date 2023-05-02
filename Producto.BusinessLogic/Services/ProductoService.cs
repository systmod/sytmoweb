using AutoMapper;
using Common;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Producto.Domain.Models;
using Producto.Domain.Request;
using Producto.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Producto.BusinessLogic.Services
{
    public class ProductoService: IProductoService
    {
        public readonly IEntityRepository<Dp03a110> _producto;
        private readonly IMapper _mapper;
        public ProductoService(IEntityRepository<Dp03a110> producto,
            IMapper mapper)
        {
            _producto = producto;
            _mapper = mapper;
        }

        public async Task<IOperationResult<ProductoDto>> GuardarProducto(IOperationRequest<ProductoRequest> request)
        {
            try
            {
                var producto = _mapper.Map<Dp03a110>(request.Data);
                producto.IdEstado = 1;

                await _producto.InsertAsync(producto);
                await _producto.SaveAsync(request);

                var result = _mapper.Map<ProductoDto>(producto);
                return await result.ToResultAsync();

            }
            catch (Exception ex)
            {
                return new OperationResult<ProductoDto>(ex);
            }
        }

        public async Task<IOperationResult<ProductoDto>> ObtenerProductoById(IOperationRequest request, int id)
        {
            try
            {
                var producto = _producto.Search(x => x.Id == id && x.IdEstado > 0)
                    .Select(x => _mapper.Map<ProductoDto>(x))
                    .FirstOrDefault();

                return await producto.ToResultAsync();
            }
            catch (Exception ex)
            {
                return new OperationResult<ProductoDto>(ex);
            }
        }

        public async Task<IOperationResult<ProductoDto>> ModificarProducto(IOperationRequest<ProductoRequest> request, int id)
        {
            try
            {
                var producto = _producto.Search(x => x.IdEmpresa == request.IdEmpresa && x.Id == id)
                            .FirstOrDefault();

                if (producto != null)
                {
                    producto = _mapper.Map<Dp03a110>(producto, request.Data);

                    await _producto.UpdateAsync(producto);
                    await _producto.SaveAsync(request);

                    var res = _mapper.Map<ProductoDto>(producto);
                    return await res.ToResultAsync();
                }
                else
                {
                    return new OperationResult<ProductoDto>(HttpStatusCode.NotFound, "ID de producto seleccionado inexistente");
                }
            }
            catch (Exception ex)
            {
                return new OperationResult<ProductoDto>(ex);
            }
        }

        public async Task<IOperationResult> BorrarProducto(IOperationRequest request, int id)
        {
            try
            {
                //Elimino la Factura Cuota
                var producto = await _producto.Search(x => x.Id == id && x.IdEstado == 1).FirstOrDefaultAsync();

                if (producto != null)
                {
                    await _producto.DeleteAsync(producto);
                    await _producto.SaveAsync(request);
                }

                return new OperationResult(HttpStatusCode.OK, "Eliminado");
            }
            catch (Exception ex)
            {
                return new OperationResult(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
        }

        public async Task<IOperationResultList<ProductoDto>> ConsultarProductos(IOperationRequest request, string? term, int page = 1, int? pageSize = default)
        {
            try
            {
                //Agregar en campo busqueda
                var producto = _producto
                    .Search(x => (term == null || EF.Functions.Like(x.Nombre, "%" + term + "%")) && x.IdEmpresa == request.IdEmpresa && x.IdEstado == 1)
                    .AsQueryable();

                return await producto.ToResultListAsync<Dp03a110, ProductoDto>(page, pageSize);
            }
            catch (Exception ex)
            {
                return new OperationResultList<ProductoDto>(ex);
            }
        }

    }
}
