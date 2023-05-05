using AutoMapper;
using Common;
using DataAccess.Models;
using DataAccess.Repositories;
using Inventario.Domain.Models;
using Inventario.Domain.Request;
using Inventario.Domain.Services;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.BusinessLogic.Services
{
    public class TransaccionService: ITransaccionService
    {   

        private readonly IMapper _mapper;
        private readonly IbenderbrauContextProcedures _procedures;
        public readonly IEntityRepository<Dpinvcab> _cabecera;
        public TransaccionService(IMapper mapper,
                            IbenderbrauContextProcedures procedures,
                            IEntityRepository<Dpinvcab> cabecera)
        {
            _mapper = mapper;            
            _procedures = procedures;
            _cabecera = cabecera;
        }

        public async Task<IOperationResult<VentaDto>> GuardarFactura(IOperationRequest<VentaRequest> request)
        {
            try
            {
                if (string.IsNullOrEmpty(request.Data.Tipo))
                    return new OperationResult<VentaDto>(System.Net.HttpStatusCode.BadRequest, "Debe ingresar tipo de transacción");
                

                //Obtengo la secuancia 
                var secuencia = await GenerarSecuencia(request.IdEmpresa, request.Data.Tipo);

                //Guardo la factura
                var comprobante = _mapper.Map<Dpinvcab>(request.Data);
                comprobante.Id = 1;
                comprobante.Numero = secuencia;

                //Genero los impuestos

                await _cabecera.InsertAsync(comprobante);
                await _cabecera.SaveAsync(request);

                var result = _mapper.Map<VentaDto>(comprobante);
                return await result.ToResultAsync();
            }
            catch (Exception ex)
            {
                return new OperationResult<VentaDto>(ex);
            }
        }

        public async Task<string> GenerarSecuencia(int IdEmpresa,string codigo)
        {
            var res = await _procedures.Custom_SecuencialAsync(IdEmpresa, codigo, "03");
            var data = res.FirstOrDefault();
            
            return data.Secuencia;
        }

    }
}
