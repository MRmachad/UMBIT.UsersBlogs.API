using AutoMapper;
using UMBIT.UsersBlogs.Dominio.Entidades;
using UMBIT.UsersBlogs.Dominio.Facade.slingacademy.Entidades;

namespace UMBIT.UsersBlogs.API.Mappers
{
    public class EntidadesMapperProfile : Profile
    {
        public EntidadesMapperProfile()
        {
            CreateMap<User, UserSlingAcademy>().ReverseMap();
            CreateMap<Blog, BlogSlingAcademy>().ReverseMap();
        }
    }
}
