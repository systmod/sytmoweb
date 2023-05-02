using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Common;
using DinkToPdf;
using Entidad.BusinessLogic.Mapping;
using Entidad.BusinessLogic.Services;
using Entidad.Domain.Services;

namespace Entidad.API
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


            services.AddScoped<IEntidadService, EntidadService>();

            // PDF Tools
            services.AddSingleton(typeof(DinkToPdf.Contracts.IConverter), new SynchronizedConverter(new PdfTools()));

        }

        protected void ConfigureMapper(IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile<EntidadMappingProfile>();
            });

            var mapper = mapperConfig.CreateMapper();
            
            services.AddSingleton(mapper);
        }
    }
}
