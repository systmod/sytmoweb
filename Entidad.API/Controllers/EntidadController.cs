using AutoMapper;
using Common;
using Common.Http;
using Entidad.Domain.Models;
using Entidad.Domain.Request;
using Entidad.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Entidad.API.Controllers
{
    //[TokenAuthorize]
    [Route("")]
    [ApiController]
    public class EntidadController : ApiControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IEntidadService _entidad;
        public EntidadController(IMapper mapper,
        IEntidadService entidad)
        {
            _mapper = mapper;
            _entidad = entidad;
        }

        [HttpPost, Route("crear")]
        [ProducesResponseType(typeof(IOperationResult<EntidadDto>), 201)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> GuardarEntidad([FromBody] EntidadRequest request)
        {
            try
            {
                var result = await _entidad.GuardarEntidad(request.ToRequest(this));

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
        [ProducesResponseType(typeof(IOperationResult<EntidadDto>), 200)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> GetCartaById(int id)
        {
            try
            {
                var result = await _entidad.ObtenerEntidadById(this,id);

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
        [ProducesResponseType(typeof(IOperationResult<EntidadDto>), 201)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> ModificarEntidad(int id,[FromBody] EntidadRequest request)
        {
            try
            {
                var result = await _entidad.ModificarEntidad(request.ToRequest(this),id);

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
        public async Task<IActionResult> BorrarEntidad(int id)
        {
            try
            {
                var result = await _entidad.BorrarEntidad(this, id);

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

        [HttpGet, Route("clientes")]
        [ProducesResponseType(typeof(IOperationResult<EntidadDto>), 200)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> GetClientes(string? term, int page = 1, int? pageSize = default)
        {
            try
            {
                var result = await _entidad.ConsultarClientes(this, term, page, pageSize);

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

        [HttpGet, Route("proveedores")]
        [ProducesResponseType(typeof(IOperationResult<EntidadDto>), 200)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> ConsultarProveedores(string? term, int page = 1, int? pageSize = default)
        {
            try
            {
                var result = await _entidad.ConsultarProveedores(this, term, page, pageSize);

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
