using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMBIT.Core.Repositorio.EntityConfigurate;
using UMBIT.UsersBlogs.Dominio.Entidades;

namespace UMBIT.UsersBlogs.Infra.EF_Config
{
    public class EF_Blog : CoreEntityConfigurate<Blog>
    {
        public override void ConfigureEntidade(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Blog> builder)
        {
            builder.HasKey(t => t.Id);
        }
    }
}
