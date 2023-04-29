using AutoMapper;
using Common;
using DataAccess.Repositories;
using DinkToPdf;
using Microsoft.EntityFrameworkCore;
using Pago.BusinessLogic.Mapping;
using Pago.BusinessLogic.Services;
using Pago.Domain.Services;

namespace Pago.API
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


            services.AddScoped<IPagoService, PagoService>();

            // PDF Tools
            services.AddSingleton(typeof(DinkToPdf.Contracts.IConverter), new SynchronizedConverter(new PdfTools()));

        }

        protected void ConfigureMapper(IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile<PagoMappingProfile>();
            });

            var mapper = mapperConfig.CreateMapper();
            
            services.AddSingleton(mapper);
        }
    }
}
