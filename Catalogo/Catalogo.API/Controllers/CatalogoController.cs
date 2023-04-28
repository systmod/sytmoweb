using AutoMapper;
using Catalogos.Domain.Models;
using Catalogos.Domain.Services;
using Common;
using Common.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalogos.API.Controllers
{
    //[TokenAuthorize]
    [Route("")]
    [ApiController]
    public class CatalogoController : ApiControllerBase
    {
        private readonly ICatalogoService _catalogo;
        private readonly IMapper _mapper;

        public CatalogoController(ICatalogoService catalogo, IMapper mapper)
        {
            _catalogo = catalogo;
            _mapper = mapper;
        }

        [HttpGet, Route("paises")]
        [ProducesResponseType(typeof(IEnumerable<PaisDto>), 200)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> GetPaises(string term = null, int page = 1, int? pageSize = default)
        {
            try
            {
                var result = await _catalogo.GetPaises(term, page, pageSize);

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

        [HttpGet, Route("provincias/{idPais}")]
        [ProducesResponseType(typeof(IEnumerable<PaisDto>), 200)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> GetProvinciasByIdPais(int idPais, string term = null, int page = 1, int? pageSize = default)
        {
            try
            {
                var result = await _catalogo.GetProvinciasByIdPais(idPais, term, page, pageSize);

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

        [HttpGet, Route("ciudades/{idProvincia}")]
        [ProducesResponseType(typeof(IEnumerable<PaisDto>), 200)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> GetCiudadesByIdProvincia(int idProvincia, string term = null, int page = 1, int? pageSize = default)
        {
            try
            {
                var result = await _catalogo.GetCiudadesByIdProvincia(idProvincia, term, page, pageSize);

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

        [HttpGet, Route("parroquias/{idCiudad}")]
        [ProducesResponseType(typeof(IEnumerable<PaisDto>), 200)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> GetParroquiasByIdCiudad(int idCiudad, string term = null, int page = 1, int? pageSize = default)
        {
            try
            {
                var result = await _catalogo.GetParroquiasByIdCiudad(idCiudad, term, page, pageSize);

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
