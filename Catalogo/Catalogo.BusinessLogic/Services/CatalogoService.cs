using AutoMapper;
using Catalogos.Domain.Models;
using Catalogos.Domain.Services;
using Common;
using DataAccess.Models;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Catalogos.BusinessLogic.Services
{
    public class CatalogoService : ICatalogoService
    {
        private readonly IEntityRepository<Pais> _pais;
        private readonly IEntityRepository<Provincia> _provincia;
        private readonly IEntityRepository<Ciudad> _ciudad;
        private readonly IEntityRepository<Parroquia> _parroquia;
        private readonly IMapper _mapper;

        public CatalogoService(IMapper mapper,
            IEntityRepository<Pais> pais,
            IEntityRepository<Provincia> provincia,
            IEntityRepository<Ciudad> ciudad,
            IEntityRepository<Parroquia> parroquia)
        {
            _mapper = mapper;
            _pais = pais;
            _provincia = provincia;
            _ciudad = ciudad;
            _parroquia = parroquia;
        }
        public async Task<IOperationResultList<PaisDto>> GetPaises(string term = default, int page = 1, int? pageSize = default)
        {
            try 
            { 
                var paises = _pais.Search(x => x.IdEstado > 0 && (term == null || x.Pais1.Contains(term)))
                                    .AsQueryable(); // Cargo el resto de la información requerida;

                return await paises.ToResultListAsync<Pais, PaisDto>(page, pageSize);
            }
            catch (Exception ex)
            {
                return new OperationResultList<PaisDto>(ex);
            }
        }

        public async Task<IOperationResultList<ProvinciaDto>> GetProvinciasByIdPais(int idPais ,string term = default, int page = 1, int? pageSize = default)
        {
            try
            {
                var provincias = _provincia.Search(x => x.IdEstado > 0 && x.IdPais== idPais && (term == null || x.Provincia1.Contains(term)))
                                    .AsQueryable(); // Cargo el resto de la información requerida;

                return await provincias.ToResultListAsync<Provincia, ProvinciaDto>(page, pageSize);
            }
            catch (Exception ex)
            {
                return new OperationResultList<ProvinciaDto>(ex);
            }
        }

        public async Task<IOperationResultList<CiudadDto>> GetCiudadesByIdProvincia(int idProvincia, string term = default, int page = 1, int? pageSize = default)
        {
            try
            {
                var ciudades = _ciudad.Search(x => x.IdEstado > 0 && x.IdProvincia == idProvincia && (term == null || x.Ciudad1.Contains(term)))
                                    .AsQueryable(); // Cargo el resto de la información requerida;

                return await ciudades.ToResultListAsync<Ciudad, CiudadDto>(page, pageSize);
            }
            catch (Exception ex)
            {
                return new OperationResultList<CiudadDto>(ex);
            }
        }

        public async Task<IOperationResultList<ParroquiaDto>> GetParroquiasByIdCiudad(int idCiudad, string term = default, int page = 1, int? pageSize = default)
        {
            try
            {
                var parroquias = _parroquia.Search(x => x.IdEstado > 0 && x.IdCiudad == idCiudad && (term == null || x.Parroquia1.Contains(term)))
                                    .AsQueryable(); // Cargo el resto de la información requerida;

                return await parroquias.ToResultListAsync<Parroquia, ParroquiaDto>(page, pageSize);
            }
            catch (Exception ex)
            {
                return new OperationResultList<ParroquiaDto>(ex);
            }
        }

    }
}
