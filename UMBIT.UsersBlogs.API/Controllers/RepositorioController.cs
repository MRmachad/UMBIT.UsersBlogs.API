using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UMBIT.Prototico.Core.API.Controller;
using UMBIT.UsersBlogs.API.Contracts;
using UMBIT.UsersBlogs.Dominio.Servicos.Interfaces;

namespace UMBIT.UsersBlogs.API.Controllers
{
    public class RepositorioController : RepositorioControllerBase
    {

        private IServicoDeRepositorioExterno ServicoDeRepositorioExterno;
        public RepositorioController(IServicoDeUser servicoDeUser, IServicoDeRepositorioExterno servicoDeRepositorioExterno)
        {
            this.ServicoDeRepositorioExterno = servicoDeRepositorioExterno;
        }

        public override async Task<IActionResult> Sincronize()
        {
            return await MiddlewareDeRetornoAsync(async () =>
            {
                await this.ServicoDeRepositorioExterno.SincronizeDatabaseAsync();

                return Ok();
            });
        }

    }
}
