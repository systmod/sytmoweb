using AutoMapper;
using Common;
using Common.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Producto.Domain.Models;
using Producto.Domain.Request;
using Producto.Domain.Services;

namespace Inventario.API.Controllers
{
    [Route("producto")]
    [ApiController]
    public class ProductoController : ApiControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductoService _producto;
        public ProductoController(IMapper mapper,
        IProductoService producto)
        {
            _mapper = mapper;
            _producto = producto;
        }

        [HttpPost, Route("crear")]
        [ProducesResponseType(typeof(IOperationResult<ProductoDto>), 201)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> GuardarProducto([FromBody] ProductoRequest request)
        {
            try
            {
                var result = await _producto.GuardarProducto(request.ToRequest(this));

                if (result.Success)
                {
                    return Ok(result);
                }
                else
                {
                    return result.ToObjectResult();
                }
            }
            catch (Exception ex)
            {
                return ex.ToObjectResult();
            }
        }

        [HttpGet, Route("consultar/{id}")]
        [ProducesResponseType(typeof(IOperationResult<ProductoDto>), 200)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> ObtenerProductoById(int id)
        {
            try
            {
                var result = await _producto.ObtenerProductoById(this, id);

                if (result.Success)
                {
                    return Ok(result);
                }
                else
                {
                    return result.ToObjectResult();
                }
            }
            catch (Exception ex)
            {
                return ex.ToObjectResult();
            }
        }

        [HttpPut, Route("modificar/{id}")]
        [ProducesResponseType(typeof(IOperationResult<ProductoDto>), 201)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> ModificarProducto(int id, [FromBody] ProductoRequest request)
        {
            try
            {
                var result = await _producto.ModificarProducto(request.ToRequest(this), id);

                if (result.Success)
                {
                    return Ok(result);
                }
                else
                {
                    return result.ToObjectResult();
                }
            }
            catch (Exception ex)
            {
                return ex.ToObjectResult();
            }
        }

        [HttpDelete, Route("eliminar/{id}")]
        [ProducesResponseType(typeof(IOperationResult), 201)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> BorrarProducto(int id)
        {
            try
            {
                var result = await _producto.BorrarProducto(this, id);

                if (result.Success)
                {
                    return Ok(result);
                }
                else
                {
                    return result.ToObjectResult();
                }
            }
            catch (Exception ex)
            {
                return ex.ToObjectResult();
            }
        }

        [HttpGet, Route("productos")]
        [ProducesResponseType(typeof(IOperationResult<ProductoDto>), 200)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> ConsultarProductos(string? term, int page = 1, int? pageSize = default)
        {
            try
            {
                var result = await _producto.ConsultarProductos(this, term, page, pageSize);

                if (result.Success)
                {
                    return Ok(result);
                }
                else
                {
                    return result.ToObjectResult();
                }

            }
            catch (Exception ex)
            {
                return ex.ToObjectResult();
            }
        }
    }
}
