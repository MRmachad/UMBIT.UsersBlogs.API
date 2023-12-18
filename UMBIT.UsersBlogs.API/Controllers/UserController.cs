using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UMBIT.UsersBlogs.Dominio.Servicos.Interfaces;

namespace UMBIT.UsersBlogs.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IServicoDeUser ServicoDeUser;
        public UserController(IServicoDeUser servicoDeUser)
        {
            this.ServicoDeUser = servicoDeUser;
        }

        [HttpGet]
        [Route("todos")]
        public async Task<IActionResult> ObtenhaTodos()
        {
            var users =  this.ServicoDeUser.ObtenhaEntidades();
            return Ok(users);
        }

    }
}
