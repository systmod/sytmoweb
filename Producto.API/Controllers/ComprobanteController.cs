using AutoMapper;
using Common;
using Common.Http;
using Inventario.Domain.Models;
using Inventario.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NPOI.SS.Formula.Functions;
using Producto.Domain.Services;

namespace Inventario.API.Controllers
{
    [Route("comprobante")]
    [ApiController]
    public class ComprobanteController : ApiControllerBase
    {

        private readonly IMapper _mapper;
        private readonly ITipoComprobanteService _tipo;
        public ComprobanteController(IMapper mapper,
        ITipoComprobanteService tipo)
        {
            _mapper = mapper;
            _tipo = tipo;
        }

        [HttpGet, Route("consultar/{codigo}")]
        [ProducesResponseType(typeof(IOperationResult<TipoComprobanteDto>), 200)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> ObtenerComprobanteById(string codigo)
        {
            try
            {
                var result = await _tipo.ObtenerComprobanteById(this, codigo);

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

        [HttpGet, Route("tipos")]
        [ProducesResponseType(typeof(IOperationResult<TipoComprobanteDto>), 200)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> ConsultarTiposByTerm(string? term, int page = 1, int? pageSize = default)
        {
            try
            {
                var result = await _tipo.ConsultarTiposByTerm(this, term, page, pageSize);

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

        [HttpGet, Route("tipo/ventas")]
        [ProducesResponseType(typeof(IOperationResult<TipoComprobanteDto>), 200)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> ConsultarTiposVentas(int page = 1, int? pageSize = default)
        {
            try
            {
                var result = await _tipo.ConsultarTiposByGrupo(this, GrupoComprobante.Venta, page, pageSize);

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

        [HttpGet, Route("tipo/compras")]
        [ProducesResponseType(typeof(IOperationResult<TipoComprobanteDto>), 200)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> ConsultarTiposCompras(int page = 1, int? pageSize = default)
        {
            try
            {
                var result = await _tipo.ConsultarTiposByGrupo(this, GrupoComprobante.Compra , page, pageSize);

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
