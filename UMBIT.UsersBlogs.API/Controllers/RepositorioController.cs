using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UMBIT.Prototico.Core.API.Controller;
using UMBIT.UsersBlogs.Dominio.Servicos.Interfaces;

namespace UMBIT.UsersBlogs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepositorioController : UMBITControllerBase
    {

        private IServicoDeRepositorioExterno ServicoDeRepositorioExterno;
        public RepositorioController(IServicoDeUser servicoDeUser, IServicoDeRepositorioExterno servicoDeRepositorioExterno)
        {
            this.ServicoDeRepositorioExterno = servicoDeRepositorioExterno;
        }

        [HttpPost]
        [Route("sync")]
        public async Task<IActionResult> SincronizeRepositorio()
        {
            return await MiddlewareDeRetornoAsync(async () =>
            {
                await this.ServicoDeRepositorioExterno.SincronizeDatabaseAsync();

                return Ok();
            });
        }
    }
}
