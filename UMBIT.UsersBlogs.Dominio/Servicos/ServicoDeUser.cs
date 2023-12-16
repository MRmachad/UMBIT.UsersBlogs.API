using System.Net.Http;
using System.Threading.Tasks;
using UMBIT.Core.Repositorio;
using UMBIT.Core.Repositorio.Repositorio;
using UMBIT.Prototico.Core.API.Servico.Basicos;
using UMBIT.UsersBlogs.Dominio.Entidades;
using UMBIT.UsersBlogs.Dominio.Servicos.Interfaces;

namespace UMBIT.UsersBlogs.Dominio.Servicos
{
    public class ServicoDeUser : ServicoDeRequisicao, IServicoDeUser
    {
        private const int LISTAGEM = 100;
        private readonly IRepositorio<User> RepositorioUser;
        public ServicoDeUser(HttpClient cliente, IUnidadeDeTrabalho unidadeDeTrabalho) : base(cliente)
        {
            this.RepositorioUser = unidadeDeTrabalho.ObtentorDeRepositorio<User>();
        }

        public async Task Sincronize()
        {
            var users = await this.ExecuteGetAsync<User>("/sample-data/users");
        }
    }
}
