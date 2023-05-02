using Microsoft.Extensions.DependencyInjection;
using Catalogos.Domain.Services;
using Common;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Catalogos.BusinessLogic.Services;
using DinkToPdf;
using AutoMapper;
using Catalogos.Domain.Mapping;
using Entidad.BusinessLogic.Services;
using Entidad.Domain.Services;

namespace Catalogos.API
{
    public partial class Startup
    {
        protected void ConfigureDependency(IServiceCollection services)
        {
            services.AddTransient<ITools, Tools>();
            services.AddScoped<benderbrauContext>();
            services.AddScoped<DbContext, benderbrauContext>();
            services.AddScoped<benderbrauContext>();
            services.AddScoped(typeof(IEntityRepository<>), typeof(EntityRepository<>));


            services.AddScoped<ICatalogoService,  CatalogoService>();                     

            // PDF Tools
            services.AddSingleton(typeof(DinkToPdf.Contracts.IConverter), new SynchronizedConverter(new PdfTools()));

        }

        protected void ConfigureMapper(IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile<CatalogoMappingProfile>();
            });

            var mapper = mapperConfig.CreateMapper();
            
            services.AddSingleton(mapper);
        }
    }
}
