using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UMBIT.Core.Repositorio;
using UMBIT.Core.Repositorio.Repositorio;
using UMBIT.Prototico.Core.API.Servico.Basicos;
using UMBIT.UsersBlogs.Dominio.Entidades;
using UMBIT.UsersBlogs.Dominio.Facade.slingacademy.Entidades;
using UMBIT.UsersBlogs.Dominio.Servicos.Interfaces;

namespace UMBIT.UsersBlogs.Dominio.Facade.slingacademy.Servicos
{
    public class SlingAcademyService : ServicoDeRequisicao, IServicoDeRepositorioExterno
    {
        private const int LIST_COUNT = 100;

        private IMapper Mapper;
        private IUnidadeDeTrabalho UnidadeDeTrabalho;
        private IRepositorio<User> RepositorioDeUser;
        private IRepositorio<Blog> RepositorioDeBlog;
        public SlingAcademyService(HttpClient cliente, IMapper mapper, IUnidadeDeTrabalho unidadeDeTrabalho) : base(cliente)
        {
            this.Mapper = mapper;
            this.UnidadeDeTrabalho = unidadeDeTrabalho;
            this.RepositorioDeBlog = unidadeDeTrabalho.ObtentorDeRepositorio<Blog>();
            this.RepositorioDeUser = unidadeDeTrabalho.ObtentorDeRepositorio<User>();
        }

        public async Task UpdateDatabaseAsync()
        {
            await this.UpdateUsers();
            await this.UpdateBlogs();
        }

        private async Task UpdateUsers()
        {
            this.UnidadeDeTrabalho.InicieTransacao();
            try
            {
                var totalUser = 0;
                var offset = 0;

                do
                {
                    var userList = await this.ExecuteGetAsync<UserListSlingAcademy>("/v1/sample-data/users",
                                                                              new Dictionary<string, string>()
                                                                              {
                                                                              { "offset" ,offset.ToString() },
                                                                              { "limit", LIST_COUNT.ToString() }
                                                                              });

                    if (!userList.ValidationResult.IsValid)
                        continue;

                    var aux = this.Mapper.Map<List<User>>(userList.Frombory.Users);
                    foreach (var item in aux)
                        this.RepositorioDeUser.AdicionetOuAtualize(item);

                    totalUser = userList.Frombory.TotalUsers;
                    offset += LIST_COUNT;
                }
                while (totalUser > offset);

                this.UnidadeDeTrabalho.SalveAlteracoes();
                this.UnidadeDeTrabalho.FinalizeTransacao();
            }
            catch (Exception)
            {

                this.UnidadeDeTrabalho.RevertaTransacao();
                throw;
            }
        }

        public async Task UpdateBlogs()
        {

            this.UnidadeDeTrabalho.InicieTransacao();
            try
            {
                var totalUser = 0;
                var offset = 0;

                do
                {
                    var blogListresult = await this.ExecuteGetAsync<BlogListSlingAcademy>("/v1/sample-data/blog-posts",
                                                                              new Dictionary<string, string>()
                                                                              {
                                                                              { "offset" ,offset.ToString() },
                                                                              { "limit", LIST_COUNT.ToString() }
                                                                              });

                    if (!blogListresult.ValidationResult.IsValid)
                        continue;


                    var aux = this.Mapper.Map<List<Blog>>(blogListresult.Frombory.Blogs);
                    foreach (var item in aux)
                        this.RepositorioDeBlog.AdicionetOuAtualize(item);

                    totalUser = blogListresult.Frombory.TotalBlogs;
                    offset += LIST_COUNT;
                }
                while (totalUser > offset);

                this.UnidadeDeTrabalho.SalveAlteracoes();
                this.UnidadeDeTrabalho.FinalizeTransacao();
            }
            catch (Exception)
            {
                this.UnidadeDeTrabalho.RevertaTransacao();
                throw;
            }

        }
    }
}
