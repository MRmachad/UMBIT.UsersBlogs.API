
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Runtime.CompilerServices;
using UMBIT.Core.Repositorio.BaseEntity;
using UMBIT.Core.Repositorio.Repositorio;
namespace UMBIT.Core.Repositorio
{
    public interface IUnidadeDeTrabalho : IDisposable
    {
        IRepositorio<T> ObtentorDeRepositorio<T>() where T : class;

        int SalveAlteracoes();
        void InicieTransacao();

        void FinalizeTransacao();

        void RevertaTransacao();
    }

}
