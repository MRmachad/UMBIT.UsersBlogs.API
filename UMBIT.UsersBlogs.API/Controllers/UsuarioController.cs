using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UMBIT.Prototico.Core.Exececoes;
using UMBIT.UsersBlogs.API.Contracts;
using UMBIT.UsersBlogs.Dominio.Entidades;
using UMBIT.UsersBlogs.Dominio.Servicos.Interfaces;

namespace UMBIT.UsersBlogs.API.Controllers
{
    public class UsuarioController : UsuarioControllerBase
    {
        private const int COUNT_LISTAGEM_MAX = 100;

        private readonly IMapper Mapper;
        private readonly IServicoDeUser ServicoDeUser;
        public UsuarioController(IServicoDeUser servicoDeUser, IMapper mapper)
        {
            this.Mapper = mapper;
            this.ServicoDeUser = servicoDeUser;
        }

        public override async Task<ActionResult<UsersResult>> Listagem(int offset, int countListagem, string fistName)
        {
            //return Ok();   ]
            //return new UsersResult();
            return await MiddlewareDeRetornoAsync(() =>
            {

                if (offset < 0 || countListagem <= 0 || countListagem > COUNT_LISTAGEM_MAX)
                {
                    throw new UMBITExeception("Os parametros de filtragem são invalidos!");
                }

                var users = this.ServicoDeUser.ObtenhaEntidades();


                var res = new UsersResult()
                {
                    Limit = countListagem,
                    Offset = offset,
                    Total_users = users.Count()
                };

                users = String.IsNullOrWhiteSpace(fistName) ? users : this.ServicoDeUser.ObtenhaEntidades().Where(t => t.FirstName.ToUpper() == fistName.ToUpper());


                res.Users = this.Mapper.Map<List<Contracts.User>>(users.OrderBy(t => t.FirstName).Skip(offset).Take(countListagem));

                return Task.FromResult(Ok(res));
            });
        }

        [HttpGet]
        [Route("todos")]
        public async Task<IActionResult> ObtenhaTodos(string fistName, int offset = 0, int countListagem = COUNT_LISTAGEM_MAX)
        {
            return await MiddlewareDeRetornoAsync(() =>
            {

                if (offset < 0 || countListagem <= 0 || countListagem > COUNT_LISTAGEM_MAX)
                    throw new UMBITExeception("Os parametros de filtragem são invalidos!");

                var users = String.IsNullOrWhiteSpace(fistName) ? this.ServicoDeUser.ObtenhaEntidades() : this.ServicoDeUser.ObtenhaEntidades().Where(t => t.FirstName.ToUpper() == fistName.ToUpper());

                return Task.FromResult(Ok(users.OrderBy(t => t.FirstName).Skip(offset).Take(countListagem).ToList()));
            });
        }

        [HttpGet]
        [Route("unico")]
        public async Task<IActionResult> ObtenhaUnico(int id)
        {
            return await MiddlewareDeRetornoAsync(() =>
            {
                var user = this.ServicoDeUser.ObtenhaEntidade(id);
                return Task.FromResult(Ok(user));
            });
        }

        public override Task<IActionResult> Remocao(int id)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        [Route("remova")]
        public async Task<IActionResult> Remova(int id)
        {
            return await MiddlewareDeRetornoAsync(() =>
            {
                this.ServicoDeUser.RemovaEntidade(id);
                return Task.FromResult(Ok());
            });
        }

        public override Task<ActionResult<User>> Unico(int id)
        {
            throw new NotImplementedException();
        }
    }
}
