using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UMBIT.UsersBlogs.API.Contracts;
using UMBIT.UsersBlogs.Dominio.Servicos.Interfaces;

namespace UMBIT.UsersBlogs.API.Controllers
{
    public class BlogController : BlogControllerBase
    {
        private const int COUNT_LISTAGEM_MAX = 100;

        private readonly IMapper Mapper;
        private IServicoDeBlog ServicoDeblog;
        public BlogController(IServicoDeBlog servicoDeBlog, IMapper mapper)
        {
            this.Mapper = mapper;
            this.ServicoDeblog = servicoDeBlog;
        }

        public override async Task<ActionResult<BlogsResult>> ObtenhaTodosBlogs([FromQuery] string title, [FromQuery] int? offset = 0, [FromQuery] int? countListagem = 100)
        {
            return await MiddlewareDeRetornoAsync<BlogsResult>(async () =>
            {

                if (offset < 0 || countListagem <= 0 || countListagem > COUNT_LISTAGEM_MAX)
                    return BadRequest("Os parametros de filtragem são invalidos!");

                var blogs = this.ServicoDeblog.ObtenhaEntidades();


                var res = new BlogsResult()
                {
                    Limit = countListagem,
                    Offset = offset,
                    Total_blogs = blogs.Count()
                };

                blogs = String.IsNullOrWhiteSpace(title) ? blogs : this.ServicoDeblog.ObtenhaEntidades().Where(t => t.Title.ToUpper().Contains(title.ToUpper()));


                res.Blogs = this.Mapper.Map<List<Contracts.Blog>>(blogs.OrderBy(t => t.Id).Skip(offset.Value).Take(countListagem.Value));

                return Ok(res);
            });
        }

        public override async Task<ActionResult<Blog>> ObtenhaUnicoBlog(int id)
        {
            return await MiddlewareDeRetornoAsync(async () =>
            {
                var blog = this.ServicoDeblog.ObtenhaEntidade(id);

                if (blog == null) return BadRequest("Nenhum Blog Encontrado!");

                return await Task.FromResult(Ok(this.Mapper.Map<Blog>(blog)));
            });
        }

        public override async Task<IActionResult> RemovaBlog(int id)
        {
            return await MiddlewareDeRetornoAsync(async () =>
            {
                this.ServicoDeblog.RemovaEntidade(id);
                return await Task.FromResult(Ok());
            });
        }
    }
}
