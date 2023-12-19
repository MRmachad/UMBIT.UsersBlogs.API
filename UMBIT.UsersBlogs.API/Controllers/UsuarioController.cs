using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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

        public override async Task<ActionResult<UsersResult>> ObtenhaTodosUsuarios([Microsoft.AspNetCore.Mvc.FromQuery] string fistName, [Microsoft.AspNetCore.Mvc.FromQuery] int? offset = 0, [Microsoft.AspNetCore.Mvc.FromQuery] int? countListagem = 100)
        {

            return await MiddlewareDeRetornoAsync<UsersResult>(async () =>
            {

                if (offset < 0 || countListagem <= 0 || countListagem > COUNT_LISTAGEM_MAX)
                   return BadRequest("Os parametros de filtragem são invalidos!");

                var users = this.ServicoDeUser.ObtenhaEntidades();


                var res = new UsersResult()
                {
                    Limit = countListagem,
                    Offset = offset,
                    Total_users = users.Count()
                };

                users = String.IsNullOrWhiteSpace(fistName) ? users : this.ServicoDeUser.ObtenhaEntidades().Where(t => t.FirstName.ToUpper().Contains(fistName.ToUpper()));


                res.Users = this.Mapper.Map<List<Contracts.User>>(users.OrderBy(t => t.Id).Skip(offset.Value).Take(countListagem.Value));

                return Ok(res);
            });
        }


        public override async Task<ActionResult<Contracts.User>> ObtenhaUnicoUsuario(int id)
        {
            return await MiddlewareDeRetornoAsync(async () =>
            {
                var user = this.ServicoDeUser.ObtenhaEntidade(id);

                if (user == null) return BadRequest("Nenhum Usuario Encontrado!");

                return await Task.FromResult(Ok(this.Mapper.Map<Contracts.User>(user)));
            });
        }


        public override async Task<IActionResult> RemovaUsuario(int id)
        {
            return await MiddlewareDeRetornoAsync(async () =>
            {
                this.ServicoDeUser.RemovaEntidade(id);
                return await Task.FromResult(Ok());
            });
        }
    }
}
