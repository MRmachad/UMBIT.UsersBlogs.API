using Microsoft.Extensions.DependencyInjection;
using UMBIT.UsersBlogs.API.Mappers;

namespace UMBIT.UsersBlogs.API.Configurate
{
    public static class ProfileMapperConfig
    {
        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(EntidadesMapperProfile));

            return services;
        }
    }
}
