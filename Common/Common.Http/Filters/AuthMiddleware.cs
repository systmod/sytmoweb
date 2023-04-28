using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;
using Common.Domain.Models;

namespace API.Filters
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _appSettings;
        private readonly ILogger<AuthMiddleware> _logger;
        private readonly string _authAPI;
        public AuthMiddleware(RequestDelegate next, ILogger<AuthMiddleware> logger, IConfiguration appSettings)
        {
            _next = next;
            _appSettings = appSettings;
            _logger = logger;
            _authAPI = appSettings["ServicesUrl:Auth"];
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                var userToken = context.Request.Headers["Authorization"].FirstOrDefault();

                userToken = userToken?.Split(" ")?.Last();

                using var client = new HttpClient();

                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", userToken);

                var result = await client.PostAsync($"{_authAPI}/token", default);

                if (result.IsSuccessStatusCode)
                {
                    var data = await result.Content.ReadAsStringAsync();
                    var user = JsonConvert.DeserializeObject<AuthResult>(data);

                    context.Items["User"] = user.Result;
                    context.Items["Status"] = user.Result.Status;
                    context.Items["Aplicacion"] = user.Result.Aplicacion;
                    context.Items["Empresa"] = user.Result.Empresa;
                    context.Items["Local"] = user.Result.Local;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "AUTH: Error de Autenticación: {0}", ex.Message);
            }
            finally
            {
                await _next(context);
            }
        }
    }
}