using AutoMapper;
using Common;
using Entidad.Domain.Models;
using Entidad.Domain.Request;
using Entidad.Domain.Services;
using Microsoft.EntityFrameworkCore;
using NPOI.SS.Formula.Functions;
using System;
using System.Net;
using System.Numerics;

namespace Entidad.BusinessLogic.Services
{
    public class EntidadService: IEntidadService
    {
        public readonly IEntityRepository<DataAccess.Models.Entidad> _entidad;
        private readonly IMapper _mapper;
        public EntidadService(IEntityRepository<DataAccess.Models.Entidad> entidad,
            IMapper mapper) 
        {
            _entidad = entidad;
            _mapper = mapper;
        }

        public async Task<IOperationResult<EntidadDto>> GuardarEntidad(IOperationRequest<EntidadRequest> request)
        {
            try
            {
                var entidad = _mapper.Map<DataAccess.Models.Entidad>(request.Data);
                entidad.IdEstado = 1;

                await _entidad.InsertAsync(entidad);   
                await _entidad.SaveAsync(request);

                var result = _mapper.Map<EntidadDto>(entidad);
                return await result.ToResultAsync();


            }
            catch (Exception ex)
            {
                return new OperationResult<EntidadDto>(ex);
            }
        }

        public async Task<IOperationResult<EntidadDto>> ObtenerEntidadById(IOperationRequest request, int id)
        {
            try
            {
                var entidad = _entidad.Search(x => x.Id == id && x.IdEstado > 0)
                    .Include(x => x.IdPaisNavigation)
                    .Include(x => x.IdProvinciaNavigation)
                    .Include(x => x.IdCiudadNavigation)
                    .Include(x => x.IdParroquiaNavigation)
                    .Select(x => _mapper.Map<EntidadDto>(x))
                    .FirstOrDefault();

                return await entidad.ToResultAsync();
            }
            catch (Exception ex)
            {
                return new OperationResult<EntidadDto>(ex);
            }
        }

        public async Task<IOperationResult<EntidadDto>> ModificarEntidad(IOperationRequest<EntidadRequest> request, int id)
        {
            try
            {
                var entidad = _entidad.Search(x => x.IdEmpresa == request.IdEmpresa && x.Id == id)
                            .FirstOrDefault();

                if (entidad != null)
                {
                    entidad = _mapper.Map<DataAccess.Models.Entidad>(entidad, request.Data);

                    await _entidad.UpdateAsync(entidad);
                    await _entidad.SaveAsync(request);

                    var res = _mapper.Map<EntidadDto>(entidad);
                    return await res.ToResultAsync();
                }
                else
                {
                    return new OperationResult<EntidadDto>(HttpStatusCode.NotFound, "ID de la entidad seleccionada inexistente");
                }
            
            }
            catch (Exception ex)
            {
                return new OperationResult<EntidadDto>(ex);
            }
        }

        public async Task<IOperationResult> BorrarEntidad(IOperationRequest request, int id)
        {
            try
            {
                //Elimino la Factura Cuota
                var entidad = await _entidad.Search(x => x.Id == id && x.IdEstado == 1).FirstOrDefaultAsync();

                if (entidad != null)
                {
                    await _entidad.DeleteAsync(entidad);
                    await _entidad.SaveAsync(request);
                }

                return new OperationResult(HttpStatusCode.OK, "Eliminado");
            }
            catch (Exception ex)
            {
                return new OperationResult(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
        }

        public async Task<IOperationResultList<EntidadDto>> ConsultarClientes(IOperationRequest request, string? term, int page = 1, int? pageSize = default)
        {
            try
            {
                //Agregar en campo busqueda
                var clientes = _entidad
                    .Search(x => (term == null || EF.Functions.Like(x.RazonSocial, "%" + term + "%")) && x.IdEmpresa == request.IdEmpresa && x.IdEstado == 1 && x.EsCliente == true)                    
                    .AsQueryable();

                return await clientes.ToResultListAsync<DataAccess.Models.Entidad, EntidadDto>(page, pageSize);
            }
            catch (Exception ex)
            {
                return new OperationResultList<EntidadDto>(ex);
            }
        }

        public async Task<IOperationResultList<EntidadDto>> ConsultarProveedores(IOperationRequest request, string? term, int page = 1, int? pageSize = default)
        {
            try
            {
                //Agregar en campo busqueda
                var clientes = _entidad
                    .Search(x => (term == null || EF.Functions.Like(x.RazonSocial, "%" + term + "%")) && x.IdEmpresa == request.IdEmpresa && x.IdEstado == 1 && x.EsProveedor == true)
                    .AsQueryable();

                return await clientes.ToResultListAsync<DataAccess.Models.Entidad, EntidadDto>(page, pageSize);
            }
            catch (Exception ex)
            {
                return new OperationResultList<EntidadDto>(ex);
            }
        }

    }
}
