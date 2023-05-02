using AutoMapper;
using Cobro.Domain.Models;
using Cobro.Domain.Request;
using Cobro.Domain.Services;
using Common;
using Common.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NPOI.SS.Formula.Functions;

namespace Cobro.API.Controllers
{
    [Route("")]
    [ApiController]
    public class CobroController : ApiControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICobroService _cobro;
        public CobroController(IMapper mapper,
        ICobroService cobro)
        {
            _mapper = mapper;
            _cobro = cobro;
        }

        [HttpGet, Route("metodos")]
        [ProducesResponseType(typeof(IOperationResult<MetodoCobroDto>), 200)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> ConsultarMetodos(int page = 1, int? pageSize = default)
        {
            try
            {
                var result = await _cobro.ConsultarMetodos(this, page,pageSize);

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
        [ProducesResponseType(typeof(IOperationResult<TipoCobroDto>), 200)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> Consultartipos(int page = 1, int? pageSize = default)
        {
            try
            {
                var result = await _cobro.Consultartipos(this, page, pageSize);

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
        
        [HttpPost, Route("crear")]
        [ProducesResponseType(typeof(IOperationResult<CobroDto>), 201)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> GuardarProducto([FromBody] CobroRequest request)
        {
            try
            {
                var result = await _cobro.GuardarCobro(request.ToRequest(this));

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
