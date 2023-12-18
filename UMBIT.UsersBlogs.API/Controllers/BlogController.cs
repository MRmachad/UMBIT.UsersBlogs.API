using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UMBIT.UsersBlogs.Dominio.Servicos.Interfaces;

namespace UMBIT.UsersBlogs.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlogController : ControllerBase
    {
        private IServicoDeBlog ServicoDeblog;
        public BlogController(IServicoDeBlog servicoDeBlog)
        {
            this.ServicoDeblog = servicoDeBlog;
        }

        [HttpGet]
        [Route("todos")]
        public async Task<IActionResult> ObtenhaTodos()
        {
            var blogs =  this.ServicoDeblog.ObtenhaEntidades();
            return Ok(blogs);
        }

    }
}
