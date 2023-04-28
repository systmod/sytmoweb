using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common
{
    public interface IHttpTools
    {
        public Task<TResul> GetDataHttpAsync<TResul>(string url, Methttp metodohtp = Methttp.GET, object objeto = null, string remplace = null) where TResul : class, new();
        public Dictionary<string, object> ParametersQuery { set; get; }

    }
}
