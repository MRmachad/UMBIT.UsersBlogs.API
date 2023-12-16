using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using UMBIT.Prototico.Core.API.Servico.Interface;

namespace UMBIT.Prototico.Core.API.Servico.Basicos
{
    public abstract class ServicoDeRequisicao : Service, IServicoDeRequisicao
    {
        private readonly HttpClient cliente;

        public ServicoDeRequisicao(HttpClient cliente)
        {
            this.cliente = cliente;
        }

        public async Task<RequestResponse<T>> ExecuteGetAsync<T>(string path, Dictionary<string, string> keyValuePairs = null)
            where T : class
        {

            var nameValue = new NameValueCollection();
            if (keyValuePairs != null)
                foreach (var keyValue in keyValuePairs)
                {
                    nameValue.Add(keyValue.Key, keyValue.Value);
                }

            var response = await this.cliente.GetAsync(QueryHelpers.AddQueryString(path, keyValuePairs), HttpCompletionOption.ResponseContentRead);

            var filterRes = await this.TratarerrosResponseAsync<T>(response);
            return filterRes;

        }
    }
}
