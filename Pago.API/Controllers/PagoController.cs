using AutoMapper;
using Common;
using Common.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pago.Domain.Models;
using Pago.Domain.Services;

namespace Pago.API.Controllers
{
    [Route("")]
    [ApiController]
    public class PagoController : ApiControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPagoService _pago;
        public PagoController(IMapper mapper,
        IPagoService pago)
        {
            _mapper = mapper;
            _pago = pago;
        }

        [HttpGet, Route("metodos")]
        [ProducesResponseType(typeof(IOperationResult<MetodoPagoDto>), 200)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> ConsultarMetodos(int page = 1, int? pageSize = default)
        {
            try
            {
                var result = await _pago.ConsultarMetodos(this, page, pageSize);

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
        [ProducesResponseType(typeof(IOperationResult<TipoPagoDto>), 200)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> Consultartipos(int page = 1, int? pageSize = default)
        {
            try
            {
                var result = await _pago.Consultartipos(this, page, pageSize);

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
