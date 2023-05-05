using AutoMapper;
using Common;
using DataAccess.Repositories;
using DinkToPdf;
using Inventario.BusinessLogic.Services;
using Inventario.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Producto.BusinessLogic.Mapping;
using Producto.BusinessLogic.Services;
using Producto.Domain.Services;

namespace Producto.API
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
            services.AddScoped<IbenderbrauContextProcedures, benderbrauContextProcedures>();

            services.AddScoped<IProductoService, ProductoService>();
            services.AddScoped<ITipoComprobanteService, TipoComprobanteService>();
            services.AddScoped<ITransaccionService, TransaccionService>();            
            // PDF Tools
            services.AddSingleton(typeof(DinkToPdf.Contracts.IConverter), new SynchronizedConverter(new PdfTools()));

        }

        protected void ConfigureMapper(IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile<ProductoMappingProfile>();
            });

            var mapper = mapperConfig.CreateMapper();
            
            services.AddSingleton(mapper);
        }
    }
}
