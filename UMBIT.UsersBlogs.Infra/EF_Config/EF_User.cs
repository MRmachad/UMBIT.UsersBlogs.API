using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMBIT.Core.Repositorio.EntityConfigurate;
using UMBIT.UsersBlogs.Dominio.Entidades;

namespace UMBIT.UsersBlogs.Infra.EF_Config
{
    public class EF_User : CoreEntityConfigurate<User>
    {
        public override void ConfigureEntidade(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<User> builder)
        {
            builder.HasMany(t => t.Blogs)
                   .WithOne()
                   .HasForeignKey(t => t.UserId);
        }
    }
}
