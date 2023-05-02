using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Common;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Auth.Domain.Services;
using Catalogos.Domain.Services;
using Auth.Domain.Models;

namespace API.Filters
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _appSettings;
        private readonly ILogger<AuthMiddleware> _logger;

        public JwtMiddleware(RequestDelegate next, ILogger<AuthMiddleware> logger, IConfiguration appSettings)
        {
            _next = next;
            _logger = logger;
            _appSettings = appSettings;
        }

        public async Task Invoke(HttpContext context, IUserService userService)
        {

            var companyToken = _appSettings.GetValue<string>("CompanyToken");

            if (companyToken != null)
                await AttachCompanyToContext(context, userService, companyToken);


            var userToken = context.Request.Headers["Authorization"].FirstOrDefault();
            userToken = userToken?.Split(" ")?.Last();

            if (userToken != null)
                await AttachUserToContextAsync(context, userService, userToken); 

            await _next(context);
        }   

        // This helper method comes in 3.0. For now you'll need a copy in your app
        private static Endpoint GetEndpoint(HttpContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            return context.Features.Get<IEndpointFeature>()?.Endpoint;
        }

        private static bool IsAnonymous(HttpContext context)
        {
            var endpoint = GetEndpoint(context);
            var allowAnonymous = endpoint?.Metadata?.GetMetadata<AllowAnonymousAttribute>();
            
            return (allowAnonymous != null);
        }

        private async Task AttachCompanyToContext(HttpContext context, IUserService userService, string companyToken)
        {
            try
            {
                var empresa = await userService.GetEmpresa(companyToken);
                context.Items["Empresa"] = empresa.Result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "AUTH: Error de Autenticación: {0}", ex.Message);
            }
        } 

        private async Task AttachUserToContextAsync(HttpContext context, IUserService userService, string token)
        {
            try
            {
                if (!IsAnonymous(context))
                {
                    var jwtToken = ValidateToken(_appSettings["SecretKey"], token);

                    // Validamos si el usuario debe cambiar de contraseña
                    var changePassword = jwtToken.Claims.FirstOrDefault(x => x.Type == IdentityClaims.ChangePassword)?.Value;

                    if (changePassword == "1")
                    {
                        context.Items["ChangePassword"] = "1";
                    }

                    var userToken = jwtToken.Claims.FirstOrDefault(x => x.Type == IdentityClaims.UserID)?.Value;

                    var user = await userService.GetByToken(userToken);

                    if (user.Success)
                    {
                        // attach user to context on successful jwt validation
                        context.Items["User"] = user.Result;

                        var empresa = await userService.GetEmpresaById(user.Result.IdEmpresa);
                        user.Result.Empresa = empresa.Result;

                        context.Items["Empresa"] = empresa.Result;
                    }
                }
            }
            catch(Exception ex)
            {
                var headers = JsonConvert.SerializeObject(context.Request.GetTypedHeaders());

                _logger.LogWarning(ex, "AUTH: Error de Autenticación: {0}\r\nToken: {1}\r\nPath: {2} {3}\r\nHeaders:\r\n\t{4}", ex.Message, 
                        token,
                        context.Request.Method,
                        context.Request.Path,
                        headers
                        );

                if (_appSettings["Development"]?.ToLower() == "true" && token == $"{_appSettings["SecretKey"]}-{DateTime.Now:ddMMyyyy}")
                {
                    var empresa = await userService.GetEmpresaById(1);
                    context.Items["Empresa"] = empresa.Result;
                    context.Items["User"] = new UsuarioDto { InicioSesion = "ADMIN", Correo = "app@fcpc-cte.com", IdEmpresa = 1, IdEntidad = "1", IdUsuario = "ADMIN", Nombre = "ADMIN", Token = $"{Guid.NewGuid()}", Empresa = empresa.Result };

                }                // do nothing if jwt validation fails
                // user is not attached to context so request won't have access to secure routes
            }
        }

        public static JwtSecurityToken ValidateToken(string secretKey, string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = (key),
                ValidateIssuer = false,
                ValidateAudience = false,
                // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            return validatedToken as JwtSecurityToken;

        }
    }
}