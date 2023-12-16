using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UMBIT.Core.Repositorio.Repositorio;
using UMBIT.UsersBlogs.Dominio.Entidades;

namespace UMBIT.UsersBlogs.Infra.Repositorios
{
    public class UserRepositorio : Repositorio<User>, IRepositorio<User>
    {
        public UserRepositorio(DbContext contexto) : base(contexto)
        {
        }      

        public override IEnumerable<User> ObtenhaTodos()
        {
            throw new NotImplementedException();
        }

        public override User ObtenhaUnico(params object[] args)
        {
            throw new NotImplementedException();
        }
    }
}
