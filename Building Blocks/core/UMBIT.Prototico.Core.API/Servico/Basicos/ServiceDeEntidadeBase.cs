using System;
using System.Collections.Generic;
using UMBIT.Core.Repositorio;
using UMBIT.Core.Repositorio.BaseEntity;
using UMBIT.Core.Repositorio.Repositorio;
using UMBIT.CORE.API.Servico.Interface;
using UMBIT.Prototico.Core.Exececoes;

namespace UMBIT.Prototico.Core.API.Servico.Basicos
{
    public abstract class ServicoDeEntidadeBase<T> : IServicoDeEntidadeBase<T> where T : class
    {
        private IRepositorio<T> Repositorio { get; set; }
        private IUnidadeDeTrabalho UnidadeDeTrabalho { get; set; }
        public ServicoDeEntidadeBase(IUnidadeDeTrabalho dataServiceFactory)
        {
            Repositorio = dataServiceFactory.ObtentorDeRepositorio<T>();
        }
        public void AtualizeEntidade(T Entidade)
        {
            try
            {
                Repositorio.Atualize(Entidade);
                UnidadeDeTrabalho.SalveAlteracoes();
            }
            catch (Exception ex)
            {
                throw new UMBITExeception("Erro Ao atualizar entidade", ex);
            }
        }

        public T ObtenhaEntidade(params object[] args)
        {
            try
            {
                return Repositorio.ObtenhaUnico(args);

            }
            catch (Exception ex)
            {
                throw new UMBITExeception("Erro Ao obter entidade", ex);
            }
        }

        public IEnumerable<T> ObtenhaEntidades()
        {
            try
            {
                return Repositorio.ObtenhaTodos();
            }
            catch (Exception ex)
            {
                throw new UMBITExeception("Erro Ao obter entidades", ex);
            }
        }

        public void RemovaEntidade(params object[] args)
        {
            try
            {
                var objeto = this.ObtenhaEntidade(args);
                Repositorio.Remova(objeto);
                UnidadeDeTrabalho.SalveAlteracoes();
            }
            catch (Exception ex)
            {
                throw new UMBITExeception("Erro Ao remover entidade", ex);
            }
        }

        public void AdicionaObjeto(T Entidade)
        {
            try
            {
                Repositorio.Adicione(Entidade);
                UnidadeDeTrabalho.SalveAlteracoes();
            }
            catch (Exception ex)
            {
                throw new UMBITExeception("Erro Ao adicionar entidade", ex);
            }
        }
    }
}
