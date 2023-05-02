using AutoMapper;
using Cobro.BusinessLogic.Services;
using Cobro.Domain.Services;
using Common;
using DataAccess.Repositories;
using DinkToPdf;
using Microsoft.EntityFrameworkCore;
using Producto.BusinessLogic.Mapping;

namespace Cobro.API
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


            services.AddScoped<ICobroService, CobroService>();

            // PDF Tools
            services.AddSingleton(typeof(DinkToPdf.Contracts.IConverter), new SynchronizedConverter(new PdfTools()));

        }

        protected void ConfigureMapper(IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile<CobroMappingProfile>();
            });

            var mapper = mapperConfig.CreateMapper();
            
            services.AddSingleton(mapper);
        }
    }
}
