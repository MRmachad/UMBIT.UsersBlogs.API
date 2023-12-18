using System.Net.Http;
using System.Threading.Tasks;
using UMBIT.Core.Repositorio;
using UMBIT.Core.Repositorio.Repositorio;
using UMBIT.CORE.API.Servico.Interface;
using UMBIT.Prototico.Core.API.Servico.Basicos;
using UMBIT.UsersBlogs.Dominio.Entidades;
using UMBIT.UsersBlogs.Dominio.Servicos.Interfaces;

namespace UMBIT.UsersBlogs.Dominio.Servicos
{
    public class ServicoDeBlog : ServicoDeEntidadeBase<Blog>, IServicoDeBlog
    {
        public ServicoDeBlog(IUnidadeDeTrabalho dataServiceFactory) : base(dataServiceFactory)
        {
        }
    }
}
