using System.Threading.Tasks;
using UMBIT.Prototico.Core.API.Servico.Interface;

namespace UMBIT.UsersBlogs.Dominio.Servicos.Interfaces
{
    public interface IServicoDeRepositorioExterno : IServicoDeRequisicao
    {
        Task SincronizeDatabaseAsync();
    }
}
