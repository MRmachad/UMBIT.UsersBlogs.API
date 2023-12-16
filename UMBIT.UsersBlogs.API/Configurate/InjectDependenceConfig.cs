using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UMBIT.Prototico.Core.API.Configurate.RequestConfigurate;
using UMBIT.UsersBlogs.Dominio.Facade.slingacademy.Servicos;
using UMBIT.UsersBlogs.Dominio.Servicos;
using UMBIT.UsersBlogs.Dominio.Servicos.Interfaces;

namespace UMBIT.UsersBlogs.API.Configurate
{
    public static class InjectDependenceConfig
    {

        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IServicoDeUser, ServicoDeUser>()
                    .AddScoped<IServicoDeRepositorioExterno, SlingAcademyService>()
                    .AddUMBITRequestConfigurate<IServicoDeRepositorioExterno, SlingAcademyService>(configuration, "RepositorioExterno");

            return services;
        }
    }
}
