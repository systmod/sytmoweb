using API.Filters;
using Common.Http;
using Common.Reporting;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace Entidad.API
{
    public partial class Startup
    {
        protected IConfiguration Settings { get; }
        protected IWebHostEnvironment Environment { get; }

        protected string Version => Settings["Version"] ?? "1";
        protected string RoutePrefix => Settings["RoutePrefix"] ?? "";

        public Startup(IConfiguration settings, IWebHostEnvironment environment)
        {
            Settings = settings;
            Environment = environment;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            services.AddDbContext<benderbrauContext>(options =>
                options.UseSqlServer(Settings.GetConnectionString("Sytmo"), sql => sql.EnableRetryOnFailure())
            );

            ConfigureDependency(services);            
            ConfigureMapper(services);
            ConfigureSwagger(services);

            services.Configure<FormOptions>(o =>
            {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });

            services.AddControllers(options =>
            {
                options.Filters.Add<ApiAuthorizeAttribute>();
                options.Filters.Add<HttpClientExceptionFilterAttribute>();
            }).AddJsonOptions(options =>
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()))
            .ConfigureApiBehaviorOptions(options => {
                options.SuppressModelStateInvalidFilter = false;
            });

            //GraphHelper.Configure(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options =>
            {
                options.AllowAnyOrigin();
                options.AllowAnyMethod();
                options.AllowAnyHeader();
            });

            app.UseDeveloperExceptionPage();

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                var swaggerEndpoint = $"{RoutePrefix}/swagger/v1/swagger.json";
                options.SwaggerEndpoint(swaggerEndpoint, $"Sytmo API {Environment?.EnvironmentName} v{Version}");
                options.RoutePrefix = string.Empty;

                Console.WriteLine(Environment?.EnvironmentName);
                Console.WriteLine(swaggerEndpoint);
            });

            app.UseDefaultFiles(new DefaultFilesOptions
            {
                RequestPath = $"{RoutePrefix}/index.html"
            });

            app.UseStatusCodePagesWithReExecute("/error/{0}");
            app.UseExceptionHandler("/error");
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseMiddleware<AuthMiddleware>();

            // custom jwt auth middleware  app.UseMiddleware<JwtMiddleware>();

            app.UseEndpoints(endpoints => endpoints.MapControllers());

            ReportClientConfig.Initialize(Settings);
            ApiControllerBase.Initialize(app.ApplicationServices, Settings, env);
            OperationExtensions.Initialize(app.ApplicationServices);
        }

    }
}
