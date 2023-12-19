using System;
using System.Collections.Generic;

namespace UMBIT.CORE.API.Servico.Interface
{
    public interface IServicoDeEntidadeBase<T> where T : class
    {
        void AdicionaObjeto(T Entidade);
        T ObtenhaEntidade(params object[] args);
        IEnumerable<T> ObtenhaEntidades();
        void RemovaEntidade(params object[] args);
        void AtualizeEntidade(T Entidade);

    }
}
