using Catalogos.Domain.Models;
using Common;
using System.Threading.Tasks;

namespace Catalogos.Domain.Services
{
    public interface ICatalogoService
    {
        Task<IOperationResultList<PaisDto>> GetPaises(string term = default, int page = 1, int? pageSize = default);
        Task<IOperationResultList<ProvinciaDto>> GetProvinciasByIdPais(int idPais, string term = default, int page = 1, int? pageSize = default);
        Task<IOperationResultList<CiudadDto>> GetCiudadesByIdProvincia(int idProvincia, string term = default, int page = 1, int? pageSize = default);
        Task<IOperationResultList<ParroquiaDto>> GetParroquiasByIdCiudad(int idCiudad, string term = default, int page = 1, int? pageSize = default);
    }


}