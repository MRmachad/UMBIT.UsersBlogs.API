using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMBIT.Prototico.Core.API.Servico.Basicos;

namespace UMBIT.Prototico.Core.API.Servico.Interface
{
    public interface IServicoDeRequisicao
    {
        Task<RequestResponse<T>> ExecuteGetAsync<T>(string path, Dictionary<string, string> keyValuePairs)
            where T : class;
    }
}

