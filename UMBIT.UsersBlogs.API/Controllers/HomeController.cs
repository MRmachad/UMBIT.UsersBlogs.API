using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UMBIT.UsersBlogs.Dominio.Servicos.Interfaces;

namespace UMBIT.UsersBlogs.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private IServicoDeUser ServicoDeUser;
        private IServicoDeRepositorioExterno ServicoDeRepositorioExterno;
        public HomeController(IServicoDeUser servicoDeUser, IServicoDeRepositorioExterno servicoDeRepositorioExterno)
        {
            this.ServicoDeUser = servicoDeUser;
            this.ServicoDeRepositorioExterno = servicoDeRepositorioExterno; 
        }

        [HttpGet]
        [Route("index")]
        public async Task<IActionResult> Index()
        {
            return Ok();
        }

        [HttpPost]
        [Route("sync")]
        public async Task<IActionResult> SincronizeRepositorio()
        {
            await this.ServicoDeRepositorioExterno.UpdateDatabaseAsync();

            return Ok(); 
        }
    }
}
