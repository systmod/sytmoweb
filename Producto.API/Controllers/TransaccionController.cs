using AutoMapper;
using Common;
using Common.Http;
using Inventario.Domain.Models;
using Inventario.Domain.Request;
using Inventario.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventario.API.Controllers
{
    [Route("transaccion")]
    [ApiController]
    public class TransaccionController : ApiControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITransaccionService _trn;
        public TransaccionController(IMapper mapper,
        ITransaccionService trn)
        {
            _mapper = mapper;
            _trn = trn;
        }

        [HttpPost, Route("venta/guardar")]
        [ProducesResponseType(typeof(IOperationResult<VentaDto>), 201)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> GuardarFactura([FromBody] VentaRequest request)
        {
            try
            {
                var result = await _trn.GuardarFactura(request.ToRequest(this));

                if (result.Success)
                {
                    return Ok(result);
                }
                return result.ToObjectResult();

            }
            catch (Exception ex)
            {
                return ex.ToObjectResult();
            }
        }

    }
}
