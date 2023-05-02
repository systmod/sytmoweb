using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using System.Text.Json;
using System.Collections;
using JsonSerializer = System.Text.Json.JsonSerializer;
using NPOI.SS.Formula.Functions;

namespace Common
{
    
    public static class HttpToolsBuilder
    {
        public static void ConfigureRouting(this IServiceCollection services, IConfiguration configuration = null)
        {
            configuration ??= services.BuildServiceProvider().GetService<IConfiguration>();

            services.ConfigureRouting(configuration["ServicesUrl:Auth"]);
        }

        public static void ConfigureRouting(this IServiceCollection services, string url)
        {
            services.AddHttpClient("binasystem", options =>
            {
                options.BaseAddress = new Uri(url);
            }).AddHeaderPropagation();

            services.AddHeaderPropagation(options =>
            {
                options.Headers.Add("Authorization", x =>
                {
                    return x.HeaderValue;
                });
            });

        }

    }
    public class HttpTools : IHttpTools
    {
        private IHttpClientFactory http;
        private IConfiguration configuration;
        //  private IServiceCollection Services;
        public Dictionary<string, object> ParametersQuery { set; get; }

        public HttpTools(IHttpClientFactory http, IConfiguration configuration)
        {
            this.http = http;
            this.configuration = configuration;
            ParametersQuery = new Dictionary<string, object>();
           /// BasicAutentication = GetCretentials();
        }

        private async Task<StringBuilder> InsertQuery()
        {
            var queryString = new StringBuilder();

            await ParametersQuery.ToList().ForEachAsync(async item =>
            {
                if (queryString.Length > 0) queryString.Append('&');
                queryString.AppendFormat("{0}={1}", item.Key, HttpUtility.UrlEncode($"{item.Value}"));
            });

           
            return queryString;
        }
        public string BasicAutentication { get; private set; }
        private string GetCretentials()
        {
            return Convert.ToBase64String(Encoding.ASCII.GetBytes(configuration["RouteApi:username"] + ":" + configuration["RouteApi:password"]));

        }

        public async Task<HttpResponseMessage> EvalueMethtpp(Methttp methttp, string url, HttpContent httpContent, HttpClient client)
        {
            return methttp switch
            {
                Methttp.POST =>  await client.PostAsync(url, httpContent),
                Methttp.GET =>  await client.GetAsync(url),
                Methttp.PUT =>  await client.PutAsync(url, httpContent),
                Methttp.DELETTE =>  await client.DeleteAsync(url),
                Methttp.PATCH => await client.PatchAsync(url, httpContent),
                Methttp.UNDEFINED => null,
            };

        }
        public async Task<TResul> GetDataHttpAsync<TResul>( string url, Methttp metodohtp = Methttp.GET, object objeto=null, string remplace = null) where TResul : class, new()
        {
            try
            {
                TResul resultado = new TResul();

                if (remplace != null)
                {

                    url = url.Replace("{0}", remplace);
                }
                StringContent httpContents=null;

                if (objeto != null)
                {
                    string jsonString = JsonSerializer.Serialize(objeto);

                 httpContents  = new StringContent(jsonString, Encoding.UTF8, "application/json");

                }
            


                var queryString = await InsertQuery();
                var httpClient = http.CreateClient("binasystem");
               // httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", BasicAutentication);
                httpClient.Timeout = TimeSpan.FromMinutes(5);



                url = httpClient.BaseAddress + $"{url}?{queryString}";

                var result = await EvalueMethtpp(metodohtp, url, httpContents, httpClient);
                ParametersQuery.Clear();
                if (result != null && result.IsSuccessStatusCode)
                {

                    var resultadso = await result.Content.ReadAsStringAsync();
                    JsonDocument jsonDocument = JsonDocument.Parse(resultadso);
                    //validar si la resuesta es un array
                    if (jsonDocument.RootElement.ValueKind == JsonValueKind.Array)
                    {
                        // validar si el modelo es del mismo tipo de objeto
                        if (resultado is IList || typeof(IEnumerable).IsAssignableFrom(resultado.GetType()) && resultado.GetType() != typeof(string))
                        {

                            resultado = JsonConvert.DeserializeObject<TResul>(resultadso);
                            return resultado;
                        }
                        return null;
                    }

                    resultado = JsonConvert.DeserializeObject<TResul>(resultadso);
                    //   resultado = await result.Content.ReadFromJsonAsync<TResul>();
                    return resultado;
                }
                //if (result.StatusCode == HttpStatusCode.BadRequest)
                //{
                //    return null;
                //}
                var content = await result.Content.ReadAsStringAsync();
                resultado = JsonConvert.DeserializeObject<TResul>(content);
                return resultado;
            }
            catch (Exception ex)
            {
                string error = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                error = error + $"Route:{url}";
                throw new Exception(error, ex);
            }

        }


    }
    public enum Methttp
    {
        POST,
        GET,
        PUT,
        DELETTE,
        PATCH,
        UNDEFINED,
    }
}
