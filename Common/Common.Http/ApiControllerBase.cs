﻿using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using Microsoft.Extensions.DependencyInjection;
using Common;
using Common.Domain.Models;

namespace Common.Http
{
    public abstract class ApiControllerBase : ControllerBase, IOperationRequest
    {
        protected static IConfiguration Settings { get; private set; }
        protected static ITools Tools { get; private set; }
        protected static IMapper Mapper { get; private set; }
        protected static IWebHostEnvironment HostingEnvironment { get; private set; }
        protected string ResourcesPath => Settings["Resources"];
         
        public static void Initialize(IServiceProvider services, IConfiguration config, IWebHostEnvironment hostingEnvironment)
        {
            Settings = config;
            HostingEnvironment = hostingEnvironment;
            Mapper = services.GetService<IMapper>();
            Tools = services.GetService<ITools>();
        }

        public IUserEntity Usuario => (IUserEntity)HttpContext.Items["User"] ?? new UsuarioDto();

        public ICompanyEntity Empresa => (ICompanyEntity)HttpContext.Items["Empresa"] ?? new EmpresaDto();

        public IAdminUnitEntity Local => (IAdminUnitEntity)HttpContext.Items["Local"] ?? new UnidadAdminDto();

        public IApplicationEntity Aplicacion => (IApplicationEntity)HttpContext.Items["Aplicacion"] ?? new AplicacionDto();

        public string Ip => RequestIP?.ToString() ?? "";

        public DateTime Fecha => DateTime.Now;

        public int IdEmpresa => Empresa?.IdEmpresa ?? 1;

        public string InicioSesion => Usuario?.InicioSesion ?? "SYSTEM";

        public IPAddress RequestIP
        {
            get
            {
                var remoteIpAddress = HttpContext.Connection?.RemoteIpAddress;

                return remoteIpAddress;
            }
        }

        //
        // Summary:
        //     Creates a Microsoft.AspNetCore.Mvc.ContentResult object by specifying a HTML template file and model
        //
        // Parameters:
        //   content:
        //     The content to write to the response.
        //
        //   contentType:
        //     The content type (MIME type).
        //
        // Returns:
        //     The created Microsoft.AspNetCore.Mvc.ContentResult object for the response.
        [NonAction]
        protected virtual ContentResult HTML<T>(string template, T model)
        {
            return Content(Tools.GetHtmlTemplate(template, model), "text/html");
        }

        [NonAction]
        protected virtual ObjectResult Error(Exception ex, string message = null)
        {
            var result = new OperationResult(ex)
            {
                Message = message ?? ex.Message
            };

            return StatusCode(500, result);
        }

        [NonAction]
        protected virtual ObjectResult Error(HttpStatusCode statusCode, string message, string exception)
        {
            return StatusCode((int)statusCode, new OperationResult(statusCode, message, exception));
        }

        [NonAction]
        protected virtual ObjectResult Error(IOperationResult result)
        {
            return StatusCode((int)result.StatusCode, result);
        }

        [NonAction]
        protected virtual ObjectResult StatusCode(HttpStatusCode statusCode, object result)
        {
            return StatusCode((int)statusCode, result);
        }

        [NonAction]
        protected virtual ObjectResult StatusCode<T>(IOperationResult<T> result)
        {
            return StatusCode((int)result.StatusCode, result);
        } 
    }


    public static class Extensions
    { 
        public static ObjectResult ToObjectResult<T>(this IOperationResult<T> result) where T : class
        {
            return new ObjectResult(result) { StatusCode = (int)result.StatusCode };
        }

        public static ObjectResult ToObjectResult(this IOperationResult result)
        {
            return new ObjectResult(result) { StatusCode = (int)result.StatusCode };
        } 

        public static ObjectResult ToObjectResult(this Exception ex, string message = null)
        {
            var result = ex.ToResult();
            if (!string.IsNullOrEmpty(message))
            {
                result.Message = message;
            }

            return new ObjectResult(result) { StatusCode = (int)result.StatusCode };
        }
    }
}
